
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    /// <summary>
    /// Handler cuida do fluxo dos dados, manipula.
    /// </summary>
    public class SubscriptionHandler :
        IHandler<CreateBoletoSubscriptionCommand>
    {
        /// <summary>
        /// tudo que for externo é necessário usar desta forma:
        /// </summary>
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;


        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;   
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validations:
            command.Validate();
            /*if (command.Invalid)
                return new CommandResult(false, "Não foi possível realizar a assinatura");*/
            
            
            //verificar se documento já está cadastrado:
            if(_repository.DocumentExists(command.Document))
                return Handle(command);
            /*AddNotification("Document", "Este CPF já está em uso");*/


            //verificar se e-mail já está cadastrado:
            if(_repository.EmailExists(command.Email))
                return Handle(command);
            /*AddNotification("Email", "Este email já está em uso");*/


            //gerar os VOs:
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(
                command.Street, 
                command.Number, 
                command.Neighborhood, 
                command.City, 
                command.State, 
                command.Country, 
                command.ZipCode);

            //gerar entidades:
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode, 
                command.BoletoNumber, 
                command.PaidDate, 
                command.ExpireDate, 
                command.Total, 
                command.TotalPaid, 
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address, email);

            //gerar os relacionamentos:
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            /*agrupar as validações:
            AddNotifications(name, document, email, address, student, subscription, payment);*/

            /*Checar as notificações:
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");*/

            //salvar as informações
            _repository.CreateSubscription(student);


            //enviar email de boas vindas.
            _emailService.Send(
                student.Name.ToString(), 
                student.Email.Address, 
                "Bem vindo!", "Sua assinatura foi criada");

            //retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        ICommandResult IHandler<CreateBoletoSubscriptionCommand>.Handle(CreateBoletoSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

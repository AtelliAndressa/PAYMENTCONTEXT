using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;


namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
        IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;

        public SubscriptionHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validations
            command.Validate();
            /*if (command.Invalid)
                return new CommandResult(false, "Não foi possível realizar a assinatura");*/
            
            
            //verificar se documento já está cadastrado
            if(_repository.DocumentExists(command.Document))
                return Handle(command);
            /*AddNotification("Document", "Este CPF já está em uso");*/


            //verificar se e-mail já está cadastrado
            if(_repository.EmailExists(command.Email))
                return Handle(command);
            /*AddNotification("Email", "Este email já está em uso");*/


            //gerar os VOs
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

            //gerar entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(null);
            var payment = new BoletoPayment();

            //aplicar as validações

            //salvar as informações

            //enviar email de boas vindas.

            //retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}

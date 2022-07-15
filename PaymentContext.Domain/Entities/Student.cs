using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        /// <summary>
        /// Usamos esta lista para fazer as valida��es na assinatura.
        /// </summary>
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="document"></param>
        /// <param name="email"></param>
        public Student(Guid id, Name name,
                       Document document,
                       Email email,
                       Address address) : base(id)
        {
            Id = id;
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();
        }

        public Guid Id { get; set; }

        /// <summary>
        /// Nome do estudante.
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Documento pessoal do estudante.
        /// </summary>
        public Document Document { get; private set; }

        /// <summary>
        /// Email do estudante.
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Endere�o do estudante.
        /// </summary>
        public Address Address { get; private set; }


        /// <summary>
        /// Usando o IReadOnlyCollection ser� necess�rio usar o m�todo 
        /// desta propriedade para poder adicionar uma assinatura nova, 
        /// obrigando assim a passar pela valida��o usada no m�todo.
        /// </summary>
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        /// <summary>
        /// M�todo de valida��o da assinatura, se est� inativa ser� adicionada uma assinatura.
        /// Se j� estiver ativa n�o poder� fazer outra.
        /// </summary>
        /// <param name="subscription"></param>
        public void AddSubscription(Subscription subscription)
        {
            foreach (var item in Subscriptions)
            {
                item.Inactivate();
            }

            _subscriptions.Add(subscription);
        }

    }
}
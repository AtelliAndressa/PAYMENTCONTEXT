using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        /// <summary>
        /// Usamos esta lista para fazer as validações na assinatura.
        /// </summary>
        private IList<Subscription> _subscriptions;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="document"></param>
        /// <param name="email"></param>
        public Student(Name name, Document document, string email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

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
        public string Email { get; private set; }

        /// <summary>
        /// Endereço do estudante.
        /// </summary>
        public string Address { get; private set; }


        /// <summary>
        /// Usando o IReadOnlyCollection será necessário usar o método 
        /// desta propriedade para poder adicionar uma assinatura nova, 
        /// obrigando assim a passar pela validação usada no método.
        /// </summary>
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        /// <summary>
        /// Método de validação da assinatura, se está inativa será adicionada uma assinatura.
        /// Se já estiver ativa não poderá fazer outra.
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
namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        /// <summary>
        /// Lista de pagamentos.
        /// </summary>
        private IList<Payment> _payments;

        /// <summary>
        /// construtor.
        /// </summary>
        /// <param name="expireDate"></param>
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        /// <summary>
        /// Data de in�cio da assinatura.
        /// </summary>
        public DateTime CreateDate { get; private set; }

        /// <summary>
        /// Data da ultima atualia��o da assinatura.
        /// </summary>
        public DateTime LastUpdateDate { get; private set; }

        /// <summary>
        /// Data de expira��o da assinatura, nullabe.
        /// </summary>
        public DateTime? ExpireDate { get; private set; }

        /// <summary>
        /// O estudante s� pode ter uma assinatura ativa por vez.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Lista de pagamentos para leitura.
        /// </summary>
        public IReadOnlyCollection<Payment> Payments { get; private set; }

        /// <summary>
        /// Esse m�todo adiciona um pagamento novo.
        /// </summary>
        /// <param name="payment"></param>
        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }

        /// <summary>
        /// Esse m�todo mostra se assinatura est� ativa na data atual.
        /// </summary>
        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        /// <summary>
        /// Esse m�todo mostra se assinatura est� inativa na data atual.
        /// </summary>
        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}
using System.Reflection.Metadata;

namespace PaymentContext.Domain.Entities
{
    /// <summary>
    /// O pagamento n�o pode ser instaciado direto.
    /// </summary>
    public abstract class Payment
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="paidDate"></param>
        /// <param name="expireDate"></param>
        /// <param name="total"></param>
        /// <param name="totalPaid"></param>
        /// <param name="document"></param>
        /// <param name="payer"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Document document, string payer, string address, string email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Document = document;
            Payer = payer;
            Address = address;
            Email = email;
        }

        /// <summary>
        /// N�mero do pagamento.
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// Data pagamento
        /// </summary>
        public DateTime PaidDate { get; private set; }

        /// <summary>
        /// Data expira��o do pagamento.
        /// </summary>
        public DateTime ExpireDate { get; private set; }

        /// <summary>
        /// Valor total do pagamento.
        /// </summary>
        public decimal Total { get; private set; }

        /// <summary>
        /// Valor pago.
        /// </summary>
        public decimal TotalPaid { get; private set; }

        /// <summary>
        /// Documento do pagador.
        /// </summary>
        public Document Document { get; private set; }

        /// <summary>
        /// Pessoa respons�vel pelo pagamento.
        /// </summary>
        public string Payer { get; private set; }

        /// <summary>
        /// Endere�o para emetir nota fiscal.
        /// Pode ser o endere�o de cobran�a.
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Email do pagador.
        /// </summary>
        public string Email { get; private set; }
    }
}
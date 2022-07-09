using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="transactionCode"></param>
        /// <param name="paidDate"></param>
        /// <param name="expireDate"></param>
        /// <param name="total"></param>
        /// <param name="totalPaid"></param>
        /// <param name="document"></param>
        /// <param name="payer"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        public PayPalPayment(
            string transactionCode,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            System.Reflection.Metadata.Document document,
            string payer,
            Address address,
            Email email) :
            base(paidDate, expireDate, total,
                totalPaid, document, payer,
                address, email)
        {
            TransactionCode = transactionCode;
        }

        /// <summary>
        /// Código da transação.
        /// </summary>
        public string TransactionCode { get; private set; }
    }
}

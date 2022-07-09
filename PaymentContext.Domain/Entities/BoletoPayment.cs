using PaymentContext.Domain.ValueObjects;
using System.Reflection.Metadata;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        /// <summary>
        /// construtor.
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="boletoNumber"></param>
        /// <param name="paidDate"></param>
        /// <param name="expireDate"></param>
        /// <param name="total"></param>
        /// <param name="totalPaid"></param>
        /// <param name="document"></param>
        /// <param name="payer"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        public BoletoPayment(
            string barCode,
            string boletoNumber,
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
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        /// <summary>
        /// código de pagamento por boleto.
        /// </summary>
        public string BarCode { get; private set; }

        /// <summary>
        /// Número do boleto gerado.
        /// </summary>
        public string BoletoNumber { get; private set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class CreditCarPayment : Payment
    {
        public CreditCarPayment(
            string cardHolderName,
            string cardNumber,
            string lastTransactionNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            Document document,
            string payer,
            string address,
            string email) :
            base(paidDate, expireDate, total,
                totalPaid, document,
                payer, address, email)
        {
            this.CardHolderName = cardHolderName;
            this.CardNumber = cardNumber;
            this.LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }

        /// <summary>
        /// Apenas os ultimos 4 digitos do cartão
        /// </summary>
        public string CardNumber { get; private set; }

        public string LastTransactionNumber { get; private set; }

    }
}
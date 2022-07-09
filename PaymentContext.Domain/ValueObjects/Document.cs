using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; set; }

        /// <summary>
        /// Esse enum traz se é do tipo cpf ou cnpj.
        /// </summary>
        public EDocumentType Type { get; set; }

    }
}

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

            Validate();
        }

        public string Number { get; set; }

        /// <summary>
        /// Esse enum traz se é do tipo cpf ou cnpj.
        /// </summary>
        public EDocumentType Type { get; set; }

        /// <summary>
        /// Validação sendo chamada no construtor.
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            if (Type == EDocumentType.CNPJ && Number.Length == 14)
            {
                return true;
            }
            if (Type == EDocumentType.CPF && Number.Length == 11)
            {
                return true;
            }   
            return false;
        }

    }
}

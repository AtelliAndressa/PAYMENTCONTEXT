using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(FirstName))
            {
                Console.WriteLine("Inválido");
            }
              
        }

        /// <summary>
        /// Nome inical do estudante.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Sobrenome do estudante.
        /// </summary>
        public string LastName { get; private set; }

      
    }
}

namespace PaymentContext.Domain.ValueObjects
{
    public class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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

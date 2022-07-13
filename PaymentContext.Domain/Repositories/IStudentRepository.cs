using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Repositories
{
    /// <summary>
    /// Aqui será abstraído e pode ser usado no infra pra ir pro db.
    /// Aqui será verificado se esses dados já existem em algum local
    /// </summary>
    public interface IStudentRepository
    {
        bool DocumentExists(string document);

        bool EmailExists(string email);

        void CreateSubscription(Student student);
    }
}

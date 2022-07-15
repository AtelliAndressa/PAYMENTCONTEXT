using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Queries
{
    public static class StudentQueries
    {
        /// <summary>
        /// Passando um documento para buscar informações do estudante.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Expression<Func<Student, bool>> GetStudentInfo(string document)
        {
            return x => x.Document.Number == document;
        }
    }
}

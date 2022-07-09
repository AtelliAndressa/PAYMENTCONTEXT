using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Shared.Entities
{
    /// <summary>
    /// Uma entidade possue um Id, um value Objects não, essa classe 
    /// será herdada pelas entidades no domain.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Com o Guid o Id é gerado no dotnet, não depende do db.
        /// É um request a menos no banco.
        /// </summary>
        /// <param name="id"></param>
        protected Entity(Guid id)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Domain.Entities.Base
{
    public class BaseEntity
    {
        protected void BaseEntityPropertys(Guid ıd, DateTime createdDate)
        {
            Id = ıd;
            CreatedDate = createdDate;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}
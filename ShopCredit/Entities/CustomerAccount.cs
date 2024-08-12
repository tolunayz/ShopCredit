using ShopCredit.Domain.Entities;
using ShopCredit.Domain.Entities.Base;
using ShopCredit.Entities;

namespace ShopCredit.Entities
{
    public class CustomerAccount: BaseEntity
    {
        public Guid CustomerId { get; set; }

        public bool IsPaid { get; private set; }

        public string? Description { get; private set; }

        public int CurrentDebt { get; private set; } //**

        public int Debt { get; private set; }   //**

        public int PaidDebt { get; private set; }   //**

        public virtual Customer Customer { get;  set; }

        /// <summary>
        /// CustomerAccount Constructer'ı
        /// </summary>
        public CustomerAccount() { }

        /// <summary>
        /// Customer Acoount Propertyleri
        /// </summary>
        /// <param name="isPaid"></param>
        /// <param name="description"></param>
        /// <param name="currentDebt"></param>
        /// <param name="debt"></param>
        /// <param name="paidDebt"></param>
        /// 

        public void CustomerAccountProperties(bool isPaid, string? description, int currentDebt, int debt, int paidDebt)
        {
            BaseEntityPropertys(Guid.NewGuid(), DateTime.Now);
            
            IsPaid = isPaid;
            Description = description;
            CurrentDebt = currentDebt;
            Debt = debt;
            PaidDebt = paidDebt;
        }

        
    }
}


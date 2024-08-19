using ShopCredit.Domain.Entities;
using ShopCredit.Domain.Entities.Base;

namespace ShopCredit.Entities
{
    public class CustomerAccount : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public bool IsPaid { get; private set; }

        public string? Description { get; private set; }

        public int CurrentDebt { get; private set; } 

        public int Debt { get; private set; }  

        public int PaidDebt { get; private set; }   

        public virtual Customer Customer { get; set; }

        /// <summary>
        /// CustomerAccounts Constructer
        /// </summary>
        public CustomerAccount() { }

        /// <summary>
        /// Customer Account Properties
        /// </summary>
        /// <param name="isPaid"></param>
        /// <param name="description"></param>
        /// <param name="currentDebt"></param>
        /// <param name="debt"></param>
        /// <param name="paidDebt"></param>
        /// 
        public void CustomerAccountProperties(string? description, int debt, int paidDebt)
        {
            Description = description;
            Debt = debt;
            PaidDebt = paidDebt;
        }

        /// <summary>
        /// CustomerAccount Create Method
        /// </summary>
        /// <param name="isPaid"></param>
        /// <param name="description"></param>
        /// <param name="currentDebt"></param>
        /// <param name="debt"></param>
        /// <param name="paidDebt"></param>
        public static CustomerAccount Create(string? description, int debt, int paidDebt,Guid customerId)
        {
            CustomerAccount ca = new CustomerAccount();
            ca.BaseEntityPropertys(Guid.NewGuid(), DateTime.Now);
            ca.Description = description;
            ca.Debt = debt;
            ca.PaidDebt = paidDebt;
            ca.CurrentDebt = debt - paidDebt;
            ca.IsPaid = (debt - paidDebt) == 0;
            ca.CustomerId = customerId;

            return ca;
        }

    }
}


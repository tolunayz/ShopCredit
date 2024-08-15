using ShopCredit.Domain.Entities.Base;
using ShopCredit.Domain.Events;
using ShopCredit.Entities;

namespace ShopCredit.Domain.Entities
{
    public class Customer : BaseEntity
    {

        public string Name { get;  set; }

        public string Surname { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }

        public string Address { get; private set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();

        public Customer()
        {
            CustomerAccounts = new HashSet<CustomerAccount>();
        }

        /// <summary>
        /// Customer Propertyleri
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        public void CustomerProperties
        (
            string name,
            string surname,
            string phoneNumber,
            string? email,
            string address

            )
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;

        }

        /// <summary>
        /// Müşteri oluşturma
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Customer Create(string name, string surname, string phoneNumber, string? email)
        {
            Customer c = new Customer();

            c.BaseEntityPropertys(Guid.NewGuid(), DateTime.Now);
            c.Name = name;
            c.Surname = surname;
            c.PhoneNumber = phoneNumber;
            c.Email = email;


            return c;

        }

        /// <summary>
        /// <see cref="Name"/>, <see cref="Surname"/>, <see cref="PhoneNumber"/> propertylerini update eder
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public Customer Update(string name, string surname, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;

            UpdateDomainEvent(new CustomerChangedEvent()
            {
                CustomerId = Guid.NewGuid(),
            });


            return this;

        }

        /// <summary>
        /// Adres set etmek içindir
        /// </summary>
        /// <param name="address"></param>
        public Customer SetAddress(string address)
        {
            Address = address;
            return this;
        }

        public Customer SetEmail(string email)
        {
            Email = email;
            return this;
        }
        //public Customer SendEmail(string name, string email)
        //{
        //    AddDomainEvent(new CustomerCreatedEvent()
        //    {
        //        CustomerId = Guid.NewGuid(),
        //    });
        //    return this;
        //}

    }
}

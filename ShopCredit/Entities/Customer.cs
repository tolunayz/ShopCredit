using ShopCredit.Domain.Entities.Base;
using ShopCredit.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace ShopCredit.Domain.Entities
{
    public class Customer : BaseEntity
    {

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public int PhoneNumber { get; private set; }

        public string? Email { get; private set; }

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
        public void  CustomerProperties      
        (
            string name,
            string surname,
            int phoneNumber,
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
        public static Customer Create(string name, string surname, int phoneNumber, string? email)
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
        /// Adres set etmek içindir
        /// </summary>
        /// <param name="address"></param>
        public Customer SetAddress(string? address)
        {
            Address = address;
            return this;
        }
     
    }
}

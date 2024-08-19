using ShopCredit.Domain.Entities.Base;

namespace ShopCredit.Entities
{
    public class Admin : BaseEntity
    {

        
        public string AdminName { get; private set; }
        public string AdminPassword { get; private set; }

        /// <summary>
        /// Admin Constructer
        /// </summary>
        /// <param name="adminName"></param>
        /// <param name="adminPassword"></param>
     
        public Admin()
        {
            
        }

        /// <summary>
        /// Admin properties
        /// </summary>
        /// <param name="adminName"></param>
        /// <param name="adminPassword"></param>
        public void AdminProperties(string adminName, string adminPassword)
        {
            //BaseEntityPropertys(Guid.NewGuid(), DateTime.Now);
            AdminName = adminName;
            AdminPassword = adminPassword;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Customer : EntityBase
    {
        public Guid CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public virtual IList<CustomerAddress>? CustomerAddresses { get; set; }
        public virtual IList<CustomerOrder>? CustomerOrders { get; set; }
        public virtual Account Account { get; set; }
    }
}

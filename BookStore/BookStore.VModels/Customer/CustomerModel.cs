using BookStore.Data.Entities;
using BookStore.VModels.CustomerAddress;
using BookStore.VModels.CustomerOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Customer
{
    public class CustomerModel : ModelBase
    {
        public Guid CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public virtual List<CustomerAddressModel>? CustomerAddresses { get; set; }
        public virtual List<CustomerOrderModel>? CustomerOrders { get; set; }
    }
}

using BookStore.Data.Entities;
using BookStore.VModels.Address;
using BookStore.VModels.AddressStatus;
using BookStore.VModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.CustomerAddress
{
    public class CustomerAddressViewModel : ModelBase
    {
        public Guid CustomerId { get; set; }
        public virtual CustomerViewModel Customer { get; set; }
        public Guid AddressId { get; set; }
        public virtual AddressStatusViewModel AddressStatus { get; set; }
        public Guid StatusId { get; set; }
        public virtual AddressViewModel Address { get; set; }
    }
}

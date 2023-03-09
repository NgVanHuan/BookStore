using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Address
{
    public class AddressModel
    {
        public int AddressId { get; set; }
        public string? StreetNumber { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }
        public virtual IList<CustomerAddress>? CustomerAddresses { get; set; }
        public virtual IList<CustomerOrder>? CustomerOrders { get; set; }
    }
}

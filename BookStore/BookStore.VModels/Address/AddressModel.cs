using BookStore.Data.Entities;
using BookStore.VModels.Country;
using BookStore.VModels.CustomerAddress;
using BookStore.VModels.CustomerOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Address
{
    public class AddressModel
    {
        public Guid AddressId { get; set; }
        public string? StreetNumber { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public Guid CountryId { get; set; }
        public virtual CountryModel? Country { get; set; }
        public virtual List<CustomerAddressModel>? CustomerAddresses { get; set; }
        public virtual List<CustomerOrderModel>? CustomerOrders { get; set; }
    }
}

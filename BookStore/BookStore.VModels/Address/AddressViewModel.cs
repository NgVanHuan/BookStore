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
    public class AddressViewModel
    {
        public Guid AddressId { get; set; }
        public string? StreetNumber { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public Guid CountryId { get; set; }
        public virtual CountryViewModel? Country { get; set; }
        public virtual List<CustomerAddressViewModel>? CustomerAddresses { get; set; }
        public virtual List<CustomerOrderViewModel>? CustomerOrders { get; set; }
    }
}

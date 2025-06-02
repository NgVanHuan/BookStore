using BookStore.Data.Entities;
using BookStore.VModels.CustomerAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.AddressStatus
{
    public class AddressStatusViewModel : ModelBase
    {
        public Guid StatusId { get; set; }
        public string? AddressStatusName { get; set; }
        public virtual List<CustomerAddressViewModel>? CustomerAddresses { get; set; }
    }
}

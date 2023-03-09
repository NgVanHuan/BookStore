using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class AddressStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string? AddressStatusName { get; set; }
        public virtual IList<CustomerAddress>? CustomerAddresses { get; set; }
    }
}

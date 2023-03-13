using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class CustomerAddress : EntityBase
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int AddressId { get; set; }
        public virtual AddressStatus AddressStatus { get; set; }
        public int StatusId { get; set; }
        public virtual Address Address { get; set; }
    }
}

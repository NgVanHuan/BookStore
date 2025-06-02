using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class CustomerAddress : EntityBase
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public Guid StatusId { get; set; }
        public virtual AddressStatus AddressStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class CustomerOrder : EntityBase
    {
        public int OrderId { get; set; }
        public virtual IList<OrderLine>? OrderLines { get; set; }
        public virtual IList<OrderHistory>? OrderHistories { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int ShippingMethodId { get; set; }
        public virtual ShippingMethod? ShippingMethod { get; set; }
        public int DestAddressId { get; set; }
        public virtual Address? DestAddress { get; set; }
    }
}

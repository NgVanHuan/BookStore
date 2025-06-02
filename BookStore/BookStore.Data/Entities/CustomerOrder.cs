using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class CustomerOrder : EntityBase
    {
        public Guid OrderId { get; set; }
        public virtual IList<OrderLine>? OrderLines { get; set; }
        public virtual IList<OrderHistory>? OrderHistories { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public Guid ShippingMethodId { get; set; }
        public virtual ShippingMethod? ShippingMethod { get; set; }
        public Guid DestAddressId { get; set; }
        public virtual Address? DestAddress { get; set; }
    }
}

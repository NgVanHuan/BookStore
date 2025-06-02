using BookStore.Data.Entities;
using BookStore.VModels.Address;
using BookStore.VModels.Customer;
using BookStore.VModels.OrderHistory;
using BookStore.VModels.OrderLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.CustomerOrder
{
    public class CustomerOrderViewModel : ModelBase
    {
        public Guid OrderId { get; set; }
        public virtual List<OrderLineViewModel>? OrderLines { get; set; }
        public virtual List<OrderHistoryViewModel>? OrderHistories { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public virtual CustomerViewModel? Customer { get; set; }
        public Guid ShippingMethodId { get; set; }
        public virtual ShippingMethod? ShippingMethod { get; set; }
        public Guid DestAddressId { get; set; }
        public virtual AddressViewModel? DestAddress { get; set; }
    }
}

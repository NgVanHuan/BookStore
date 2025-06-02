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
    public class CustomerOrderModel : ModelBase
    {
        public Guid OrderId { get; set; }
        public virtual List<OrderLineModel>? OrderLines { get; set; }
        public virtual List<OrderHistoryModel>? OrderHistories { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public virtual CustomerModel? Customer { get; set; }
        public Guid ShippingMethodId { get; set; }
        public virtual ShippingMethod? ShippingMethod { get; set; }
        public Guid DestAddressId { get; set; }
        public virtual AddressModel? DestAddress { get; set; }
    }
}

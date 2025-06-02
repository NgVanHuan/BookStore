using BookStore.Data.Entities;
using BookStore.VModels.CustomerOrder;
using BookStore.VModels.OrderStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.OrderHistory
{
    public class OrderHistoryModel : ModelBase
    {
        [Key]
        public Guid HistoryId { get; set; }
        public Guid OrderId { get; set; }
        public virtual CustomerOrderModel? CustomerOrder { get; set; }
        public Guid StatusId { get; set; }
        public virtual OrderStatusModel? OrderStatus { get; set; }
        public DateTime StatusDate { get; set; }
    }
}

using BookStore.Data.Entities;
using BookStore.VModels.OrderHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.OrderStatus
{
    public class OrderStatusModel : ModelBase
    {
        public Guid StatusId { get; set; }
        public string? StatusValue { get; set; }
        public virtual List<OrderHistoryModel>? Histories { get; set; }
    }
}

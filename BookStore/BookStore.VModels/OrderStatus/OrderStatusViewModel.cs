using BookStore.Data.Entities;
using BookStore.VModels.OrderHistory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.OrderStatus
{
    public class OrderStatusViewModel : ModelBase
    {
        public Guid StatusId { get; set; }
        [Display(Name = "Status Value")]
        public string? StatusValue { get; set; }
        public virtual List<OrderHistoryViewModel> Histories { get; set; }
    }
}

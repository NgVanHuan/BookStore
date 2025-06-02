using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class OrderHistory : EntityBase
    {
        [Key]
        public Guid HistoryId { get; set; }
        public Guid OrderId { get; set; }
        public virtual CustomerOrder? CustomerOrder { get; set; }
        public Guid StatusId { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
        public DateTime StatusDate { get; set; }
    }
}

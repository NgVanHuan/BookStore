using BookStore.Data.Entities;
using BookStore.VModels.CustomerOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.OrderLine
{
    public class OrderLineModel : ModelBase
    {
        [Key]
        public Guid LineId { get; set; }
        public Guid OrderId { get; set; }
        public virtual CustomerOrderModel? CustomerOrder { get; set; }
        public Guid BookId { get; set; }
        public virtual Book? Book { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

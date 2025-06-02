using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class OrderStatus : EntityBase
    {
        public Guid StatusId { get; set; }
        public string? StatusValue { get; set; }
        public virtual IList<OrderHistory>? Histories { get; set; }
    }
}

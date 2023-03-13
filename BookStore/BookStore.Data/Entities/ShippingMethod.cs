using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class ShippingMethod : EntityBase
    {
        [Key]
        public int MethodId { get; set; }
        public int MethodName { get; set; }
        public int Code { get; set; }
        public virtual IList<CustomerOrder>? CustomerOrders { get; set; }
    }
}

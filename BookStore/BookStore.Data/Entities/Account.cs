using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Account : EntityBase
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

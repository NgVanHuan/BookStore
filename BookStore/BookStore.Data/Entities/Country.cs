using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Country : EntityBase
    {
        [Key]
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
        public virtual IList<Address>? Addresses { get; set; }
    }
}

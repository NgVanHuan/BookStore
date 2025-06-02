using BookStore.Data.Entities;
using BookStore.VModels.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Country
{
    public class CountryViewModel : ModelBase
    {
        public Guid CountryId { get; set; }
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        public virtual List<AddressViewModel> Addresses { get; set; }
    }
}

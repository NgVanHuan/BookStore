using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Entities
{
    public class OrderLine : EntityBase
    {
        [Key]
        public int LineId { get; set; }

        public int OrderId { get; set; }
        public virtual CustomerOrder? CustomerOrder { get; set; }
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
        public int Price { get; set; }
    }
}
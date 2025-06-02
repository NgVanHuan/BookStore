using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Entities
{
    public class OrderLine : EntityBase
    {
        [Key]
        public Guid LineId { get; set; }
        public Guid OrderId { get; set; }
        public virtual CustomerOrder? CustomerOrder { get; set; }
        public Guid BookId { get; set; }
        public virtual Book? Book { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
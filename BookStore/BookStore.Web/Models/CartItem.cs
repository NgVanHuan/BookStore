using BookStore.Data.Entities;

namespace BookStore.Web.Models
{
    public class CartItem
    {
        public Book Books { get; set; }
        public int Quantity { get; set; }
    }
}

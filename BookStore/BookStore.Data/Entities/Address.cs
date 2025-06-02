namespace BookStore.Data.Entities
{
    public class Address : EntityBase
    {
        public Guid AddressId { get; set; }
        public string? StreetNumber { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country? Country { get; set; }
        public virtual IList<CustomerAddress>? CustomerAddresses { get; set; }
        public virtual IList<CustomerOrder>? CustomerOrders { get; set; }
    }
}
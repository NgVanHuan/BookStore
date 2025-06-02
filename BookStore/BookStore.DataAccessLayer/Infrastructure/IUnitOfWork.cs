using BookStore.DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Infrastructure
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get; }
        IAddressStatusRepository AddressStatusRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IBookAuthorRepository BookAuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IBookLanguageRepository BookLanguageRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICustomerAddressRepository CustomerAddressRepository { get; }
        ICustomerOrderRepository CustomerOrderRepository { get; }
        IOrderHistoryRepository OrderHistoryRepository { get; }
        IOrderLineRepository OrderLineRepository { get; }
        IOrderStatusRepository OrderStatusRepository { get; }
        IPublisherRepository PublisherRepository { get; }
        //ICartRepository CartRepository { get; }
        int SaveChanges();
    }
}

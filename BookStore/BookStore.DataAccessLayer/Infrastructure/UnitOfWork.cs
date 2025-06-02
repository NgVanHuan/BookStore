using BookStore.Data.Context;
using BookStore.DataAccessLayer.IRepository;
using BookStore.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext _context;
        private IAddressRepository _addressRepository;
        private IAddressStatusRepository _addressStatusRepository;
        private IAuthorRepository _authorRepository;
        private IBookAuthorRepository _bookAuthorRepository;
        private IBookRepository _bookRepository;
        private IBookLanguageRepository _bookLanguageRepository;
        private ICategoryRepository _categoryRepository;
        private ICountryRepository _countryRepository;
        private ICustomerRepository _customerRepository;
        private ICustomerAddressRepository _customerAddressRepository;
        private ICustomerOrderRepository _customerOrderRepository;
        private IOrderHistoryRepository _orderHistoryRepository;
        private IOrderLineRepository _orderLineRepository;
        private IOrderStatusRepository _orderStatusRepository;
        private IPublisherRepository _publisherRepository;
        //private ICartRepository _cartRepository;

        public UnitOfWork(BookDbContext context)
        {
            _context = context;
        }

        public IAddressRepository AddressRepository => _addressRepository ??= (IAddressRepository)new AddressRepository(_context);
        public IAddressStatusRepository AddressStatusRepository => _addressStatusRepository ??= (IAddressStatusRepository)new AddressStatusRepository(_context);
        public IAuthorRepository AuthorRepository => _authorRepository ??= (IAuthorRepository)new AuthorRepository(_context);
        public IBookAuthorRepository BookAuthorRepository => _bookAuthorRepository ??= (IBookAuthorRepository)new BookAuthorRepository(_context);
        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_context);
        public IBookLanguageRepository BookLanguageRepository => _bookLanguageRepository ??= (IBookLanguageRepository)new BookLanguageRepository(_context);
        public ICategoryRepository CategoryRepository => _categoryRepository ??= (ICategoryRepository)new CategoryRepository(_context);
        public ICountryRepository CountryRepository => _countryRepository ??= (ICountryRepository)new CountryRepository(_context);
        public ICustomerRepository CustomerRepository => _customerRepository ??= (ICustomerRepository)new CustomerRepository(_context);
        public ICustomerAddressRepository CustomerAddressRepository => _customerAddressRepository ??= (ICustomerAddressRepository)new CustomerAddressRepository(_context);
        public ICustomerOrderRepository CustomerOrderRepository => _customerOrderRepository ??= (ICustomerOrderRepository)new CustomerOrderRepository(_context);
        public IOrderHistoryRepository OrderHistoryRepository => _orderHistoryRepository ??= (IOrderHistoryRepository)new OrderHistoryRepository(_context);
        public IOrderLineRepository OrderLineRepository => _orderLineRepository ??= (IOrderLineRepository)new OrderLineRepository(_context);
        public IOrderStatusRepository OrderStatusRepository => _orderStatusRepository ??= (IOrderStatusRepository)new OrderStatusRepository(_context);
        public IPublisherRepository PublisherRepository => _publisherRepository ??= (IPublisherRepository)new PublisherRepository(_context);
        //public ICartRepository CartRepository => _cartRepository ??= (ICartRepository)new CartRepository(_context);

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

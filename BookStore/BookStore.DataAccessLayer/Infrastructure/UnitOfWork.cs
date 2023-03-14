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
        private ICategoryRepository _categoryRepository;

        public UnitOfWork(BookDbContext context)
        {
            _context = context;
        }

        public IAddressRepository AddressRepository => _addressRepository ??= (IAddressRepository)new AddressRepository(_context);
        public ICategoryRepository CategoryRepository => _categoryRepository ??= (ICategoryRepository)new CategoryRepository(_context);

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

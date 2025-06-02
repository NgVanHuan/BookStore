using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        private readonly BookDbContext _context;

        public AddressRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }

        public Address GetByIdWithCountry(Guid addressId)
        {
            return _context.Addresses
                .Include(a => a.Country)
                .FirstOrDefault(a => a.AddressId == addressId);
        }
    }
}

using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository
{
    public class BookAuthorRepository : BaseRepository<BookAuthor>, IBookAuthorRepository
    {
        private readonly BookDbContext _context;
        public BookAuthorRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

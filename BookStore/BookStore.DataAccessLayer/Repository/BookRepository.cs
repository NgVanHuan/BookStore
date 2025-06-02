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
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books.AsQueryable();
        }

        public Book GetByIdWithAll(Guid id)
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .Include(b => b.BookLanguage)
                .FirstOrDefault(b => b.BookId == id);
        }
    }
}

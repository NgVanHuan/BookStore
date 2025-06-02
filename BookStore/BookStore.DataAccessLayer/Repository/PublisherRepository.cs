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
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BookDbContext context) : base(context)
        {
        }
    }
}

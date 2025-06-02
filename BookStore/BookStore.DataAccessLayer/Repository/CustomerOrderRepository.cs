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
    public class CustomerOrderRepository : BaseRepository<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(BookDbContext context) : base(context)
        {
        }
    }
}

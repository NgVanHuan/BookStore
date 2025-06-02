using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repository
{
    public class OrderStatusRepository : BaseRepository<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(BookDbContext context) : base(context)
        {
        }
    }
}

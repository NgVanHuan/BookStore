using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.IRepository
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
    }
}

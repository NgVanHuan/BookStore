using AutoMapper;
using BookStore.Data.Entities;
using BookStore.VModels.Address;

namespace BookStore.Web.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Address, AddressViewModel>().ReverseMap();
        }
    }
}

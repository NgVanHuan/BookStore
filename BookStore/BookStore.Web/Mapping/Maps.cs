using AutoMapper;
using BookStore.Data.Entities;
using BookStore.VModels.Address;
using BookStore.VModels.Author;
using BookStore.VModels.Books;
using BookStore.VModels.BookLanguage;
using BookStore.VModels.Category;
using BookStore.VModels.Country;
using BookStore.VModels.OrderStatus;
using BookStore.VModels.Publisher;
using BookStore.VModels.BookAuthor;
using BookStore.VModels.AddressStatus;
using BookStore.VModels.CustomerAddress;
using BookStore.VModels.Customer;
using BookStore.VModels.CustomerOrder;
using BookStore.VModels.OrderHistory;
using BookStore.VModels.OrderLine;

namespace BookStore.Web.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<AddressStatus, AddressStatusViewModel>().ReverseMap();
            CreateMap<Author, AuthorViewModel>().ReverseMap();

            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.BookLanguage, opt => opt.MapFrom(src => src.BookLanguage))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
                .ReverseMap();

            CreateMap<BookAuthor, BookAuthorViewModel>()
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ReverseMap();

            CreateMap<BookLanguage, BookLanguageViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();

            CreateMap<CustomerOrder, CustomerOrderModel>().ReverseMap();
            CreateMap<OrderLine, OrderLineModel>().ReverseMap();
            CreateMap<OrderHistory, OrderHistoryModel>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusModel>().ReverseMap();

            CreateMap<CustomerOrderViewModel, CustomerOrderModel>().ReverseMap();
            CreateMap<OrderLineViewModel, OrderLineModel>().ReverseMap();
            CreateMap<OrderHistoryViewModel, OrderHistoryModel>().ReverseMap();
            CreateMap<OrderStatusViewModel, OrderStatusModel>().ReverseMap();

            CreateMap<CustomerAddress, CustomerAddressViewModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.AddressStatus, opt => opt.MapFrom(src => src.AddressStatus))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ReverseMap();

            //CreateMap<CustomerOrder, CustomerOrderViewModel>()
            //    .ForMember(dest => dest.DestAddress, opt => opt.MapFrom(src => src.DestAddress))
            //    .ForMember(dest => dest.ShippingMethod, opt => opt.MapFrom(src => src.ShippingMethod))
            //    .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            //    .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines))
            //    .ReverseMap();

            CreateMap<CustomerOrder, CustomerOrderViewModel>()
                .ForMember(dest => dest.DestAddress, opt => opt.MapFrom(src => src.DestAddress))
                .ForMember(dest => dest.ShippingMethod, opt => opt.MapFrom(src => src.ShippingMethod))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines))
                .ForMember(dest => dest.OrderHistories, opt => opt.MapFrom(src => src.OrderHistories))
                .ReverseMap();

            CreateMap<OrderHistory, OrderHistoryViewModel>()
                .ForMember(dest => dest.CustomerOrder, opt => opt.MapFrom(src => src.CustomerOrder))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus))
                .ReverseMap();

            CreateMap<OrderLine, OrderLineViewModel>()
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book))
                .ForMember(dest => dest.CustomerOrder, opt => opt.MapFrom(src => src.CustomerOrder))
                .ReverseMap();

            CreateMap<OrderStatus, OrderStatusViewModel>().ReverseMap();
            CreateMap<Publisher, PublisherViewModel>().ReverseMap();
        }
    }
}

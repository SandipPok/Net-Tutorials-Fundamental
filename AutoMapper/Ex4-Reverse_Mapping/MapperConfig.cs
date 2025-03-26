using AutoMapper;
using Ex4_Reverse_Mapping.Model;

namespace Ex4_Reverse_Mapping
{
    class MapperConfig
    {
        public static Mapper InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.OrderId, org => org.MapFrom(src => src.OrderNo))
                .ForMember(dest => dest.CustomerId, org => org.MapFrom(src => src.Customer.CustomerID))
                .ForMember(dest => dest.Name, org => org.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.Postcode, org => org.MapFrom(src => src.Customer.Postcode))
                .ForMember(dest => dest.MobileNo, org => org.MapFrom(src => src.Customer.ContactNo))
                .ReverseMap();
            });

            return new Mapper(config);
        }
    }
}

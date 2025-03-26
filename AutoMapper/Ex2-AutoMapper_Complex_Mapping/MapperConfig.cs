using AutoMapper;
using Ex2_AutoMapper_Complex_Mapping.Model;
namespace Ex2_AutoMapper_Complex_Mapping
{
    class MapperConfig
    {
        public static Mapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.AddressDto, act => act.MapFrom(src => src.Address));
                cfg.CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.EmpState, act => act.MapFrom(src => src.State))
                .ForMember(dest => dest.EmpCity, act => act.MapFrom(src => src.City));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}

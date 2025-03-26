using AutoMapper;
using Ex3_MapComplex_Type_To_Primitive_Type.Model;

namespace Ex3_MapComplex_Type_To_Primitive_Type
{
    class MapperConfig
    {
        public static Mapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                //.ForMember(des => des.City, act => act.MapFrom(src => src.Address.City))
                //.ForMember(des => des.State, act => act.MapFrom(src => src.Address.State))
                //.ForMember(des => des.Country, act => act.MapFrom(src => src.Address.Country));

                .ForMember(dest => dest.Address, act => act.MapFrom(src => new Address()
                {
                    Country = src.Country,
                    State = src.State,
                    City = src.City
                }));
            });

            return new Mapper(config);
        }
    }
}

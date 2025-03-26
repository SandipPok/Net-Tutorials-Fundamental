using AutoMapper;
using AutoMapperDemo.Models;

namespace AutoMapperDemo
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}

using AutoMapper;
using UserServices.DTO;
using UserServices.Model;

namespace UserServices.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

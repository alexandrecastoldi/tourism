using AutoMapper;
using Snowman.Tourism.Domain;
using Snowman.Tourism.Domain.Identity;
using Snowman.Tourism.WebApi.Dto;

namespace Snowman.Tourism.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Picture, PictureDto>().ReverseMap();
            CreateMap<Spot, SpotDto>().ReverseMap();
            CreateMap<Spot, SpotDetailDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}

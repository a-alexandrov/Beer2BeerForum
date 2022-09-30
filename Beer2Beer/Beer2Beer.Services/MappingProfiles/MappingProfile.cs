using AutoMapper;
using Beer2Beer.DTO;
using Beer2Beer.Models;

namespace QuizOverflow.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserFullDto>();
            CreateMap<UserFullDto, User>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<User, UserLoginDto>();
            CreateMap<UserLoginDto, User>();

            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}

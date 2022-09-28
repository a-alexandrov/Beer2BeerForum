using AutoMapper;
using Beer2Beer.DTO;
using Beer2Beer.Models;

namespace QuizOverflow.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}

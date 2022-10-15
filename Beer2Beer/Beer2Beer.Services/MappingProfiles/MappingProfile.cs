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

            CreateMap<Post, PostDto>()
                .ForMember(d=>d.Tags,d=>d.MapFrom(p=>p.TagPosts));
            CreateMap<PostDto, Post>()
                .ForMember(p=>p.TagPosts,p=>p.MapFrom(d=>d.Tags));

            CreateMap<Post, PostCreateDto>();
            CreateMap<PostCreateDto, Post>();

            CreateMap<User, UserLoginDto>();
            CreateMap<UserLoginDto, User>();

            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();

            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<Comment, CommentFullDto>();
            CreateMap<CommentFullDto, Comment>();

            CreateMap<Comment, CommentCreateDto>();
            CreateMap<CommentCreateDto, Comment>();
        }
    }
}

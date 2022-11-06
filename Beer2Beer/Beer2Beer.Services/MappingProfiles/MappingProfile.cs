using AutoMapper;
using Beer2Beer.DTO;
using Beer2Beer.Models;

namespace Beer2Beer.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserFullDto>();
            CreateMap<UserFullDto, User>();

            CreateMap<User, UserDisplayDto>()
                .ForMember(d => d.AvatarImage, d => d.MapFrom(p => p.AvatarImage))
                .ForMember(d => d.ImageType, d => d.MapFrom(p => p.ImageType));

            CreateMap<UserDisplayDto, User>();

            CreateMap<User, UserLoginDto>();
            CreateMap<UserLoginDto, User>();

            CreateMap<User, UserRegisterDto>()
                .ForMember(d => d.Password, d => d.MapFrom(u => u.PasswordHash));
            CreateMap<UserRegisterDto, User>()
                .ForMember(u => u.PasswordHash, u => u.MapFrom(d => d.Password));

            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<Post, PostDto>()
                .ForMember(d => d.Tags, d => d.MapFrom(p => p.TagPosts))
                .ForMember(d => d.AvatarImage, d => d.MapFrom(p => p.User.AvatarImage))
                .ForMember(d => d.ImageType, d => d.MapFrom(p => p.User.ImageType))
                .ForMember(d => d.UserName, d => d.MapFrom(p => p.User.Username));
            CreateMap<PostDto, Post>()
                .ForMember(p => p.TagPosts, p => p.MapFrom(d => d.Tags));

            CreateMap<Post, PostCreateDto>();
            CreateMap<PostCreateDto, Post>();

            CreateMap<Post, LikesDto>();

            CreateMap<Comment, CommentInPostDTO>();
            CreateMap<CommentInPostDTO, Comment>();

            CreateMap<Comment, CommentFullDto>();
            CreateMap<CommentFullDto, Comment>();

            CreateMap<Comment, CommentCreateDto>();
            CreateMap<CommentCreateDto, Comment>();

            CreateMap<Comment, CommentUpdateDto>();
            CreateMap<CommentUpdateDto, Comment>();
        }
    }
}

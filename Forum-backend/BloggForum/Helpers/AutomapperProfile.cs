using AutoMapper;
using Forum.Entities;
using Forum.RequestModel;
using Forum.Db_Context;
using Forum.Helpers;
using Forum.Auth;
using BCrypt.Net;
using Forum.Controllers;

namespace Forum.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<UserAuthRequest, User>();
            CreateMap<User, UserAuthResponse>();
            CreateMap<UpdateUser, User>();
            CreateMap<CreatePostRequest, Forumpost>();
        }
    }
}

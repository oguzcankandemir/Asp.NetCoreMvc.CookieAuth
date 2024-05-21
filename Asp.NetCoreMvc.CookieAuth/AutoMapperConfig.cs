using Asp.NetCoreMvc.CookieAuth.Entities;
using Asp.NetCoreMvc.CookieAuth.Models;
using AutoMapper;

namespace Asp.NetCoreMvc.CookieAuth
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();  
            CreateMap<User, EditUserModel>().ReverseMap();
        }
    }
}

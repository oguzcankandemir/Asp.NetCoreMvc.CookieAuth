using Asp.NetCoreMvc.CookieAuth.Entities;
using Asp.NetCoreMvc.CookieAuth.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreMvc.CookieAuth.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public UserController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<User> users = _databaseContext.Users.ToList();
            List<UserModel> model = users.Select(x => _mapper.Map<UserModel>(x)).ToList();//Select dolaşmak demek 
            return View(model);
        }
    }
}

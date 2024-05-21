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
            List<UserModel> model = users.Select(x => _mapper.Map<UserModel>(x)).ToList();//Select dolaşmak demek <Çevir>
            //List<UserModel> users =
            //   _databaseContext.Users.ToList()
            //       .Select(x => _mapper.Map<UserModel>(x)).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exists.");
                    return View(model);
                }

                User user = _mapper.Map<User>(model);

                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            User user = _databaseContext.Users.Find(id);
            EditUserModel model = _mapper.Map<EditUserModel>(user);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exists.");
                    return View(model);
                }

                User user = _databaseContext.Users.Find(id);

                _mapper.Map(model, user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            User user = _databaseContext.Users.Find(id);

            if (user != null)
            {
                _databaseContext.Users.Remove(user);
                _databaseContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

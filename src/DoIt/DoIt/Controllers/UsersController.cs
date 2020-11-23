using DoIt.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DoIt.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService _usersService;

        public UsersController()
        {
            _usersService = new UsersService();
        }


        // GET: Users
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult LogIn(string email, string password)
        {

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(string name, string phone, string email, string password, string address)
        {
            var newUser = new User { 
                Name = name,
                PhoneNumber = phone,
                Email = email, 
                Password = password, 
                Address = address,
                ProviderScore = 0,
                CustomerScore = 0
            };

            await _usersService.CreateUser(newUser);

            return RedirectToAction("Index", "Home");
        }
    }
}
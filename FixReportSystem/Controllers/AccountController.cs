using Microsoft.AspNetCore.Mvc;
using FixReportSystem.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FixReportSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ModelContext _context;
        public AccountController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // De la tabla users selecciona el nombre donde el correo y la contrasenia sean igual a los parametros
            var username = from usr in _context.Users
                           where usr.Email == email && usr.Password == password
                           select usr.UserName;
            ViewBag.DynamicThing = $"Bienvenido {username.SingleOrDefault()}!";

            //sepa la vrga porque no me jala el email jsjsj
            var user = _context.Users.Where(s => s.Email == email && s.Password == password);
            if (user.Any())
            {
                if (user.Where(s => s.Email == email && s.Password == password).Any())
                {
                    return View("index");
                }
                else
                {
                    return View(); //pass incorrecto
                }
            }
            else
            {
                ViewBag.DynamicThing = "Credenciales incorrectas";
                return View();
            }
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            user.UserId = Guid.NewGuid().ToString();
            user.ConfirmPassword = user.Password;   //Me dio weba
            _context.Users.Add(user);
            _context.SaveChanges();
            return View("Login");
        }
        public IActionResult Signout()
        {
            return View();
        }
    }
}

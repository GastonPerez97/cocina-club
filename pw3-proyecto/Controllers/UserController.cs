using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Services.Interfaces;

namespace pw3_proyecto.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        public IActionResult Login(IFormCollection form)
        {
            string email = form["Email"];
            string password = form["Password"];

            Usuario user = _userService.Login(email, password);

            if (user != null)
            {
                HttpContext.Session.SetString("Name", user.Nombre);
                HttpContext.Session.SetInt32("Profile", user.Perfil);

                return user.Perfil == Profiles.Cocinero
                    ? RedirectToAction("Perfil", "Cocinero")
                    : RedirectToAction("Reservas", "Comensal");
            }
            else
            {
                ViewBag.Email = email;
                ViewBag.Password = password;
                ViewBag.WrongEmailOrPassword = "Usuario o contraseña incorrecta.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Usuario user)
        {
            if (ModelState.IsValid)
            {
                _userService.Save(user);
                TempData["RegisterOk"] = "¡Registrado correctamente! Ya puedes iniciar sesión.";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.RegisterError = "Ocurrió un error al momento del registro, intente nuevamente.";
                return View(user);
            }
        }
    }
}

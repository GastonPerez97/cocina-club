using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Services.Interfaces;

namespace pw3_proyecto.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(IFormCollection form)
        {
            string email = form["Email"];
            string password = form["Password"];

            Usuario user = _userService.Login(email, password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.IdUsuario);
                HttpContext.Session.SetString("Name", user.Nombre);
                HttpContext.Session.SetInt32("Profile", user.Perfil);

                return user.Perfil == Profiles.Cocinero
                    ? RedirectToAction("Perfil", "Cocineros")
                    : RedirectToAction("Reservas", "Comensales");
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

        [Route("registracion")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("registracion")]
        public IActionResult Register(Usuario user)
        {
            if (_userService.CheckIfUserExists(user.Email))
            {
                ViewBag.RegisterError = "El E-Mail ya se encuentra en uso, utiliza otro.";
                return View();
            }
            else if (ModelState.IsValid)
            {
                _userService.Save(user);
                TempData["RegisterOk"] = "¡Registrado correctamente! Ya puedes iniciar sesión.";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.RegisterError = "Ocurrió un error al momento del registro, intente nuevamente.";
                return View();
            }
        }
    }
}

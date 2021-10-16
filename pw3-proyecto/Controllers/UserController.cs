using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _userService.Save(usuario);
                TempData["RegisterOk"] = "¡Registrado correctamente! Ya puedes iniciar sesión.";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.RegisterError = "Ocurrió un error al momento del registro, intente nuevamente.";
                return View(usuario);
            }
        }
    }
}

using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using pw3_proyecto.Services.Interfaces;
using System;

namespace pw3_proyecto.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void Save(Usuario usuario)
        {
            usuario.FechaRegistracion = DateTime.Now;
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            _userRepo.Save(usuario);
            _userRepo.SaveChanges();
        }
    }
}

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

        public Usuario Login(string email, string password)
        {
            Usuario dbUser = _userRepo.GetBy(email);

            if (dbUser != null)
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, dbUser.Password);
                return isValidPassword ? dbUser : null;
            }
            else
            {
                return null;
            }
        }

        public void Save(Usuario user)
        {
            user.FechaRegistracion = DateTime.Now;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _userRepo.Save(user);
            _userRepo.SaveChanges();
        }

        public bool CheckIfUserExists(int id)
        {
            Usuario user = _userRepo.GetBy(id);
            return user != null ? true : false;
        }

        public bool CheckIfUserExists(string email)
        {
            Usuario user = _userRepo.GetBy(email);
            return user != null ? true : false;
        }

        public Usuario GetBy(int id)
        {
            return _userRepo.GetBy(id);
        }
    }
}

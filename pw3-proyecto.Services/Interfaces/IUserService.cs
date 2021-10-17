using pw3_proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Services.Interfaces
{
    public interface IUserService
    {
        public void Save(Usuario user);
        public Usuario Login(string email, string password);
        public bool CheckIfUserExists(int id);
    }
}

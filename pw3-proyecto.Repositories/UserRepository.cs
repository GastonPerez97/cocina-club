using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Repositories
{
    public class UserRepository : IUserRepository
    {
        private _20212C_TPContext _dbContext;

        public UserRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario GetBy(string email)
        {
            return _dbContext.Usuarios.FirstOrDefault(user => user.Email == email);
        }

        public void Save(Usuario user)
        {
            _dbContext.Usuarios.Add(user);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

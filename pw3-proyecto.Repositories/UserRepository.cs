using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System.Linq;

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

        public Usuario GetBy(int id)
        {
            return _dbContext.Usuarios.Find(id);
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

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
        private _20212C_TPContext _ctx;

        public UserRepository(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public void Save(Usuario usuario)
        {
            _ctx.Usuarios.Add(usuario);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}

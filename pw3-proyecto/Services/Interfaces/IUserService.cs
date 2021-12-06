using pw3_proyecto.Entities;

namespace pw3_proyecto.Services.Interfaces
{
    public interface IUserService
    {
        public void Save(Usuario user);
        public Usuario Login(string email, string password);
        public bool CheckIfUserExists(int id);
        public bool CheckIfUserExists(string email);
        public Usuario GetBy(int id);
    }
}

using pw3_proyecto.Entities;

namespace pw3_proyecto.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public void Save(Usuario user);
        public Usuario GetBy(string email);
        public void SaveChanges();
        public Usuario GetBy(int id);
    }
}

using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace pw3_proyecto.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly _20212C_TPContext _dbContext;

        public ReservaRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(Reserva reservation)
        {
            _dbContext.Reservas.Add(reservation);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public List<Reserva> GetAllByUser(int idUser)
        {
            return _dbContext.Reservas.Where(receta => receta.IdComensal == idUser).ToList();
        }
    }
}

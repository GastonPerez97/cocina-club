using pw3_proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        public void Save(Reserva reservation);
        public void SaveChanges();
        
    }
}

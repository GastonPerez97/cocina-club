using pw3_proyecto.Entities;
using pw3_proyecto.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Services.Interfaces
{
    public interface IReservaService
    {
        public void Save(Reserva reservation);
        public ConfirmarReserva details(int idE, int idC);
        public void SaveReserva(ConfirmarReserva confirmarReserva);

        public List<Reserva> GetAllByUser(int idUser);

    }
}

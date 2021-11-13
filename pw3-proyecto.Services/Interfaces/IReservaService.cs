using pw3_proyecto.Entities;
using pw3_proyecto.Entities.Model;
using System.Collections.Generic;

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

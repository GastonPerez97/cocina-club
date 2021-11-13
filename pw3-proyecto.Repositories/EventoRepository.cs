using Microsoft.EntityFrameworkCore;
using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pw3_proyecto.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly _20212C_TPContext _dbContext;

        public EventoRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Evento> GetAllBy(int userId)
        {
            return _dbContext.Eventos.Where(evento => evento.IdCocinero == userId).ToList();
        }

        public void Save(Evento evento)
        {
            _dbContext.Eventos.Add(evento);
        }

        public List<Evento> getAvailableEventsOf(int userId)
        {
            List<Evento> eventAvailable = new List<Evento>();
            int Cantidad = 0;

            var queryDispo = from eventos in _dbContext.Eventos.Include("Reservas")
                             where eventos.Fecha > DateTime.Now && eventos.Estado == EventStates.Pendiente
                             && !eventos.Reservas.Any(reserva => reserva.IdComensal == userId)
                             select eventos;

            foreach (Evento evento in queryDispo)
            {
                foreach (Reserva reserva in evento.Reservas)
                {
                    Cantidad += reserva.CantidadComensales;
                }

                if (Cantidad < evento.CantidadComensales)
                {
                    eventAvailable.Add(evento);
                }
                else
                {
                    Cantidad = 0;
                }
            }

            return eventAvailable;
        }

        public Evento FindById(int id)
        {
            return _dbContext.Eventos.Find(id);
        }

        public Evento FindEventoReserva(int id)
        {
            var query = from e in _dbContext.Eventos.Include("Reservas")
                        where e.IdEvento == id
                        select e;
            return query.Single();
        }

        public List<Evento> GetAllEventosByUser(int idUser)
        {

            var eventos = from e in _dbContext.Eventos
                          join r in _dbContext.Reservas on e.IdEvento equals r.IdEvento
                          where r.IdComensal == idUser
                          select e;

            return eventos.ToList();

        }

        public List<Evento> GetAllEventosByUserCalificacion(int idUser)
        {

            var eventos = from e in _dbContext.Eventos
                          join c in _dbContext.Calificaciones on e.IdEvento equals c.IdEvento
                          where c.IdComensal == idUser
                          select e;

            return eventos.ToList();
        }

        public List<Evento> GetFinishedEvents()
        {
            return _dbContext.Eventos.Where(evento => evento.Estado == EventStates.Finalizado).ToList();
        }


        public void CancelEvent(int eventId)
        {

            Evento evento = (from e in _dbContext.Eventos
                             where e.IdEvento == eventId
                             select e).First();
            evento.Estado = 2;

        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}

using pw3_proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Services.Interfaces
{
    public interface IEventoService
    {
        public void Register(Evento evento);
        public List<Evento> EventAvailable();
    }
}

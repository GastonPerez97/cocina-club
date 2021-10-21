using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pw3_proyecto.Entities;
namespace pw3_proyecto.Repositories.Interfaces
{
    public interface IEventoRepository
    {
        public void Register(Evento evento);
        public List<Evento> EventAvailable();
    }
}

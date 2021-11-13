using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pw3_proyecto.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {


        private readonly IEventoService _eventoService;

        public EventController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {

            _eventoService.CancelEvent(id);

        }

    }
}

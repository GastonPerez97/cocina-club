using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Services.Interfaces;
using pw3_proyecto.Entities;

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

        [HttpPut("{id}/cancel")]
        public void Put(int id, [FromBody] int userId)
        {
            if (_eventoService.EventExists(id))
            {
                if (_eventoService.CheckIfEventBelongsToUser(id, userId))
                {
                    _eventoService.ChangeEventStateTo(EventStates.Cancelado, id);
                    this.HttpContext.Response.StatusCode = 200;
                }
                else
                {
                    this.HttpContext.Response.StatusCode = 401;
                }
            }
            else
            {
                this.HttpContext.Response.StatusCode = 404;
            }
        }
    }
}

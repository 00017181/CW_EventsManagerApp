
using CW_EventsManagerApp.Data;
using CW_EventsManagerApp.Models;
using CW_EventsManagerApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CW_EventsManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsController(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _eventsRepository.GetEvents();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _eventsRepository.GetSingleEvent(id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }
            await _eventsRepository.UpdateEvent(@event);
            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            await _eventsRepository.CreateEvent(@event);

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventsRepository.DeleteEvent(id);
            return NoContent();
        }
    }
}

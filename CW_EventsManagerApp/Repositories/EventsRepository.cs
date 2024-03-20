using CW_EventsManagerApp.Data;
using CW_EventsManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_EventsManagerApp.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly EventDBContext _dbContext;

        public EventsRepository(EventDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<IEnumerable<Event>> GetEvents()
        {
            return await _dbContext.Events.ToListAsync();
        }

        public async Task<Event> GetSingleEvent(int id)
        {
            return await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task CreateEvent(Event Event)
        {
            await _dbContext.AddAsync(Event);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEvent(Event Event)
        {
            _dbContext.Entry(Event).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEvent(int id)
        {
            var Event = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == id );
            if (Event !=null)
            {
                _dbContext.Events.Remove(Event);
                await _dbContext.SaveChangesAsync();

            }
        }

    }
}

using CW_EventsManagerApp.Models;

namespace CW_EventsManagerApp.Repositories
{
    public interface IEventsRepository
    {
        Task<IEnumerable <Event>> GetEvents();
        Task<Event> GetSingleEvent(int id);
        Task CreateEvent(Event Event);
        Task UpdateEvent(Event Event);

        Task DeleteEvent(int id);
    
    }
}
using ESports.Dto;
using ESports.Models;

namespace ESports.Manager
{
    public interface IEventManager
    {
        Task<List<EventViewModel>> AllEvents();
        Task<int?> CreateEvent(EventViewModel Event);
        Task<int?> DeleteEvent(int id);
        Task<EventViewModel> EventMapper(Tournament Event);
    }
}
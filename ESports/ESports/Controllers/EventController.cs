using CommunicationChannel;
using ESports.Dto;
using ESports.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventManager _eventManager;
        public Client client;
        public EventController(IEventManager eventManager) {
            client = new Client("http://localhost:5112");
            _eventManager = eventManager;
        }
        [HttpGet("GetAllEvent")]
        public async Task<List<EventViewModel>> GetAllEvent()
        {
            return await _eventManager.AllEvents();
        }
        [HttpPost("CreateEvent")]
        public async Task<EventViewModel> CraeteEvent(EventViewModel Event)
        {
            var result = await _eventManager.CreateEvent(Event);
            if (result != null)
            {
                return Event;
            }
            return null;
        }
        [HttpDelete("DeleteEvent{id}")]
        public async Task<int?> DeleteEvent(int id)
        {
            var result  = await _eventManager.DeleteEvent(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}

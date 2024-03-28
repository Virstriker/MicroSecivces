using AutoMapper;
using CommunicationChannel;
using ESports.Dto;
using ESports.Models;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;

namespace ESports.Manager
{
    public class EventManager : IEventManager
    {
        private readonly IMapper _mapper;
        private readonly ESportsContext _data;
        private Client _client;
     

        public EventManager(IMapper mapper)
        {
            _mapper = mapper;
            _data = new ESportsContext();
            _client = new Client("http://localhost:5112");
     
        }
        public async Task<EventViewModel> EventMapper(Tournament Event)
        {
            return _mapper.Map<EventViewModel>(Event);

        }
        public async Task<List<EventViewModel>> AllEvents()
        {
            var list = new List<EventViewModel>();
            foreach(var item in _data.Tournaments)
            {
                list.Add(await EventMapper(item));
            }
            return list;
        }
        public async Task<int?> CreateEvent(EventViewModel Event)
        {
            var Check = await _client.GameGETAsync(Event.TournamentGame);
            if (Check != null)
            {
                var result = _mapper.Map<Tournament>(Event);
                _data.Add(result);
                await _data.SaveChangesAsync();
                return 1;
            }
            return null;
        }
        public async Task<int?> DeleteEvent(int id)
        {
            if(_data.Tournaments.Where(s=>s.TournamentId == id).Any()){
                _data.Tournaments.Remove(await _data.Tournaments.FindAsync(id));
                await _data.SaveChangesAsync();
                return 1;
            }
            return null;
        }
    }
}

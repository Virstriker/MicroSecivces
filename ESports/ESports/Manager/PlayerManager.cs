using AutoMapper;
using CommunicationChannel;
using ESports.Dto;
using ESports.Models;

namespace ESports.Manager
{
    public class PlayerManager
    {
        private readonly IMapper _mapper;
        private readonly ESportsContext _data;
        private Client _client;


        public PlayerManager(IMapper mapper)
        {
            _mapper = mapper;
            _data = new ESportsContext();
            _client = new Client("http://localhost:5112");

        }
        public async Task<PlayerViewModel> PlayerMapper(TournamentPlayer player)
        {
            return _mapper.Map<PlayerViewModel>(player);
        }
        public async Task<List<PlayerViewModel>> AllPlayer()
        {
            var list = new List<PlayerViewModel>();
            foreach (var item in _data.TournamentPlayers)
            {
                list.Add(await PlayerMapper(item));

            }
            return list;
        }
        public async Task<int?> AddPlayer(PlayerViewModel player)
        {
            var result = await _client.GamerGET2Async(player.PlayerName);
            var condition1 = (!_data.TournamentPlayers.Where(s => s.PlayerName == player.PlayerName).Any());
            var condition2 = _data.Tournaments.Where(x => x.TournamentId == player.PlayerTournament).Any();
            var condition3 = (result != null);
            var tornament = await _data.Tournaments.FindAsync(player.PlayerTournament);
            var condition4 = (result.GameName == tornament.TournamentGame);
            if ((condition1) && (condition2) && (condition3) && (condition4))
            {
                var obj = _mapper.Map<TournamentPlayer>(player);
                _data.TournamentPlayers.Add(obj);
                await _data.SaveChangesAsync();
                return 1;
            }
            return null;
        }

    }
}

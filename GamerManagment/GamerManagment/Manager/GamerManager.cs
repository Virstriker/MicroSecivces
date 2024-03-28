using GamerManagment.Models;
using GamerManagment.DTO;
using AutoMapper;
using System.Collections.Generic;

namespace GamerManagment.Manager
{
    public class GamerManager : IGamerManager
    {
        private readonly PracticeContext data;
        private readonly IMapper _mapper;
        public GamerManager(IMapper mapper, PracticeContext data)
        {
            this.data = data;
            _mapper = mapper;
        }
        public async Task<int?> AddGamer(GamerViewModel gamer)
        {
            if (data.Games.Where(s => s.GameId == gamer.GameId).Any())
            {
                var data1 = _mapper.Map<Gamer>(gamer);
                data1.Id = null;
                data.Gamers.Add(data1);
                await data.SaveChangesAsync();

                return 0;
            }
            return null;
        }
        public async Task<GamerViewModelWithId> GetViewModel(Gamer data)
        {
            return _mapper.Map<GamerViewModelWithId>(data);
        }
        public async Task<List<GamerViewModelWithId>> GetGamers()
        {
            int coutn = data.Gamers.Count();
            List<GamerViewModelWithId> list = new List<GamerViewModelWithId>();
            foreach (var item in data.Gamers)
            {
                list.Add(await GetViewModel(item));
            }
            return list;
        }
        public async Task<GamerViewModelWithId> GetGamerWithId(int id)
        {
            if (data.Gamers.Where(s => s.Id == id).Any())
            {
                return await GetViewModel(data.Gamers.FirstOrDefault(s => s.Id == id));
            }
            return null;
        }
        public async Task<int?> DeleteGamerWithId(int id)
        {
            if (data.Gamers.Where(s => s.Id == id).Any())
            {
                data.Gamers.Remove(await data.Gamers.FindAsync(id));
                await data.SaveChangesAsync();
                return 1;
            }
            return null;
        }
        public async Task<int?> UpdateGamerWithId(GamerViewModelWithId gamer)
        {
            if (data.Gamers.Where(s => s.Id == gamer.Id).Any())
            {
                var result = _mapper.Map<Gamer>(gamer);
                data.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await data.SaveChangesAsync();
                return 1;

            }
            return null;
        }
        public async Task<IEnumerable<object>> GamerWithGame()
        {
            var query = data.Gamers.Join(data.Games, gamers => gamers.GameId, games => games.GameId, (gamers, games) => new
            {
                gamers.Name,
                games.GameName,
                games.GameType
            });
            //return query;
            var list = query.ToList();
            return list;
        }
        public async Task<JoinViewModel> GamerWithGameByName(string name)
        {
            var query = data.Gamers.Join(data.Games, gamers => gamers.GameId, games => games.GameId, (gamers, games) => new
            {
                gamers.Name,
                games.GameName,
                games.GameType
            });

            var list = query.ToList();
            var res = list.FirstOrDefault(x => x.Name == name);
            JoinViewModel result = new JoinViewModel()
            {
                Name = res.Name,
                GameName = res.GameName,
                GameType = res.GameType
            };
            return result;
        }

    }
}

using AutoMapper;
using GamerManagment.DTO;
using GamerManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace GamerManagment.Manager
{
    public class GameManager : IGameManager
    {
        private readonly IMapper _mapper;
        private readonly PracticeContext data;
        public GameManager(IMapper mapper, PracticeContext data)
        {
            _mapper = mapper;
            this.data = data;
        }
        public async Task<int?> AddGame(GameViewModel game)
        {
            if (!(data.Games.Where(s => s.GameId == game.GameId).Any()))
            {
                var result = _mapper.Map<Game>(game);
                data.Games.AddAsync(result);
                data.SaveChangesAsync();
                return 1;
            }
            return null;
        }
        public async Task<GameViewModel> GetGame(Game game)
        {
            return _mapper.Map<GameViewModel>(game);
        }
        public async Task<List<GameViewModel>> GetGames()
        {
            //int coutn = data.Games.Count();
            List<GameViewModel> list = new List<GameViewModel>();
            foreach (var item in data.Games)
            {
                list.Add(await GetGame(item));
            }
            return list;
        }
        public async Task<GameViewModel> GetGameById(string name)
        {
            if (data.Games.Where(s => s.GameName == name).Any())
            {
                return await GetGame(await data.Games.FirstOrDefaultAsync(s => s.GameName == name));
            }
            return null;
        }
        public async Task<int?> UpdateGame(GameViewModel game)
        {
            if (data.Games.Where(s => s.GameId == game.GameId).Any())
            {
                var result = _mapper.Map<Game>(game);
                data.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                data.SaveChangesAsync();
                return 1;

            }
            return null;
        }
        public async Task<int?> DeleteGame(int id)
        {
            if (data.Games.Where(s => s.GameId == id).Any())
            {
                data.Games.Remove(await data.Games.FindAsync(id));
                data.SaveChangesAsync();
                return 1;
            }
            return null;
        }
        public async Task<GameWithGamerViewModel> GameWithGamerMap(Game game)
        {
            var obj = _mapper.Map<GameWithGamerViewModel>(game);
            List<string> names = new List<string>();
            foreach (var item in data.Gamers)
            {
                if (item.GameId == game.GameId)
                {
                    names.Add(item.Name);
                }
            }
            obj.Gamers = names;
            return obj;
        }
        public async Task<List<GameWithGamerViewModel>> GameWithGamer()
        {
            var result = new List<GameWithGamerViewModel>();
            foreach (var item in data.Games)
            {
                result.Add(await GameWithGamerMap(item));
            }
            return result;
        }
    }
}

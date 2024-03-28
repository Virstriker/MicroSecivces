using GamerManagment.DTO;
using GamerManagment.Models;

namespace GamerManagment.Manager
{
    public interface IGameManager
    {
        Task<int?> AddGame(GameViewModel game);
        Task<int?> DeleteGame(int id);
        Task<List<GameWithGamerViewModel>> GameWithGamer();
        Task<GameWithGamerViewModel> GameWithGamerMap(Game game);
        Task<GameViewModel> GetGame(Game game);
        Task<GameViewModel> GetGameById(string id);
        Task<List<GameViewModel>> GetGames();
        Task<int?> UpdateGame(GameViewModel game);
    }
}
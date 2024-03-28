using GamerManagment.DTO;
using GamerManagment.Models;

namespace GamerManagment.Manager
{
    public interface IGamerManager
    {
        Task<int?> AddGamer(GamerViewModel gamer);
        Task<int?> DeleteGamerWithId(int id);
        Task<IEnumerable<object>> GamerWithGame();
        Task<JoinViewModel> GamerWithGameByName(string name);
        Task<List<GamerViewModelWithId>> GetGamers();
        Task<GamerViewModelWithId> GetGamerWithId(int id);
        Task<GamerViewModelWithId> GetViewModel(Gamer data);
        Task<int?> UpdateGamerWithId(GamerViewModelWithId gamer);
    }
}
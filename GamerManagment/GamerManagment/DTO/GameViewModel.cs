using System.ComponentModel.DataAnnotations;

namespace GamerManagment.DTO
{
    public class GameViewModel
    {
        public int GameId { get; set; }
        public string? GameName { get; set; }
        public string? GameType { get; set; }

    }
}

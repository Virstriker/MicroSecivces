namespace GamerManagment.DTO
{
    public class GameWithGamerViewModel
    {
        public int GameId { get; set; }
        public string? GameName { get; set; }
        public string? GameType { get; set; }
        public List<string> Gamers { get; set; }
    }
}

namespace ESports.Dto
{
    public class PlayerViewModel
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = null!;
        public int PlayerTournament { get; set; }
        public int PlayerTotalMatcher { get; set; }
        public int PlayerWins { get; set; }
    }
}

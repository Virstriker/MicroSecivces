namespace ESports.Dto
{
    public class EventViewModel
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; } = null!;
        public DateTime TournamentDate { get; set; }
        public string TournamentGame { get; set; } = null!;
    }
}

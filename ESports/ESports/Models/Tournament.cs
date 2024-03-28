using System;
using System.Collections.Generic;

namespace ESports.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            TournamentPlayers = new HashSet<TournamentPlayer>();
        }

        public int TournamentId { get; set; }
        public string TournamentName { get; set; } = null!;
        public DateTime TournamentDate { get; set; }
        public string TournamentGame { get; set; } = null!;

        public virtual ICollection<TournamentPlayer> TournamentPlayers { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ESports.Models
{
    public partial class TournamentPlayer
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = null!;
        public int PlayerTournament { get; set; }
        public int PlayerTotalMatcher { get; set; }
        public int PlayerWins { get; set; }

        public virtual Tournament PlayerTournamentNavigation { get; set; } = null!;
    }
}

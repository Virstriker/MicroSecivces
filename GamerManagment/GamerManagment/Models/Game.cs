using System;
using System.Collections.Generic;

namespace GamerManagment.Models
{
    public partial class Game
    {
        public Game()
        {
            Gamers = new HashSet<Gamer>();
        }

        public int GameId { get; set; }
        public string? GameName { get; set; }
        public string? GameType { get; set; }
        public virtual ICollection<Gamer> Gamers { get; set; }
    }
}

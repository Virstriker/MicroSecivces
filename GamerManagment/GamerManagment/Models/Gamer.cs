using System;
using System.Collections.Generic;

namespace GamerManagment.Models
{
    public partial class Gamer
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? GameId { get; set; }

       public virtual Game? Game { get; set; }
    }
}

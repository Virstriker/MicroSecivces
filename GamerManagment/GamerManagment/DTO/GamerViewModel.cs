using System.ComponentModel.DataAnnotations;

namespace GamerManagment.DTO
{
    public class GamerViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Required]
        public int? GameId { get; set; }

    }
}

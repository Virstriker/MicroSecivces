using System.ComponentModel.DataAnnotations;

namespace GamerManagment.DTO
{
    public class GamerViewModelWithId
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Required]
        public int? GameId { get; set; }
    }
}

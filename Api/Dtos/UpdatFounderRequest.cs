using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class UpdateFounderRequest
    {
        public int? Id { get; set; }

        [Required]
        public string Inn { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class CreateFounderRequest
    {
        [Required]
        public string Inn { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;
    }
}
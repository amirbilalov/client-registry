using System.ComponentModel.DataAnnotations;
using BusinessLogic.Models;

namespace Api.Dtos
{
    public class CreateClientRequest
    {
        [Required]
        public string Inn { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [EnumDataType(typeof(ClientType))]
        public ClientType Type { get; set; }

        public List<CreateFounderRequest> Founders { get; set; } = new();
    }
}
using System.ComponentModel.DataAnnotations;
using BusinessLogic.Models;

namespace Api.Dtos
{
    public class UpdateClientRequest
    {
        [Required]
        public string Inn { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [EnumDataType(typeof(ClientType))]
        public ClientType Type { get; set; }

        [Required]
        public List<UpdateFounderRequest>? Founders { get; set; }
    }
}
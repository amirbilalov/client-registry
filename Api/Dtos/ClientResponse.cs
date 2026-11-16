using BusinessLogic.Models;

namespace Api.Dtos
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string Inn { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ClientType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<FounderResponse> Founders { get; set; } = new();
    }
}

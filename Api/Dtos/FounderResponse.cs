namespace Api.Dtos
{
    public class FounderResponse
    {
        public int Id { get; set; }
        public string Inn { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

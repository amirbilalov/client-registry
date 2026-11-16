using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Client
    {
        public int Id { get; private set; }
        public string Inn { get; private set; }
        public string Name { get; private set; }
        public ClientType Type { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public List<Founder> Founders { get; private set; } = new();

        public Client(string inn, string name, ClientType type)
        {
            Inn = inn;
            Name = name;
            Type = type;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;   
        }

        public void UpdateDetails(string inn, string name, ClientType type)
        {
            Inn = inn;
            Name = name;
            Type = type;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

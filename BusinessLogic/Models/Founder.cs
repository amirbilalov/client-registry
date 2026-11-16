using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Founder
    {
        public int Id { get; private set; }
        public string Inn { get; private set; }
        public string FullName { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public int ClientId { get; private set; }

        public Founder(string inn, string fullName)
        {
            Inn = inn;
            FullName = fullName;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }

        public void UpdateDetails(string inn, string fullName)
        {
            if (Inn == inn && FullName == fullName)
            {
                return;
            }

            Inn = inn;
            FullName = fullName;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

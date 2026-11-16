using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class FounderUpdate
    {
        public int? Id { get; set; }
        public string Inn { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}

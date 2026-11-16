using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IClientService
    {
        Task<Client?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Client>> GetAllAsync(CancellationToken cancellationToken);
        Task<Client?> CreateAsync(string inn, string name, ClientType type, List<Founder> founders, CancellationToken cancellationToken);
        Task<Client?> UpdateAsync(int id, string inn, string name, ClientType type, List<FounderUpdate> founders, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

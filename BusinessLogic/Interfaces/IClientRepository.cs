using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IClientRepository
    {
        Task<Client?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Client>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Client client, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task DeleteAsync(Client client, CancellationToken cancellationToken);
    }
}

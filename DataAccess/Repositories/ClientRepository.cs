using BusinessLogic.Models;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientRegistryDbContext _context;

        public ClientRepository(ClientRegistryDbContext context)
        {
            _context = context;
        }

        public Task<Client?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _context.Clients
                .Include(client => client.Founders)
                .FirstOrDefaultAsync(client => client.Id == id, cancellationToken);
        }

        public Task<List<Client>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _context.Clients
                .Include(client => client.Founders)
                .OrderBy(client => client.Id)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Client client, CancellationToken cancellationToken)
        {
            _context.Clients.Add(client);
            await SaveChangesAsync(cancellationToken);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        public Task DeleteAsync(Client client, CancellationToken cancellationToken)
        {
            _context.Clients.Remove(client);
            return SaveChangesAsync(cancellationToken);
        }
    }
}

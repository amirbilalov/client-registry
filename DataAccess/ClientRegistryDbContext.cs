using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClientRegistryDbContext : DbContext
    {
        public ClientRegistryDbContext(DbContextOptions<ClientRegistryDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(client => client.Founders)
                .WithOne()
                .HasForeignKey(founder => founder.ClientId);
        }
    }
}

using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public Task<Client?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _repository.GetByIdAsync(id, cancellationToken);
        }

        public Task<List<Client>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _repository.GetAllAsync(cancellationToken);
        }

        public async Task<Client?> CreateAsync(string inn, string name, ClientType type, List<Founder> founders, CancellationToken cancellationToken)
        {
            if (type == ClientType.IndividualEntrepreneur && founders.Count > 0)
            {
                return null;
            }

            var client = new Client(inn, name, type);
            client.Founders.AddRange(founders);

            await _repository.AddAsync(client, cancellationToken);
            return client;
        }

        public async Task<Client?> UpdateAsync(int id, string inn, string name, ClientType type, List<FounderUpdate> founders, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(id, cancellationToken);

            if (client == null)
                return null;

            if (type == ClientType.IndividualEntrepreneur && founders.Count > 0)
                throw new ValidationException("У ип не может быть учредителей");

            var existingFounders = client.Founders.ToDictionary(founder => founder.Id);
            var founderIdsToKeep = new HashSet<int>();

            foreach(var founder in founders)
            {
                if(founder.Id is int founderId)
                {
                    if (!existingFounders.ContainsKey(founderId))
                        throw new ValidationException($"учредитель с id {founderId} не принадлежит этому клиенту");

                    if (!founderIdsToKeep.Add(founderId))
                        throw new ValidationException($"учредитель с id {founderId} указан дважды");
                }
            }

            client.UpdateDetails(inn, name, type);
            client.Founders.RemoveAll(founder => !founderIdsToKeep.Contains(founder.Id));

            foreach (var founder in founders)
            {
                if (founder.Id is int founderId)
                {
                    existingFounders[founderId].UpdateDetails(founder.Inn, founder.FullName);
                }
                else
                {
                    client.Founders.Add(new Founder(founder.Inn, founder.FullName));
                }
            }

            await _repository.SaveChangesAsync(cancellationToken);
            return client;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(id, cancellationToken);

            if (client == null)
            {
                return false;
            }

            await _repository.DeleteAsync(client, cancellationToken);
            return true;
        }
    }
}

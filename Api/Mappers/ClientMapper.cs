using Api.Dtos;
using BusinessLogic.Models;

namespace Api.Mappers
{
    public static class ClientMapper
    {
        public static ClientResponse ToResponse(Client client)
        {
            var response = new ClientResponse
            {
                Id = client.Id,
                Inn = client.Inn,
                Name = client.Name,
                Type = client.Type,
                CreatedAt = client.CreatedAt,
                UpdatedAt = client.UpdatedAt
            };

            foreach (var founder in client.Founders)
            {
                response.Founders.Add(new FounderResponse
                {
                    Id = founder.Id,
                    Inn = founder.Inn,
                    FullName = founder.FullName,
                    CreatedAt = founder.CreatedAt,
                    UpdatedAt = founder.UpdatedAt
                });
            }

            return response;
        }
    }
}
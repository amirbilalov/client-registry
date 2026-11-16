using Api.Dtos;
using Api.Mappers;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClientResponse>> GetById(int id, CancellationToken cancellationToken)
        {
            var client = await _clientService.GetByIdAsync(id, cancellationToken);

            if (client == null)
                return NotFound();

            return Ok(ClientMapper.ToResponse(client));
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var clients = await _clientService.GetAllAsync(cancellationToken);
            var response = new List<ClientResponse>();

            foreach (var client in clients)
            {
                response.Add(ClientMapper.ToResponse(client));
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ClientResponse>> Create(CreateClientRequest request, CancellationToken cancellationToken)
        {
            var founders = new List<Founder>();

            foreach (var founder in request.Founders)
            {
                if (founder == null)
                {
                    ModelState.AddModelError("founders", "null на учредителе");
                    return ValidationProblem(ModelState);
                }

                founders.Add(new Founder(founder.Inn, founder.FullName));
            }

            var client = await _clientService.CreateAsync(request.Inn, request.Name, request.Type, founders, cancellationToken);

            if (client == null)
            {
                ModelState.AddModelError("founders", "У ип не может быть учредителей");
                return ValidationProblem(ModelState);
            }

            var response = ClientMapper.ToResponse(client);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, response);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ClientResponse>> Update(int id, UpdateClientRequest request, CancellationToken cancellationToken)
        {
            if (request.Founders == null)
            {
                ModelState.AddModelError("founders", "Передайте список учредителей.");
                return ValidationProblem(ModelState);
            }

            var founders = new List<FounderUpdate>();

            foreach (var founder in request.Founders)
            {
                if (founder == null)
                {
                    ModelState.AddModelError("founders", "Укажите данные каждого учредителя.");
                    return ValidationProblem(ModelState);
                }

                founders.Add(new FounderUpdate
                {
                    Id = founder.Id,
                    Inn = founder.Inn,
                    FullName = founder.FullName
                });
            }

            Client? client;
            try
            {
                client = await _clientService.UpdateAsync(
                    id, request.Inn, request.Name, request.Type, founders, cancellationToken);
            }
            catch (ValidationException exception)
            {
                ModelState.AddModelError("founders", exception.Message);
                return ValidationProblem(ModelState);
            }

            if (client == null)
            {
                return NotFound();
            }

            return Ok(ClientMapper.ToResponse(client));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _clientService.DeleteAsync(id, cancellationToken);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}

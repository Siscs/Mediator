using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Siscs.Mediator.Api.Application.Commands;
using Siscs.Mediator.Api.Domain.Entities;
using Siscs.Mediator.Api.Domain.Repositories;

namespace Siscs.Mediator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;

        public PessoaController(IMediator mediator, IRepository<Pessoa> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(AdicionarPessoaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlterarPessoaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = new ExcluirPessoaCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }

    }
}
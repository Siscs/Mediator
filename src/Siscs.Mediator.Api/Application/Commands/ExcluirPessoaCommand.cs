using System;
using MediatR;

namespace Siscs.Mediator.Api.Application.Commands
{
    public class ExcluirPessoaCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
using System;
using MediatR;

namespace Siscs.Mediator.Api.Application.Notifications
{
    public class PessoaExcluidaNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
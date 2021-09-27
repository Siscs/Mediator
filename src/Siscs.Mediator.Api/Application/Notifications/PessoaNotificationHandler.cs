using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Siscs.Mediator.Api.Application.Notifications
{
    public class PessoaNotificationHandler : INotificationHandler<PessoaAdicionadaNotification>,
                                             INotificationHandler<PessoaAlteradaNotification>,
                                             INotificationHandler<PessoaExcluidaNotification>
    {
        private readonly ILogger<PessoaNotificationHandler> _logger;
        public PessoaNotificationHandler(ILogger<PessoaNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(PessoaAdicionadaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                _logger.LogInformation($"PESSOA INCLUIDA: {notification.Id}-{notification.Nome}");
            });
        }

        public Task Handle(PessoaAlteradaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                _logger.LogInformation($"PESSOA ALTERADA: {notification.Id}-{notification.Nome}");
            });
        }

        public Task Handle(PessoaExcluidaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                _logger.LogInformation($"PESSOA EXCLUIDA: {notification.Id}");
            });
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Siscs.Mediator.Api.Application.Notifications;
using Siscs.Mediator.Api.Domain.Entities;
using Siscs.Mediator.Api.Domain.Repositories;

namespace Siscs.Mediator.Api.Application.Commands
{
    public class PessoaCommandHandler : IRequestHandler<AdicionarPessoaCommand, string>,
                                        IRequestHandler<AlterarPessoaCommand, string>,
                                        IRequestHandler<ExcluirPessoaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;

        public PessoaCommandHandler(IMediator mediator, 
                                    IRepository<Pessoa> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(AdicionarPessoaCommand command, CancellationToken cancellationToken)
        {
            //validar commando
            // if (command.Valido())

            var pessoa = new Pessoa(null, command.Nome, command.Idade, command.Sexo);

            // validar regras negocios
            // ex se pessoa já existe

            // persiste no repository

            await _repository.Add(pessoa);

            //gera notificacao
            await _mediator.Publish(new PessoaAdicionadaNotification { Id = pessoa.Id,  Nome = pessoa.Nome} );

            return "Pessoa adicionada com sucesso.";
        }

        public async Task<string> Handle(AlterarPessoaCommand command, CancellationToken cancellationToken)
        {
            //validar commando
            // if (command.Valido())

            var pessoa = new Pessoa(command.Id, command.Nome, command.Idade, command.Sexo);

            // validar regras negocios

            // persiste no repository
            await _repository.Edit(pessoa);

            //gera notificacao
            await _mediator.Publish(new PessoaAlteradaNotification { Id = pessoa.Id,  Nome = pessoa.Nome} );

            return "Pessoa alterarada com sucesso.";
        }

        public async Task<string> Handle(ExcluirPessoaCommand command, CancellationToken cancellationToken)
        {
            //validar commando
            // if (command.Valido())

            // validar regras negocios

            // persiste no repository
            await _repository.Delete(command.Id);

            //gera notificacao
            await _mediator.Publish(new PessoaExcluidaNotification { Id = command.Id} );

            return "Pessoa excluída com sucesso.";
        }
    }
}
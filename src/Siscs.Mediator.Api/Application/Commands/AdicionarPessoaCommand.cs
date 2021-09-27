using MediatR;

namespace Siscs.Mediator.Api.Application.Commands
{
    public class AdicionarPessoaCommand : IRequest<string>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }
}
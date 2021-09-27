using System;
using MediatR;

namespace Siscs.Mediator.Api.Application.Notifications
{
    public class PessoaAlteradaNotification : INotification
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public bool Sucesso { get; set; }
        
    }


}
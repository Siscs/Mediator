using System;

namespace Siscs.Mediator.Api.Domain.Entities
{
    public class Pessoa
    {

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public char Sexo { get; private set; }

        public Pessoa(Guid? id, string nome, int idade, char sexo) 
        {

            if(id is null) id = Guid.NewGuid();

            Id = id.Value;
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
  
        }
        
    }
}
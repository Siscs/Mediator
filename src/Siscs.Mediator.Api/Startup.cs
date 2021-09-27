using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Siscs.Mediator.Api.Application.Commands;
using Siscs.Mediator.Api.Application.Notifications;
using Siscs.Mediator.Api.Domain.Entities;
using Siscs.Mediator.Api.Domain.Repositories;
using Siscs.Mediator.Api.Infra.Repositories;

namespace Siscs.Mediator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMediatR(typeof(Startup));

            services.AddScoped<IRepository<Pessoa>, PessoaRepository>();
            
            // services.AddScoped<IRequestHandler<AdicionarPessoaCommand,string>, PessoaCommandHandler>();
            // services.AddScoped<IRequestHandler<AlterarPessoaCommand,string>, PessoaCommandHandler>();
            // services.AddScoped<IRequestHandler<ExcluirPessoaCommand,string>, PessoaCommandHandler>();

            // services.AddScoped<INotificationHandler<PessoaAdicionadaNotification>, PessoaNotificationHandler>();
            // services.AddScoped<INotificationHandler<PessoaAlteradaNotification>, PessoaNotificationHandler>();
            // services.AddScoped<INotificationHandler<PessoaExcluidaNotification>, PessoaNotificationHandler>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Siscs.Mediator.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Siscs.Mediator.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

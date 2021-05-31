using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SuperInovacoes.Business.Interfaces;
using SuperInovacoes.Business.Notificacoes;
using SuperInovacoes.Business.Services;
using SuperInovacoes.Data.Data;
using SuperInovacoes.Data.Repository;

namespace SuperInovacoes.Api.Configuracao
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}

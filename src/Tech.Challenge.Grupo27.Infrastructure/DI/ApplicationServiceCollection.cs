﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Handler_;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.API.InserirContato.Handler_;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Application.Worker.InserirContato.Dispatchers_;
using Tech.Challenge.Grupo27.Application.Worker.InserirContato.Dispatchers;
using Tech.Challenge.Grupo27.Application.Worker.AtualizarContato.Dispatchers_;
using Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato.Handler_;
using Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato;

namespace Tech.Challenge.Grupo27.Infrastructure.DI
{
    public static class ApplicationServiceCollection
    {
        public static void AddApplication(this IServiceCollection services)
        {       
            services.AddTransient<IRequestHandler<ContatoRequest,ContatoResponse>>(x=> 
            new InserirContatoHandler(x.GetRequiredService<IContatoCriadoProducer>(), x.GetRequiredService<INotificacaoContext>()));

            services.AddTransient<IRequestHandler<AtualizarContatoRequest, ContatoResponse>>(x =>
            new AtualizarContatoHandler(x.GetRequiredService<IContatoAtualizadoProducer>(), x.GetRequiredService<INotificacaoContext>()));
            services.AddTransient<IRequestHandler<ObterPorDddRequest, ContatoResponse>, ObterContatosPorDddHandler>();
            services.AddTransient<IRequestHandler<ObterPorIdRequest, ContatoResponse>, ObterContatoPorIdHandler>();
            services.AddTransient<IInserirContatoDispatcher, InserirContatoDispatcher>();
            services.AddTransient<IAtualizarContatoDispatcher, AtualizarContatoDispatcher>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InserirContatoHandler).Assembly));
        }   
    }
}

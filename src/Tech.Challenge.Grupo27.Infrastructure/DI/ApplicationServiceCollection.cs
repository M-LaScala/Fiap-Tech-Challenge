﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Handler_;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Application.Worker.InserirContato.Dispatchers_;
using Tech.Challenge.Grupo27.Application.Worker.InserirContato.Dispatchers;
using Tech.Challenge.Grupo27.Application.Worker.AtualizarContato.Dispatchers_;
using Tech.Challenge.Grupo27.Application.Worker.DeleteContato.Dispatchers_;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Application.InserirContato;
using Tech.Challenge.Grupo27.Application.DeletarContato;
using Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato.Handler_;
using Tech.Challenge.Grupo27.Application.AtualizarContato;

namespace Tech.Challenge.Grupo27.Infrastructure.DI
{
    public static class ApplicationServiceCollection
    {
        public static void AddApplication(this IServiceCollection services)
        {       
            services.AddTransient<IRequestHandler<Application.InserirContato.ViewModels.ContatoRequest, Application.InserirContato.ViewModels.ContatoResponse>>(x=> 
            new InserirContatoHandler(x.GetRequiredService<IContatoCriadoProducer>(), x.GetRequiredService<INotificacaoContext>()));

            services.AddTransient<IRequestHandler<AtualizarContatoRequest, Application.AtualizarContato.ContatoResponse>>(x =>
            new AtualizarContatoHandler(x.GetRequiredService<IContatoAtualizadoProducer>(), x.GetRequiredService<INotificacaoContext>()));

            services.AddTransient<IRequestHandler<DeleteContatoRequest, Application.DeletarContato.ContatoResponse>>(x =>
            new DeleteContatoHandler(x.GetRequiredService<IContatoService>(),x.GetRequiredService<IContatoDeletadoProducer>()));


            services.AddTransient<IRequestHandler<ObterPorDddRequest, Application.Contatos.ViewModels.ContatoResponse>, ObterContatosPorDddHandler>();
            services.AddTransient<IRequestHandler<ObterPorIdRequest, Application.Contatos.ViewModels.ContatoResponse>, ObterContatoPorIdHandler>();
            services.AddTransient<IInserirContatoDispatcher, InserirContatoDispatcher>();
            services.AddTransient<IAtualizarContatoDispatcher, AtualizarContatoDispatcher>();
            services.AddTransient<IDeletarContatoDispatcher, DeletarContatoDispatcher>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InserirContatoHandler).Assembly));
        }   
    }
}

﻿using MediatR;

namespace Tech.Challenge.Grupo27.Application.InserirContato.Shared
{
    public interface IHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}

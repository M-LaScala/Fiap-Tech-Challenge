﻿using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker
{
    public interface IContatoDeletadoProducer
    {
        Task DeleteContato(ContatoDeletadoCommand mensagem);
    }
}

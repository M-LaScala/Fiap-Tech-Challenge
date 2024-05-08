

using FluentValidation.Results;

namespace Tech.Challenge.Grupo27.Domain.Shared.Notificacoes
{
    public class NotificacaoContext : INotificacaoContext
    {
        private readonly List<Notificacao> _notificacoes;
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;
        public bool ExisteNotificacoes => _notificacoes.Any();

        IReadOnlyCollection<Notificacao> INotificacaoContext.Notificacoes { get => _notificacoes; }
        bool INotificacaoContext.ExisteNotificacoes { get => _notificacoes.Any(); }

        public NotificacaoContext()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void AddNotificacao(string codigo, string message)
        {
            _notificacoes.Add(new Notificacao(message, codigo));
        }

        public void AddNotificacao(Notificacao notification)
        {
            _notificacoes.Add(notification);
        }

        public void AddNotificacoes(IReadOnlyCollection<Notificacao> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void AddNotificacoes(IList<Notificacao> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void AddNotificacoes(ICollection<Notificacao> notifications)
        {
            _notificacoes.AddRange(notifications);
        }

        public void AddNotificacoes(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotificacao(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}

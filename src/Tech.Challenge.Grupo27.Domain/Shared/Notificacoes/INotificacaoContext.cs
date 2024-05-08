using FluentValidation.Results;

namespace Tech.Challenge.Grupo27.Domain.Shared.Notificacoes
{
    public interface INotificacaoContext
    {

        public IReadOnlyCollection<Notificacao> Notificacoes { get; }
        public bool ExisteNotificacoes { get; }
        void AddNotificacao(string codigo, string message);

        void AddNotificacao(Notificacao notification);

        void AddNotificacoes(IReadOnlyCollection<Notificacao> notifications);

        void AddNotificacoes(IList<Notificacao> notifications);

        void AddNotificacoes(ICollection<Notificacao> notifications);

        void AddNotificacoes(ValidationResult validationResult);
    }
}

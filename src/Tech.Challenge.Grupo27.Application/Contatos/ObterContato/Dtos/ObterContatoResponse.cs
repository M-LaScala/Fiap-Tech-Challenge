namespace Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos
{
    public class ObterContatoResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public TelefoneResponse? Telefone { get; set; }

        public ObterContatoResponse(Guid id, string? nome, string? email, TelefoneResponse? telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Id = id;
        }
    }

    public class TelefoneResponse
    {
        public string? Numero { get; init; }

        public string? Ddd { get; init; }

        public string? Estado { get; init; }

        public string? Regiao { get; init; }

        public TelefoneResponse(string? numero, string? ddd, string? estado, string? regiao)
        {
            Numero = numero;
            Ddd = ddd;
            Estado = estado;
            Regiao = regiao;
        }
    }
}

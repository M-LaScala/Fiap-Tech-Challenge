namespace Tech.Challenge.Grupo27.Application.DeletarContato
{
    public class DeleteContatoResponse
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public TelefoneResponse? Telefone { get; set; }

        public DeleteContatoResponse(Guid? id, string? nome, string? email, TelefoneResponse? telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Id = id;
        }
    }
}

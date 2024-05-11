using System.Text.RegularExpressions;

namespace Tech.Challenge.Grupo27.Domain.Shared.ValueObject
{
    public class Telefone
    {
        public string? Ddd { get; private set; }

        public string? Numero { get; private set; }

        public string? Regiao { get; private set; }

        public string? Estado { get; private set; }

        public Telefone(string? dDD, string? numero)
        {
            Ddd = dDD;
            Numero = numero; 
        }

        public bool ValidarNumero(string numero)
        {
            if(string.IsNullOrWhiteSpace(numero)) return false;

            var expressao = @"^[9]{0,1}[6-9]{1}[0-9]{3}[0-9]{4}$";

            return Regex.Match(numero, expressao).Success;
        }

        public bool ValidarDdd(string ddd)
        {
            if (string.IsNullOrWhiteSpace(ddd)) return false;

            var expressao = @"^[1-9]{2}";
            return Regex.Match(ddd, expressao).Success;
        }

        public void AdicionarRegiaoDoDdd(string regiao, string estado)
        {
            Estado = estado;
            Regiao = regiao;
        }
    }
}

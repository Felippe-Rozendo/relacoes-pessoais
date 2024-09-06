namespace relacoes_pessoais_api.Dominio.Entidades
{
    public class Pessoa
    {
        public int CodPessoa { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataModificacao { get; set; }
        public ICollection<Contato> Contatos { get; set; }
    }
}

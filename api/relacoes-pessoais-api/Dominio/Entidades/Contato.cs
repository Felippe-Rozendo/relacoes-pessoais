namespace relacoes_pessoais_api.Dominio.Entidades
{
    public class Contato
    {
        public int CodContato { get; set; }
        public int TipoContato { get; set; }// Telefone, Email, Whatsapp
        public string ValorContato { get; set; } = string.Empty;
        public int CodPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}

namespace relacoes_pessoais_api.Aplicacao.DTO
{
    public class ContatoDto
    {
        public int CodContato { get; set; }
        public int TipoContato { get; set; }
        public string TipoContatoDsc { get; set; } = string.Empty;
        public string ValorContato { get; set; } = string.Empty;
        public int CodPessoa { get; set; }
    }
}

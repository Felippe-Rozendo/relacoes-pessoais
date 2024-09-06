using Microsoft.AspNetCore.Mvc;
using relacoes_pessoais_api.Aplicacao.DTO;
using relacoes_pessoais_api.Dominio.Entidades;

namespace relacoes_pessoais_api.Dominio.IRepositories
{
    public interface IPessoaRepository
    {
        public Task<PessoaDto?> ObterPessoaAsync(int codPessoa);
        public Task<IList<PessoaDto>> ObterListaAsync();
        public Task<Pessoa> AdicionarPessoaAsync(PessoaDto model);
        public Task<Pessoa> EditarPessoaAsync(PessoaDto model);
        public Task<(bool excluido, string? mensagem)> RemoverPessoaAsync(int codPessoa);
    }
}

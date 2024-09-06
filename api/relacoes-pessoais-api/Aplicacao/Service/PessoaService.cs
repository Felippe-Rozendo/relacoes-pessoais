using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using relacoes_pessoais_api.Aplicacao.DTO;
using relacoes_pessoais_api.Dominio.Entidades;
using relacoes_pessoais_api.Dominio.IRepositories;
using relacoes_pessoais_api.Infraestrutura.Repositories;

namespace relacoes_pessoais_api.Aplicacao.Service
{
    public class PessoaService
    {
        private readonly PessoaRepository _pessoaRepository;

        public PessoaService(PessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<PessoaDto?> ObterPessoaAsync(int codPessoa)
        {
            try
            {
                return await _pessoaRepository.ObterPessoaAsync(codPessoa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<PessoaDto>> ObterListaAsync()
        {
            try
            {
                return await _pessoaRepository.ObterListaAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa> AdicionarPessoaAsync(PessoaDto dto)
        {
            try
            {
                return await _pessoaRepository.AdicionarPessoaAsync(dto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa> EditarPessoaAsync(PessoaDto dto)
        {
            try
            {
                return await _pessoaRepository.EditarPessoaAsync(dto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(bool excluido, string? mensagem)> ExcluirPessoaAsync(int codPessoa)
        {
            try
            {
                return await _pessoaRepository.RemoverPessoaAsync(codPessoa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

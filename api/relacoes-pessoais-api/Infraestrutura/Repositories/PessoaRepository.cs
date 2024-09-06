using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relacoes_pessoais_api.Aplicacao.DTO;
using relacoes_pessoais_api.Dominio.Entidades;
using relacoes_pessoais_api.Dominio.Enums;
using relacoes_pessoais_api.Dominio.Extensions;
using relacoes_pessoais_api.Dominio.IRepositories;
using relacoes_pessoais_api.Infraestrutura.Context;
using System.Threading.Tasks;

namespace relacoes_pessoais_api.Infraestrutura.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly RelacoesPessoaisDB _db;

        public PessoaRepository(RelacoesPessoaisDB db)
        {
            _db = db;
        }

        public async Task<IList<PessoaDto>> ObterListaAsync()
        {
            var result = await (from pessoa in _db.Pessoas
                                join contato in _db.Contatos
                                on pessoa.CodPessoa equals contato.CodPessoa into pessoaContatos
                                select new PessoaDto
                                {
                                    CodPessoa = pessoa.CodPessoa,
                                    Nome = pessoa.Nome,
                                    DataModificacao = pessoa.DataModificacao,
                                    Contatos = pessoaContatos.Select(c => new ContatoDto
                                    {
                                        CodPessoa = c.CodPessoa,
                                        CodContato = c.CodContato,
                                        TipoContato = c.TipoContato,
                                        TipoContatoDsc = EnumExtensions.GetDescription<TipoContatoEnum>(c.TipoContato),
                                        ValorContato = c.ValorContato
                                    }).ToList()
                                }).ToListAsync();
            return result;
        }


        public async Task<PessoaDto?> ObterPessoaAsync(int codPessoa)
        {
            return await _db.Pessoas
                .AsNoTracking()
                .Where(p => p.CodPessoa == codPessoa)
                .Select(p => new PessoaDto
                {
                    CodPessoa = p.CodPessoa,
                    Nome = p.Nome,
                    DataModificacao = p.DataModificacao,
                    Contatos = _db.Contatos
                        .Where(c => c.CodPessoa == p.CodPessoa)
                        .Select(c => new ContatoDto
                        {
                            CodContato = c.CodContato,
                            TipoContato = c.TipoContato,
                            TipoContatoDsc = EnumExtensions.GetDescription<TipoContatoEnum>(c.TipoContato),
                            ValorContato = c.ValorContato
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }


        public async Task<Pessoa> AdicionarPessoaAsync(PessoaDto model)
        {
            var pessoa = new Pessoa();

            pessoa.Nome = model.Nome;
            pessoa.DataModificacao = DateTime.Now;

            await _db.Pessoas.AddAsync(pessoa);
            await _db.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> EditarPessoaAsync(PessoaDto model)
        {
            var pessoa = await _db.Pessoas.FirstAsync(x => x.CodPessoa == model.CodPessoa);

            if (pessoa == null)
                throw new Exception("Pessoa não encontrada.");

            pessoa.Nome = model.Nome;
            pessoa.DataModificacao = DateTime.Now;

            _db.Pessoas.Update(pessoa);
            await _db.SaveChangesAsync();
            return pessoa;
        }

        public async Task<(bool excluido, string? mensagem)> RemoverPessoaAsync(int codPessoa)
        {
            try
            {
                var pessoa = await _db.Pessoas.FirstAsync(x => x.CodPessoa == codPessoa);

                if (pessoa == null)
                    return (false, "Pessoa não encontrada.");

                _db.Pessoas.Remove(pessoa);
                await _db.SaveChangesAsync();
                return (true, "Pessoa excluída com sucesso.");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }

        }
    }
}

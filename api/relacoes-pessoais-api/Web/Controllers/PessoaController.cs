using Microsoft.AspNetCore.Mvc;
using relacoes_pessoais_api.Aplicacao.DTO;
using relacoes_pessoais_api.Aplicacao.Service;

namespace relacoes_pessoais_api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        [HttpGet("obter-pessoa")]
        public async Task<ActionResult> ObterPessoaAsync([FromServices] PessoaService service, [FromQuery] int codPessoa)
        {
            try
            {
                var pessoa = await service.ObterPessoaAsync(codPessoa);

                if(pessoa is null)
                    return BadRequest("Pessoa não encontrada");

                return Ok(pessoa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("obter-lista-pessoas")]
        public async Task<ActionResult> ObterDadosSrt([FromServices] PessoaService service)
        {
            try
            {
                return Ok(await service.ObterListaAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("incluir-pessoa")]
        public async Task<ActionResult> IncluirPessoaAsync([FromServices] PessoaService service, [FromBody] PessoaDto model)
        {
            try
            {
                var response = await service.AdicionarPessoaAsync(model);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("editar-pessoa")]
        public async Task<ActionResult> EditarPessoaAsync([FromServices] PessoaService service, [FromBody] PessoaDto model)
        {
            try
            {
                var response = await service.EditarPessoaAsync(model);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("excluir-pessoa")]
        public async Task<ActionResult> ExcluirPessoaAsync([FromServices] PessoaService service, [FromQuery] int codPessoa)
        {
            try
            {
                var (excluido, mensagem) = await service.ExcluirPessoaAsync(codPessoa);

                if (!excluido)
                    return BadRequest(mensagem);

                return Ok(mensagem);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

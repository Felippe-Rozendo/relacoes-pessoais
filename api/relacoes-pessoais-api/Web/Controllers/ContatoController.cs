﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using relacoes_pessoais_api.Aplicacao.DTO;
using relacoes_pessoais_api.Aplicacao.Service;

namespace relacoes_pessoais_api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {

        [HttpPost("incluir-contato")]
        public async Task<ActionResult> IncluirContatoAsync([FromServices] ContatoService service, [FromBody] IList<ContatoDto> model)
        {
            try
            {
                var response = await service.AdicionarContatoAsync(model);

                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("editar-contato")]
        public async Task<ActionResult> EditarContatoAsync([FromServices] ContatoService service, [FromBody] IList<ContatoDto> model)
        {
            try
            {
                var response = await service.EditarContatoAsync(model);

                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("excluir-contato")]
        public async Task<ActionResult> ExcluirRegistroContatoAsync([FromServices] ContatoService service, [FromQuery] int codContato)
        {
            try
            {
                var (excluido, mensagem) = await service.ExcluirContatoAsync(codContato);

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

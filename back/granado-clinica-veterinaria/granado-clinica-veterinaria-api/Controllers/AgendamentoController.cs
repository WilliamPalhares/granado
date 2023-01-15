using granado_clinica_veterinaria_business.Services;
using granado_clinica_veterinaria_business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace granado_clinica_veterinaria_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        protected readonly AgendamentoService agendamentoService;

        public AgendamentoController(AgendamentoService agendamentoService)
        {
            this.agendamentoService = agendamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoViewModel>>> Get()
        {
            try
            {
                return Ok(await this.agendamentoService.GetListAtendimentoAsync());
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoViewModel>> Get(Int64 Id)
        {
            try
            {
                return Ok(await this.agendamentoService.GetAtendimentoAsync(Id));
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AgendamentoViewModel viewModel)
        {
            try
            {
                await this.agendamentoService.InsertAsync(viewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AgendamentoViewModel viewModel)
        {
            try
            {
                viewModel.Id = id;
                await this.agendamentoService.UpdateAsync(viewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await this.agendamentoService.RemocaAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(
                    new
                    {
                        Mensagem = ex.Message,
                        Erro = true
                    });
            }
        }
    }
}

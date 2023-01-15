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
    public class VeterinarioController : ControllerBase
    {
        protected readonly VeterinarioService veterinarioService;

        public VeterinarioController(VeterinarioService veterinarioService)
        {
            this.veterinarioService = veterinarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeterinarioViewModel>>> Get()
        {
            try
            {
                return Ok(await this.veterinarioService.GetListVeterinarioAsync());
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
        public async Task<ActionResult<VeterinarioViewModel>> Get(Int64 Id)
        {
            try
            {
                return Ok(await this.veterinarioService.GetVeterinarioAsync(Id));
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
        public async Task<ActionResult> Post([FromBody] VeterinarioViewModel viewModel)
        {
            try
            {
                await this.veterinarioService.InsertAsync(viewModel);
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
        public async Task<ActionResult> Put(int id, [FromBody] VeterinarioViewModel viewModel)
        {
            try
            {
                viewModel.Id = id;
                await this.veterinarioService.UpdateAsync(viewModel);
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
                await this.veterinarioService.RemocaAsync(id);
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

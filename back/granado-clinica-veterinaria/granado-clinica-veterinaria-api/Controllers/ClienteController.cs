using granado_clinica_veterinaria_business.Services;
using granado_clinica_veterinaria_business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace granado_clinica_veterinaria_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly ClienteService clienteService;

        public ClienteController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> Get()
        {
            try
            {
                return Ok(await this.clienteService.GetListClienteAsync());
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
        public async Task<ActionResult<ClienteViewModel>> Get(Int64 Id)
        {
            try
            {
                return Ok(await this.clienteService.GetClienteAsync(Id));
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
        public async Task<ActionResult> Post([FromBody] ClienteViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await this.clienteService.InsertAsync(viewModel);
                    return Ok();
                }
                else
                {
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    throw new Exception(allErrors.ToArray().ToString());
                }
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
        public async Task<ActionResult> Put(int id, [FromBody] ClienteViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.Id = id;
                    await this.clienteService.UpdateAsync(viewModel);
                    return Ok();
                }
                else
                {
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    throw new Exception(allErrors.ToArray().ToString());
                }
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
                await this.clienteService.RemocaAsync(id);
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

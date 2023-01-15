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
    public class AnimalController : ControllerBase
    {
        protected readonly AnimalService animalService;

        public AnimalController(AnimalService animalService)
        {
            this.animalService = animalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalViewModel>>> Get()
        {
            try
            {
                return Ok(await this.animalService.GetListAnimalAsync());
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
        public async Task<ActionResult<AnimalViewModel>> Get(Int64 Id)
        {
            try
            {
                return Ok(await this.animalService.GetAnimalAsync(Id));
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
        public async Task<ActionResult> Post([FromBody] AnimalViewModel viewModel)
        {
            try
            {
                await this.animalService.InsertAsync(viewModel);
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
        public async Task<ActionResult> Put(int id, [FromBody] AnimalViewModel viewModel)
        {
            try
            {
                viewModel.Id = id;
                await this.animalService.UpdateAsync(viewModel);
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
                await this.animalService.RemocaAsync(id);
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

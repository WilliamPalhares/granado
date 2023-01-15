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
    public class TipoAnimalController : ControllerBase
    {
        protected readonly TipoAnimalService tipoAnimalService;

        public TipoAnimalController(TipoAnimalService tipoAnimalService)
        {
            this.tipoAnimalService = tipoAnimalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAnimalViewModel>>> Get()
        {
            try
            {
                return Ok(await this.tipoAnimalService.GetListTipoAsync());
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
        public async Task<ActionResult<TipoAnimalViewModel>> Get(Int64 Id)
        {
            try
            {
                return Ok(await this.tipoAnimalService.GetTipoAsync(Id));
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

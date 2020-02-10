using LimpseApi.Data;
using LimpseApi.Models;
using LimpseApi.Models.Ser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosKitController
    {
        private readonly ServiciosKitRepository _repository;

        public ServiciosKitController(ServiciosKitRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<List<SERVICIOS_KIT>>> Get()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new ResultadoSP() 
                {
                    Result = 0, 
                    ErrorMessage= ex.Message, 
                    FriendlyMessage="Error al obtener la información"                   
                });
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SERVICIOS_KIT>>> Get(int id)
        {
            try
            {
                return await _repository.GetById(id);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Error al obtener la información"
                });
            }
        }

        [HttpPost]
        public async Task<ResultadoSP> Post([FromBody] SERVICIOS_KIT servicioKit)
        {
            try
            {
                return await _repository.Abc(1, "diegoniux", servicioKit);
            }
            catch (Exception ex)
            {
                return new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Ups. Ocirrió un error interno."
                };
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ResultadoSP> Delete(int id)
        {
            try
            {
                return await _repository.Abc(2, "diegoniux", new SERVICIOS_KIT() { IdServicioKit = id });
            }
            catch (Exception ex)
            {
                return new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Ups. Ocirrió un error interno."
                };
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ResultadoSP> Put(int id, [FromBody] SERVICIOS_KIT servicioKit)
        {
            try
            {
                return await _repository.Abc(3, "diegoniux", servicioKit);
            }
            catch (Exception ex)
            {
                return new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Ups. Ocirrió un error interno."
                };
            }
            
        }
    }
}

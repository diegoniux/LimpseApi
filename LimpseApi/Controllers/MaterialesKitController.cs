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
    public class MaterialesKitController
    {
        private readonly MaterialesKitRepository _repository;

        public MaterialesKitController(MaterialesKitRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<List<MATERIALES_KIT>>> Get()
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
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Error al obtener la información"
                });
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MATERIALES_KIT>>> Get(int id)
        {
            try
            {
                return await _repository.GetByIdKit(id);
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
        public async Task<ResultadoSP> Post([FromBody] MATERIALES_KIT materialKit)
        {
            try
            {
                return await _repository.Abc(1, "diegoniux", materialKit);
            }
            catch (Exception ex)
            {
                return new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Error al obtener la información"
                };
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ResultadoSP> Delete(int id)
        {
            try
            {
                return await _repository.Abc(2, "diegoniux", new MATERIALES_KIT() { IdMaterialKit = id });
            }
            catch (Exception ex)
            {
                return new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Error al obtener la información"
                };
            }
           
        }

        [HttpPut("{id}")]
        public async Task<ResultadoSP> Put(int id, [FromBody] MATERIALES_KIT materialKit)
        {
            try
            {
                return await _repository.Abc(3, "diegoniux", materialKit);
            }
            catch (Exception ex)
            {
                return new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Error al obtener la información"
                };
            }
            
        }
    }
}

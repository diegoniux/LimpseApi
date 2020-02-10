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
    public class MaterialesController
    {
        private readonly MaterialesRepository _repository;

        public MaterialesController(MaterialesRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<List<MATERIALES>>> Get()
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
        public async Task<ActionResult<MATERIALES>> Get(int id)
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
        public async Task<ResultadoSP> Post([FromBody] MATERIALES material)
        {
            try
            {
                return await _repository.Abc(1, "diegoniux", material);
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
                return await _repository.Abc(2, "diegoniux", new MATERIALES() { IdMaterial = id, Material = "" });
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
        public async Task<ResultadoSP> Put(int id, [FromBody] MATERIALES material)
        {
            try
            {
                return await _repository.Abc(3, "diegoniux", material);
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

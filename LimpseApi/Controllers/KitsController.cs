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
    public class KitsController
    {
        private readonly KitsRepository _repository;

        public KitsController(KitsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<List<KITS_SERVICIO>>> Get()
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
        public async Task<ActionResult<KITS_SERVICIO>> Get(int id)
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
        public async Task<ResultadoSP> Post([FromBody] KITS_SERVICIO kit)
        {
            try
            {
                return await _repository.Abc(1, "diegoniux", kit);
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
                return await _repository.Abc(2, "diegoniux", new KITS_SERVICIO() { IdKitServicio = id, KitServicio = "" });
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
        public async Task<ResultadoSP> Put(int id, [FromBody] KITS_SERVICIO kit)
        {
            try
            {
                return await _repository.Abc(3, "diegoniux", kit);
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

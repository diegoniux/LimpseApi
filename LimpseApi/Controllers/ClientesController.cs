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
    public class ClientesController
    {
        private readonly ClientesRepository _repository;

        public ClientesController(ClientesRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<List<CLIENTES>>> Get()
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
        public async Task<ActionResult<CLIENTES>> Get(int id)
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
        public async Task<ResultadoSP> Post([FromBody] CLIENTES cliente)
        {
            try
            {
                return await _repository.Abc(1, "diegoniux", cliente);
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
                return await _repository.Abc(2, "diegoniux", new CLIENTES() { 
                    IdCliente = id,
                    Nombres = "",
                    ApellidoPaterno = "",
                    ApellidoMaterno = "",
                    RFC = "",
                    RazonSocial = "",
                    Email = ""
                });
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
        public async Task<ResultadoSP> Put(int id, [FromBody] CLIENTES cliente)
        {
            try
            {
                return await _repository.Abc(3, "diegoniux", cliente);
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

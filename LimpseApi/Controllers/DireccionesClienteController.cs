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
    public class DireccionesClienteController
    {
        private readonly DireccionesClienteRepository _repository;

        public DireccionesClienteController(DireccionesClienteRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DIRECCIONES_CLIENTES>>> Get(int id)
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
        public async Task<ResultadoSP> Post([FromBody] DIRECCIONES_CLIENTES direccionCliente)
        {
            try
            {
                return await _repository.Abc(1, "diegoniux", direccionCliente);
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
                return await _repository.Abc(2, "diegoniux", new DIRECCIONES_CLIENTES()
                {
                    IdDireccionCliente = id,
                    Calle = "",
                    NoExt = "",
                    NoInt = "",
                    Ciudad = "",
                    Colonia = "",
                    Estado = "",
                    CP = ""
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
        public async Task<ResultadoSP> Put(int id, [FromBody] DIRECCIONES_CLIENTES direccionCliente)
        {
            try
            {
                return await _repository.Abc(3, "diegoniux", direccionCliente);
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

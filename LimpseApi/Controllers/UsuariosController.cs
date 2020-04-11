using LimpseApi.Data;
using LimpseApi.Models;
using LimpseApi.Models.Sis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController: ControllerBase
    {
        private readonly UsuariosRepository _repository;

        public UsuariosController(UsuariosRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<List<USUARIOS>>> Get()
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
        public async Task<ActionResult<USUARIOS>> Get(int id)
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
        public async Task<ResultadoSP> Post([FromBody] USUARIOS usuario)
        {
            try
            {
                return await _repository.Abc(1, "diegoniux", usuario);
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
                return await _repository.Abc(2, "diegoniux", new USUARIOS() { IdUsuario = id, Usuario = "", Password = "" });
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
        public async Task<ResultadoSP> Put(int id, [FromBody] USUARIOS usuario)
        {
            try
            {
                return await _repository.Abc(3, "diegoniux", usuario);
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

        [HttpPut("/ResetPass/{id}")]
        public async Task<ResultadoSP> Put(int id)
        {
            try
            {
                return await _repository.ResetPass("diegoniux", id);
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

        [HttpPut("/CambioPass/{id}")]
        public async Task<ResultadoSP> CambioPass(int id, [FromBody] USUARIOS usuario)
        {
            try
            {

                return await _repository.CambioPass("diegoniux", usuario);
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

        [HttpPut("/BloquearUsuario")]
        public async Task<ResultadoSP> Lock([FromBody] int IdUsuario)
        {
            try
            {

                return await _repository.Lock("diegoniux", IdUsuario);
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

        [HttpPut("/DesbloquearUsuario")]
        public async Task<ResultadoSP> Unlock([FromBody] int IdUsuario)
        {
            try
            {

                return await _repository.Unlock("diegoniux", IdUsuario);
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

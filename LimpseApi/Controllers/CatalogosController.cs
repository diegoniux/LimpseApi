using LimpseApi.Data;
using LimpseApi.Models;
using LimpseApi.Models.Ser;
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
    public class CatalogosController
    {
        private readonly CatalogosRepository _repository;

        public CatalogosController(CatalogosRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("EstatusOrdenesServicio")]
        public async Task<ActionResult<List<ESTATUS_ORDENES_SERVICIO>>> GetEstatusOrdenesServicio()
        {
            try
            {
                return await _repository.GetEstatusOrdenesServicio();
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

        [HttpGet("EtapasOrdenesServicio")]
        public async Task<ActionResult<List<ETAPAS_ORDENES_SERVICIO>>> GetEtapasOrdenesServicio()
        {
            try
            {
                return await _repository.GetEtapasOrdenesServicio();
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

        [HttpGet("TiposDocumento")]
        public async Task<ActionResult<List<TIPOS_DOCUMENTO>>> GetTiposDocumento()
        {
            try
            {
                return await _repository.GetTiposDocumento();
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

        [HttpGet("TiposMaterial")]
        public async Task<ActionResult<List<TIPOS_MATERIALES>>> GetTiposMaterial()
        {
            try
            {
                return await _repository.GetTiposMaterial();
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

        [HttpGet("TiposServicio")]
        public async Task<ActionResult<List<TIPOS_SERVICIOS>>> GetTiposServicio()
        {
            try
            {
                return await _repository.GetTiposServicio();
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

        [HttpGet("TiposTelefono")]
        public async Task<ActionResult<List<TIPOS_TELEFONO>>> GetTiposTelefono()
        {
            try
            {
                return await _repository.GetTiposTelefono();
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

        [HttpGet("Perfiles")]
        public async Task<ActionResult<List<PERFILES>>> GetPerfiles()
        {
            try
            {
                return await _repository.GetPerfiles();
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

        [HttpGet("EstatusUsuario")]
        public async Task<ActionResult<List<ESTATUS_USUARIO>>> GetEstatusUSuario()
        {
            try
            {
                return await _repository.GetEstatusUsuario();
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



    }
}

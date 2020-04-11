using LimpseApi.Models;
using LimpseApi.Models.Ser;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Data
{
    public class TelefonosClienteRepository
    {

        private readonly string _connectionString;

        public TelefonosClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        private TELEFONOS_CLIENTES MapToValue(SqlDataReader reader)
        {
            return new TELEFONOS_CLIENTES()
            {
                IdTelefonoCliente = (int)reader["IdTelefonoCliente"],
                IdCliente = (int)reader["IdCliente"],
                IdTipoTelefono = (int)reader["IdTipoTelefono"],
                Telefono = reader["Telefono"].ToString()
            };
        }

        public async Task<List<TELEFONOS_CLIENTES>> GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarTelefonosCliente", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@p_IdCliente", id);
                        var response = new List<TELEFONOS_CLIENTES>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToValue(reader));
                            }
                        }
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultadoSP> Abc(int accion, string usuario, TELEFONOS_CLIENTES telefonoCliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.Abc_TelefonosClientes", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_Accion", accion);
                        sqlCmd.Parameters.AddWithValue("@p_IdTelefonoCliente", telefonoCliente.IdTelefonoCliente);
                        sqlCmd.Parameters.AddWithValue("@p_IdCliente", telefonoCliente.IdCliente);
                        sqlCmd.Parameters.AddWithValue("@p_IdTipoTelefono", telefonoCliente.IdTipoTelefono);
                        sqlCmd.Parameters.AddWithValue("@p_Telefono", telefonoCliente.Telefono);
                        sqlCmd.Parameters.AddWithValue("@p_Usuario", usuario);

                        await sqlConn.OpenAsync();

                        var response = new ResultadoSP();
                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            await reader.ReadAsync();
                            response = new ResultadoSP();
                            response.Result = (int)reader["Result"];
                            //Si la ejecución es exitosa
                            if (response.Result == 1)
                            {
                                response.Id = (int)reader["Id"];
                            }
                            else
                            {
                                response.ErrorMessage = reader["ErrorMessage"].ToString();
                                response.FriendlyMessage = reader["FriendlyMessage"].ToString();
                            }
                        }

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Ocurrió un error interno."
                };
            }
        }

    }
}

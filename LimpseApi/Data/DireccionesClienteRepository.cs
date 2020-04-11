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
    public class DireccionesClienteRepository
    {
        private readonly string _connectionString;

        public DireccionesClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        private DIRECCIONES_CLIENTES MapToValue(SqlDataReader reader)
        {
            return new DIRECCIONES_CLIENTES()
            {
                IdDireccionCliente = (int)reader["IdDireccionCliente"],
                IdCliente = (int)reader["IdCliente"],
                Calle = reader["Calle"].ToString(),
                NoExt = reader["NoExt"].ToString(),
                NoInt = reader["NoInt"].ToString(),
                Colonia = reader["Colonia"].ToString(),
                CP = reader["CP"].ToString(),
                Ciudad = reader["Ciudad"].ToString(),
                Estado = reader["Estado"].ToString()
            };
        }

        public async Task<List<DIRECCIONES_CLIENTES>> GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarDireccionesCliente", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@p_IdCliente", id);
                        var response = new List<DIRECCIONES_CLIENTES>();
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

        public async Task<ResultadoSP> Abc(int accion, string usuario, DIRECCIONES_CLIENTES direccionCliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.Abc_DireccionesClientes", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_Accion", accion);
                        sqlCmd.Parameters.AddWithValue("@p_IdDireccionCliente", direccionCliente.IdDireccionCliente);
                        sqlCmd.Parameters.AddWithValue("@p_IdCliente", direccionCliente.IdCliente);
                        sqlCmd.Parameters.AddWithValue("@p_Calle", direccionCliente.Calle);
                        sqlCmd.Parameters.AddWithValue("@p_NoExt", direccionCliente.NoExt);
                        sqlCmd.Parameters.AddWithValue("@p_NoInt", direccionCliente.NoInt);
                        sqlCmd.Parameters.AddWithValue("@p_Colonia", direccionCliente.Colonia);
                        sqlCmd.Parameters.AddWithValue("@p_CP", direccionCliente.CP);
                        sqlCmd.Parameters.AddWithValue("@p_Ciudad", direccionCliente.Ciudad);
                        sqlCmd.Parameters.AddWithValue("@p_Estado", direccionCliente.Estado);
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

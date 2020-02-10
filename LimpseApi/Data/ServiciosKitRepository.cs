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
    public class ServiciosKitRepository
    {
        private readonly string _connectionString;

        public ServiciosKitRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        public async Task<List<SERVICIOS_KIT>> GetAll()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarServiciosKit", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<SERVICIOS_KIT>();
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

        private SERVICIOS_KIT MapToValue(SqlDataReader reader)
        {
            return new SERVICIOS_KIT()
            {
                IdServicioKit = (int)reader["IdServicioKit"],
                IdKitServicio = (int)reader["IdKitServicio"],
                IdServicio = (int)reader["IdServicio"],
                Cantidad = (int)reader["Cantidad"]
                
            };
        }

        public async Task<List<SERVICIOS_KIT>> GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarServiciosKit", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@p_IdKitServicio", id);
                        var response = new List<SERVICIOS_KIT>();
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

        public async Task<ResultadoSP> Abc(int accion, string usuario, SERVICIOS_KIT serviciokit)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.Abc_ServiciosKit", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_Accion", accion);
                        sqlCmd.Parameters.AddWithValue("@p_IdServicioKit", serviciokit.IdServicioKit);
                        sqlCmd.Parameters.AddWithValue("@p_IdKitServicio", serviciokit.IdKitServicio);
                        sqlCmd.Parameters.AddWithValue("@p_IdServicio", serviciokit.IdServicio);
                        sqlCmd.Parameters.AddWithValue("@p_Cantidad", serviciokit.Cantidad);
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

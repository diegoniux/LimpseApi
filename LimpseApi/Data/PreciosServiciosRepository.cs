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
    public class PreciosServiciosRepository
    {

        private readonly string _connectionString;

        public PreciosServiciosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }
        public async Task<ResultadoSP> RegistrarPrecioServicio(string usuario, PRECIOS_SERVICIOS precioServicio)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prRegistrarPrecioServicio", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_IdPrecioServicio", precioServicio.IdPrecioServicio);
                        sqlCmd.Parameters.AddWithValue("@p_IdServicio", precioServicio.IdServicio);
                        sqlCmd.Parameters.AddWithValue("@p_Precio", precioServicio.Precio);
                        sqlCmd.Parameters.AddWithValue("@p_FechaAplicacion", precioServicio.FechaAplicacion);
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

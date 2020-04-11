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
    public class PreciosMaterialesRepository
    {
        private readonly string _connectionString;

        public PreciosMaterialesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        public async Task<ResultadoSP> RegistrarPrecioMaterial(string usuario, PRECIOS_MATERIALES precioMaterial)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prRegistrarPrecioMaterial", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_IdPrecioMaterial", precioMaterial.IdPrecioMaterial);
                        sqlCmd.Parameters.AddWithValue("@p_IdMaterial", precioMaterial.IdMaterial);
                        sqlCmd.Parameters.AddWithValue("@p_Precio", precioMaterial.Precio);
                        sqlCmd.Parameters.AddWithValue("@p_FechaAplicacion", precioMaterial.FechaAplicacion);
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

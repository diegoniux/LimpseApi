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
    public class ClientesRepository
    {
        private readonly string _connectionString;

        public ClientesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        public async Task<List<CLIENTES>> GetAll()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarClientes", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<CLIENTES>();
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

        private CLIENTES MapToValue(SqlDataReader reader)
        {
            return new CLIENTES()
            {
                IdCliente = (int)reader["IdCliente"],
                RFC = reader["RFC"].ToString(),
                RazonSocial = reader["RazonSocial"].ToString(),
                Nombres = reader["Nombres"].ToString(),
                ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                Email = reader["Email"].ToString(),
                Activo = (bool)reader["Activo"]
            };
        }

        public async Task<CLIENTES> GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarClientes", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@p_IdCliente", id);
                        var response = new CLIENTES();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response = MapToValue(reader);
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

        public async Task<ResultadoSP> Abc(int accion, string usuario, CLIENTES cliente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.Abc_Clientes", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_Accion", accion);
                        sqlCmd.Parameters.AddWithValue("@p_IdCliente", cliente.IdCliente);
                        sqlCmd.Parameters.AddWithValue("@p_RazonSocial", cliente.RazonSocial);
                        sqlCmd.Parameters.AddWithValue("@p_Nombres", cliente.Nombres);
                        sqlCmd.Parameters.AddWithValue("@p_ApellidoPaterno", cliente.ApellidoPaterno);
                        sqlCmd.Parameters.AddWithValue("@p_ApellidiMaterno", cliente.ApellidoMaterno);
                        sqlCmd.Parameters.AddWithValue("@p_RFC", cliente.RFC);
                        sqlCmd.Parameters.AddWithValue("@p_Email", cliente.Email);
                        sqlCmd.Parameters.AddWithValue("@p_Activo", cliente.Activo);
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

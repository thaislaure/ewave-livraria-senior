using BLL.DTO;
using BLL.Models;
using Dapper;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace DAL.Repository
{
    public class GeneroRepository : RepositoryBase, IGeneroRepository
    {
        public List<GeneroDTO> GetAll()
        {
            var connectionString = this.GetConnectionString();
            List<GeneroDTO> generos = new List<GeneroDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    var query = @"SELECT 
                                   g.GeneroId, 
                                   g.Nome                                   
                                   FROM Genero g ";

                    generos = con.Query<GeneroDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return generos;
            }
        }

        public Genero GetById(int generoId)
        {
            var connectionString = this.GetConnectionString();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Genero WHERE GeneroId =" + generoId;
                    return con.Query<Genero>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public int Add(Genero genero)
        {
            var connectionString = this.GetConnectionString();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Genero(Nome) VALUES (@Nome); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, genero);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Update(Genero genero)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"UPDATE Genero SET Nome = @Nome WHERE GeneroId = " + genero.GeneroId;
                    count = con.Execute(query, genero);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Remove(int generoId)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Genero WHERE GeneroId =" + generoId;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

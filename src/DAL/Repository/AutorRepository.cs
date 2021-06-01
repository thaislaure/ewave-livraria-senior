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
    public class AutorRepository : RepositoryBase, IAutorRepository
    {
        public List<AutorDTO> GetAll()
        {
            var connectionString = this.GetConnectionString();
            List<AutorDTO> autores = new List<AutorDTO>();
            string where = string.Empty;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();                                      

                    var query = @"SELECT 
                                   a.AutorId, 
                                   a.Nome                                   
                                   FROM Autor a ";

                    autores = con.Query<AutorDTO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return autores;
            }
        }

        public Autor GetById(int autorId)
        {
            var connectionString = this.GetConnectionString();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Autor WHERE AutorId =" + autorId;
                    return con.Query<Autor>(query).FirstOrDefault();
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

        public int Add(Autor autor)
        {
            var connectionString = this.GetConnectionString();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Autor(Nome) VALUES (@Nome); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, autor);
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

        public int Update(Autor autor)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"UPDATE Autor SET Nome = @Nome WHERE AutorId = " + autor.AutorId;
                    count = con.Execute(query, autor);
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

        public int Remove(int autorId)
        {
            var connectionString = this.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Autor WHERE AutorId =" + autorId;
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

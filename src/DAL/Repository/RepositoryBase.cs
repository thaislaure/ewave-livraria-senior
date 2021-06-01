using Interfaces.Repository;

namespace DAL.Repository
{
    public  class RepositoryBase : IRepositoryBase
    {
        public string GetConnectionString()
        {
           // return "Server= 192.168.0.10\\SQLEXPRESS;Database=Livraria;User Id=sa;Password=c6!Hc#;";
            return @"Server=database;Database=Livraria;User Id=sa;Password=123@Abc@#!X;";
        }
    }
}

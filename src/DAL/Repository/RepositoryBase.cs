using Interfaces.Repository;

namespace DAL.Repository
{
    public  class RepositoryBase : IRepositoryBase
    {
        public string GetConnectionString()
        {
           // return "Server= 192.168.0.10\\SQLEXPRESS;Database=Livraria;User Id=sa;Password=c6!Hc#;";
            return "Server= 172.27.1.4\\SQLEXPRESS;Database=Livraria;User Id=sa;Password=123;";
        }
    }
}

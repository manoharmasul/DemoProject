using Microsoft.Data.SqlClient;
using System.Data;

namespace DemoProject.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string  _connectionstring;
        public DapperContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("SqlConnection");

        }
        public IDbConnection CreateConnection() =>
             new SqlConnection(_connectionstring);
    }
}

using Microsoft.Extensions.Configuration;
using Cayetano.Inmobiliaria.Transversal.Common;
using System.Data;
using System.Data.SqlClient;
using Cayetano.Inmobiliaria.Infrastructure.Data;

namespace Cayetano.Inmobiliaria.Infrastructure.Data
{

    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("NortwindConnection");
        }

        public IDbConnection GetConnection
        {
            get
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
        }
    }
}

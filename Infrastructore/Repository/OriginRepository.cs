using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Application.RepositoryInterfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructore.Repository
{
    public class OriginRepository: IOriginRepository
    {
        private readonly string _connectionString;
        public OriginRepository(IConfiguration config)
        {
            _connectionString = config["connection"];
        }

        public List<string> GetOrigins()
        { 
            using var sqlConnection = new SqlConnection(_connectionString);
            var result =
                ( sqlConnection.Query<string>("Origins_Get",
                    commandType: CommandType.StoredProcedure)).ToList();
            return result;
        }
    }
}
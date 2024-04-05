using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using MagicVilla_VillaAPI.Models;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Data
{
    public class DapperDbContext : IDapperDbContext
    {
        private readonly IDbConnection db;
        
        public DapperDbContext()
        {
            db = new SqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
        }

        public async Task<ResponseObjectType> GetInfoAsync<ResponseObjectType>(object obj, string sp)
        {
            var result = await db.QueryFirstOrDefaultAsync<ResponseObjectType>(sp, obj, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<IEnumerable<ResponseObjectType>> GetInfoListAsync<ResponseObjectType>(object obj, string sp)
        {
            var result = await db.QueryAsync<ResponseObjectType>(sp, obj, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task ExecuteNonQueryAsync(object obj, string sp)
        {
            await db.ExecuteAsync(sp, obj, commandType: CommandType.StoredProcedure);
        }
        
        public async Task<T> ExecuteScalarAsync<T>(object obj, string sp)
        {
            var result = await db.ExecuteScalarAsync<T>(sp, obj, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
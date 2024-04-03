using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Data
{
    public class DapperDbContext : IDapperDbContext
    {
        private readonly IDbConnection db;
        
        public DapperDbContext(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("cn1"));
        }

        public ResponseObjectType GetInfo<ResponseObjectType>(object obj, string sp)
        {
            var result = db.QueryFirstOrDefault<ResponseObjectType>(sp, obj, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<ResponseObjectType> GetInfoList<ResponseObjectType>(object obj, string sp)
        {
            var result = db.Query<ResponseObjectType>(sp, obj, commandType: CommandType.StoredProcedure);
            return result;
        }

        public void ExecuteNonQuery(object obj, string sp)
        {
            db.Execute(sp, obj, commandType: CommandType.StoredProcedure);
        }
        
        public T ExecuteScalar<T>(object obj, string sp)
        {
            var result = db.ExecuteScalar<T>(sp, obj, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
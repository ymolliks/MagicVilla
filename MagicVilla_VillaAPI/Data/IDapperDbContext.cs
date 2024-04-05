using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Data
{
    public interface IDapperDbContext
    {
        Task ExecuteNonQueryAsync(object obj, string sp);
        Task<ResponseObjectType> GetInfoAsync<ResponseObjectType>(object obj, string sp);
        Task<IEnumerable<ResponseObjectType>> GetInfoListAsync<ResponseObjectType>(object obj, string sp);
        Task<T> ExecuteScalarAsync<T>(object obj, string sp);
    }
}
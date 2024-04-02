namespace MagicVilla_VillaAPI.Data
{
    public interface IDapperDbContext
    {
        void BasicOperation(object obj, string sp);
        ResponseObjectType GetInfo<ResponseObjectType>(object obj, string sp);
        IEnumerable<ResponseObjectType> GetInfoList<ResponseObjectType>(object obj, string sp);
    }
}
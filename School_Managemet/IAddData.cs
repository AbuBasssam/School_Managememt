using Microsoft.Data.SqlClient;

namespace School_Managemet
{
    public interface IAddData<in T> where T : class
    {
        Task<int?> Add(T entity);
    }
    
}

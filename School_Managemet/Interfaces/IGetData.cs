
namespace School_Managemet_Repository.Interfaces
{
    public interface IGetData<T> where T : class
    {
        Task<T?> Get(int ID);
    }
}

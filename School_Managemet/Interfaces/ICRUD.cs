namespace School_Managemet_Repository.Interfaces
{
    public interface ICRUD<T> where T : class
    {
        Task<int?> Add(T entity);
        Task<T?> Get(int ID);
        Task<bool> Update(T entity);
        Task<bool> Delete(int ID);
    }
}

namespace School_Managemet_Repository.Interfaces
{
    public interface IUpdateData<in T> where T : class
    {
        Task<bool> Update(T entity);
    }
}

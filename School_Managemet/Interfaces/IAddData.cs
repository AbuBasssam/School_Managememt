namespace School_Managemet_Repository.Interfaces
{
    public interface IAddData<in T> where T : class
    {
        Task<int?> Add(T entity);
    }

}

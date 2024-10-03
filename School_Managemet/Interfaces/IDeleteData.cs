namespace School_Managemet_Repository.Interfaces
{
    public interface IDeleteData
    {
        Task<bool> Delete(int ID);
    }
}

namespace School_Managemet_Repository.Interfaces
{
    public interface IUserType<T> :IUserRepository
    {
        Task<T?> Login(string UserName, string Password);

    }
}

using School_Management_Domain;

namespace School_Managemet_Repository.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<bool> ChangePassword(ChangePassword changePasswordModel);
        Task<bool> DeactivateAsync(int UserID);
    }
}

using School_Managemet_Repository.Models;

namespace School_Managemet_Repository.Interfaces
{
    public interface IUserRepository:IPersonRepository
    {
        Task<bool> ChangePassword(ChangePassword changePasswordModel);
    }
}

using School_Managemet_Repository.Models;

namespace School_Managemet_Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ChangePassword(ChangePassword changePasswordModel);
        Task<bool> Update<Person>(Person person);
    }
}

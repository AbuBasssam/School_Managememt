using School_Managemet_Repository;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;
using School_Managemet_Repository.Repositories;
namespace School_Management_Services
{
    public abstract class User:Person
    {
        public int? UserID { get; set; } = null;    
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
   
        /// <summary>
        ///  method for changing a user's password.
        /// </summary>
        /// <param name="changePasswordModel">The change password DTO containing new password,old password and UserID details.</param>
        /// <returns>True if password change is successful, otherwise false.</returns>
        public async Task<bool> ChangePassword(IUserRepository _userRepository, ChangePassword changePasswordModel)
        {
            return await _userRepository.ChangePassword(changePasswordModel);
        }

    }

}

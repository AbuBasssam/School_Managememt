using School_Managemet_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ChangePassword(ChangePassword changePasswordModel);
        Task<bool> Update<Person>(Person person);
    }
}

using School_Managemet_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository
{
    public interface IUserRepository:IUpdateData<Person>
    {
        Task<bool> ChangePassword(string OldPassword,string NewPassword);
    }
}

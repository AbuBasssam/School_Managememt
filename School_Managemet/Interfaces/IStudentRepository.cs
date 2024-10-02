using School_Managemet_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Interfaces
{
    public interface IStudentRepository:IUserType<StudentUser>,IDeleteData,IGetData<Student>
    {
        Task<string?> Add(AddStudent NewStudentUser);
        Task<bool> UpgradeLevel(string UserName);
        Task<IEnumerable<StudentView?>> GetStudentsPage(int Page = 1);

    }
}

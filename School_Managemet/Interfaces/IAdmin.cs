using School_Managemet_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Interfaces
{
    public interface IAdmin
    {
        Task<bool> DeactivateAsync(int UserID);
        //Task<bool> Delete(int UserID);
        //Task<IEnumerable<StudentView?>> GetStudentsPage(int Page = 1);
        //Task<IEnumerable<TeacherView?>> GetTeachersPage(int Page = 1);
        //Task<bool> UpgradeLevel(int StudentID);


    }
}

using School_Management_Domain;
using School_Managemet_Repository.Models;

namespace School_Managemet_Repository.Interfaces
{
    public interface IStudentRepository:IUserType<StudentUser>,IGenericRepository<Student>
    {
        Task<bool> UpdateAsync(Person person);
        Task<IEnumerable<StudentView>> GetStudentsViewPageAsync(int Page = 1);
    
    }
}

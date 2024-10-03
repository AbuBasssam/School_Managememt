using School_Managemet_Repository.Models;

namespace School_Managemet_Repository.Interfaces
{
    public interface IStudentRepository:IUserType<StudentUser>,IDeleteData,IGetData<Student>
    {
        Task<string?> Add(AddStudent NewStudentUser);
        Task<bool> UpgradeLevel(string UserName);
        Task<IEnumerable<StudentView?>> GetStudentsPage(int Page = 1);

    }
    public interface ITeacherRepository : IUserType<TeacherUser>, IDeleteData, IGetData<Teacher>
    {
        Task<string?> Add(AddTeacher NewTeacherUser);

        Task<IEnumerable<TeacherView?>> GetTeachersPage(int Page = 1);

    }
}

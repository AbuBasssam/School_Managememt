using School_Managemet_Repository.Models;

namespace School_Managemet_Repository.Interfaces
{
    public interface ITeacherRepository : IUserType<TeacherUser>//, IDeleteData, IGetData<Teacher>
    {
        //Task<string?> Add(AddTeacher NewTeacherUser);

       // Task<IEnumerable<TeacherView?>> GetTeachersPage(int Page = 1);

    }
}

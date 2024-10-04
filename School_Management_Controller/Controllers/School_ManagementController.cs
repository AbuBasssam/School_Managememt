using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_Services;
using School_Managemet_Repository.Repositories;


namespace School_Management_Controller.Controllers
{
    [Route("api/School_Management/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentService;
        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("Login/{UserName},{Password}", Name = "StudentLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StudentDTO>Login(string UserName,string Password)
        {
            if (string.IsNullOrEmpty( UserName )||string.IsNullOrEmpty(Password))
            {
                return BadRequest($"Not accepted Credantial");
            }
            var Student = _studentService.Login(UserName,Password);

           return  Student.Result == null? NotFound($"Invalid username/password.") : Ok(Student.Result.DTO); ;
            
        }

    }



    [Route("api/School_Management/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _Teacher;
        public TeacherController(ITeacher teacher)
        {
            _Teacher = teacher;
        }
        [HttpGet("Login/{UserName},{Password}", Name = "TeacherLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TeacherDTO> Login(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                return BadRequest($"Not accepted Credantial");
            }
            var Teacher = _Teacher.Login(UserName, Password);

            return Teacher.Result == null ? NotFound($"Invalid username/password.") : Ok(Teacher.Result.DTO); ;

        }

    }
}

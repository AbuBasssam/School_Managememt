using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_Services;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Repositories;
using School_Managemet_Repository.Models;

using System.Linq;


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
        [HttpPut("UpdateStudent/{PersonID}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UpdatePersonDTO> UpdateStudentInfo(int PersonID, UpdatePersonDTO UpdatedStudent)
        {


            /* switch (_Person.IsValid(UpdatedStudent))
             {
                 case clsPerson.enPersonValidationType.NullObject:
                     return BadRequest($"The Object is Null fill it ");

                 case clsPerson.enPersonValidationType.EmptyFileds:
                     return BadRequest($"Some fileds is empty,please fill it");

                 case clsPerson.enPersonValidationType.UnderAge:
                     return BadRequest($"Invalid Date of birth  the age is under 18");

                 case clsPerson.enPersonValidationType.NationalNoDuplicate:

                     if (Student.Result.NationalNo != UpdatedStudent.NationalNo)
                         return BadRequest($"The National number '{UpdatedStudent.NationalNo}' already exists.");
                     else
                         break;
                 case clsPerson.enPersonValidationType.WrongNationality:
                     return BadRequest($"The NationalityID '{UpdatedStudent.Nationality}' is out of range the NationalityID show between 1 and 193 .");
             }*/
            if (PersonID < 1)
                BadRequest("Invalid ID try another one");
            UpdatePersonDTO person = new UpdatePersonDTO(
                PersonID,
                UpdatedStudent.NationalNo,
                UpdatedStudent.FirstName,
                UpdatedStudent.SecondName,
                UpdatedStudent.ThirdName,
                UpdatedStudent.LastName,
                UpdatedStudent.Gender,
                UpdatedStudent.Nationality,
                UpdatedStudent.DateOfBirth,
                UpdatedStudent.Email,
                UpdatedStudent.Phone,
                UpdatedStudent.Address
            );

            var IsStudentUpdated = _studentService.Update(person);

            return (IsStudentUpdated.Result) ? Ok("Updated Successfully") : BadRequest("Something is wrong the data not updated");

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

        [HttpPut("UpdateTeacher/{PersonID}", Name = "UpdateTeacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UpdatePersonDTO> UpdateTeacherInfo(int PersonID,  UpdatePersonDTO UpdatedTeacher)
        {


            /* switch (_Person.IsValid(UpdatedStudent))
             {
                 case clsPerson.enPersonValidationType.NullObject:
                     return BadRequest($"The Object is Null fill it ");

                 case clsPerson.enPersonValidationType.EmptyFileds:
                     return BadRequest($"Some fileds is empty,please fill it");

                 case clsPerson.enPersonValidationType.UnderAge:
                     return BadRequest($"Invalid Date of birth  the age is under 18");

                 case clsPerson.enPersonValidationType.NationalNoDuplicate:

                     if (Student.Result.NationalNo != UpdatedStudent.NationalNo)
                         return BadRequest($"The National number '{UpdatedStudent.NationalNo}' already exists.");
                     else
                         break;
                 case clsPerson.enPersonValidationType.WrongNationality:
                     return BadRequest($"The NationalityID '{UpdatedStudent.Nationality}' is out of range the NationalityID show between 1 and 193 .");
             }*/

            var genderOptions = new List<string> { "Male", "Female" };
            //if(!genderOptions.Contains(UpdatedTeacher.Gender))
            //{
            //    return BadRequest("Invalid gender value. Please use 'Male' or 'Female'.");
            //}

            if (PersonID < 1)
                BadRequest("Invalid ID try another one");
            UpdatePersonDTO person = new UpdatePersonDTO(
                PersonID,
                UpdatedTeacher.NationalNo,
                UpdatedTeacher.FirstName,
                UpdatedTeacher.SecondName,
                UpdatedTeacher.ThirdName,
                UpdatedTeacher.LastName,
                UpdatedTeacher.Gender,
                UpdatedTeacher.Nationality,
                UpdatedTeacher.DateOfBirth,
                UpdatedTeacher.Email,
                UpdatedTeacher.Phone,
                UpdatedTeacher.Address
            );

            var IsStudentUpdated = _Teacher.Update(person);

            return (IsStudentUpdated.Result) ? Ok("Updated Successfully") : BadRequest("Something is wrong the data not updated");

        }
    }
}

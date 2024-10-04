// See https://aka.ms/new-console-template for more information
using School_Managemet_Repository.Repositories;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
           var connectionString = "Server=.;Database=SchoolDB;User Id=sa;Password=sa123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;"; // replace with your actual connection string
            /*var StudentRepo= new StudentRepsitory(connectionString);
            if (StudentRepo.GetStudentsPage().Result != null ) 
                Console.WriteLine("Sccussfully");*/
            var TeacherRepo = new TeacherRepository(connectionString);
            /*var teacher = new AddTeacher();

            teacher.NationalNO = "2289192213";
            teacher.FirstName = "Sara Alhassal";
            teacher.SecondName = "Bassam";
            teacher.ThirdName = "Abdul Rahman";
            teacher.LastName = "Hajjar";
            teacher.DateOfBirth = new DateTime(2009, 1, 1);
            teacher.Gender = 1;
            teacher.Address = "Eygpt,Alqaura";
            teacher.Phone = "+966 581149658";
            teacher.Email = "Ammar@gmail.com";
            teacher.Nationality = 161;
            teacher.ImagePath = null;
            teacher.Password = "1234";
            teacher.SubjectExpertise = "Science";
            teacher.bio = "ScenceTeacher";*/

            //var result = TeacherRepo.GetTeachersPage(1).Result;
            //if(result!=null) 
            //    Console.WriteLine($"user deactivated successfully");
            Console.ReadKey();
        }

    }
}


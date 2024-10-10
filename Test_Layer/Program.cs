// See https://aka.ms/new-console-template for more information
using School_Management_Domain;
using School_Managemet_Repository.Repositories;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
           var connectionString = "Server=.;Database=SchoolDB;User Id=sa;Password=sa123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;"; 

            var studentRepo = new StudentRepsitory(connectionString);
            
            Console.ReadKey();

        }
    }
    /* People Tests
 * People view page
var PeopleRepo = new PersonRepository(connectionString);
if(PeopleRepo.GetViewPageAsync().Result.Count()>0)
    Console.WriteLine($"People List is there");

 * People page
if(PeopleRepo.GetPageAsync().Result.Count()>0)
    Console.WriteLine($"People List is there");

* Add Person
Person person= new Person();
person.NationalNO = "1234567895"; // Example National ID
person.FirstName = "Maher";
person.SecondName = "Mohammed";
person.ThirdName = "Ahmed";
person.LastName = "AlSaud";
person.Gender = 0;// 1 for Male, 2 for Female (example)
person.Nationality = 169; // Example value for nationality
person.DateOfBirth = new DateTime(1990, 1, 1); // Example date of birth
person.Email = "ali.alsaud@example.com";
person.Phone = "+966 561234567"; // Function to format phone number
person.Address = "Riyadh, Saudi Arabia";
person.ImagePath = null; // Or specify a path if available
int? PersonID = PeopleRepo.AddAsync(person).Result;
if (PersonID != null)
   Console.WriteLine($"Person add successfuly with ID : {PersonID}");

 * Get & Update
Person? person = PeopleRepo.GetByNationalNOAsync("1234567895").Result;
if (person != null)
{
    person.FirstName = "Maherr";
    if (PeopleRepo.UpdateAsync(person).Result)
       Console.WriteLine($"Person Updated successfuly");

}

*Delete person

if (PeopleRepo.DeleteAsync(14).Result)
    {
        Console.WriteLine($"Person Deleted successfuly");

    }

*/

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

    /* Users Tests
     * var UserRepo=new UserRepository(connectionString);
     
     * Users list
       if (UserRepo.GetPageAsync().Result.Count() > 0)
            Console.WriteLine($"Users List is there");
     * Get User
     if (UserRepo.GetByIDAsync(1).Result!=null)
                Console.WriteLine($"Users Find successfully");
     * Add user
       var newUser = new Domain.User
            {
                UserName = "johndoe",
                Password = "securepassword!", // Remember to hash the password in a real application
                IsActive = true,
                PersonID = 13 // Example PersonID
            };
            int? UserID = UserRepo.AddAsync(newUser).Result;
            if (UserID != null)
                Console.WriteLine($"User add successfuly with ID : {UserID}");
    
     * Get & update user
       var User = UserRepo.GetByIDAsync(12).Result;
            if (User != null)
            {
                User.Password = "593049573";
                if (UserRepo.UpdateAsync(User).Result)
                    Console.WriteLine($"User Updated successfuly");

            }
     * Delete user
     if (UserRepo.DeleteAsync(12).Result)
                    Console.WriteLine($"User Deleted successfuly");
     
     * Update Password
     var ChangePassword = new ChangePassword { OldPassword = "1234", NewPassword = "1245", UserID = 11 };
           
            if (UserRepo.ChangePassword(ChangePassword).Result)
            {
                Console.WriteLine("Updated Successfully");
            }
     * Deactive user
     if (UserRepo.DeactivateAsync(11).Result)
            {
                Console.WriteLine("Deactiveated");
            }
     */

    /* student Tests
      var studentRepo = new StudentRepsitory(connectionString);

     * Get & update
       Student? student;
            student = studentRepo.GetByIDAsync(1).Result;
            if (  student!=null)
            {
             student.EnrollmentDate = DateTime.Now.AddDays(1);
                if (studentRepo.UpdateAsync(student).Result)
                {
                    Console.WriteLine("Updated Sucessfully");   
                }
                
            }

     * Add student by Exists user
    
    Student student = new Student()
            {
                UserID = 12,
                GradeLevel = 1
            };

            int? ID=studentRepo.AddAsync(student).Result;
            if (ID.HasValue)
            {
                Console.WriteLine($"Student has added successfully with ID : {ID}");
            }
     * Student View
     
      if (studentRepo.GetStudentsViewPageAsync().Result.Count()>0)
            {
                Console.WriteLine("Found Successfully");
            }
     
     * Student page
     
      if (studentRepo.GetPageAsync().Result.Count() > 0)
            {
                Console.WriteLine("Found Successfully");
            }
            
     */
}


// See https://aka.ms/new-console-template for more information
using School_Managemet_Repository;
using School_Managemet_Repository.Models;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
           var connectionString = "Server=.;Database=SchoolDB;User Id=sa;Password=sa123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;"; // replace with your actual connection string
            var StudentRepo= new StudentRepsitory(connectionString);
            if (StudentRepo.GetStudentsPage() != null ) 
                Console.WriteLine("Sccussfully");
            Console.ReadKey();
        }

    }
}


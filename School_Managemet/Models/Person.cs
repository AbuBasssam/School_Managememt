using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace School_Managemet_Repository.Models
{
    public class Person
    {
        public required int PersonID { get;  set; }
        public required string NationalNO { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string ThirdName { get; set; }
        public required string LastName { get; set; }
        public required bool Gender { get; set; }
        public required byte Nationality { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public string? ImagePath { get; set; }



    }
}

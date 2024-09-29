using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace School_Managemet_Repository
{
    internal class Person
    {
        public int ID { get; private set; }
        public  string NationalNO { get; set; }
        public  string FirstName { get; set; }
        public  string SecondName { get; set; }
        public  string ThirdName { get; set; }
        public  string LastName { get; set; }
        public  byte Gender { get; set; }
        public  byte Nationality { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public  string Email { get; set; }
        public  string Phone { get; set; }
        public  string Address { get; set; }
        public string? ImagePath { get; set; }



    }
}

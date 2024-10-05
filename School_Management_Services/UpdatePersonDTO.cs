namespace School_Management_Services
{
    public class UpdatePersonDTO
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public byte Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public UpdatePersonDTO(int personID, string nationalNo,
            string firstName, string secondName, string thirdName, string lastName,
            bool gender, byte nationality, DateTime dateOfBirth,
            string email, string phone, string address)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Gender = gender;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
            Email = email;
            Phone = phone;
            Address = address;
        }


    }
}

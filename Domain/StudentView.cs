namespace School_Management_Domain
{
    public class StudentView
    {
        public PersonView info { get; set; }= new PersonView();
        public string StudentNumber {  get; set; }
        public string GradeLevel { get; set; }  


    }
}

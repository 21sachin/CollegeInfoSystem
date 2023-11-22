namespace CollegeInfoSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public  string Sname { get; set; }  
        public string Email { get; set; }
        public string PhoneNo { get; set; } 
        public Teacher Teacher { get; set; }
        public int Tid { get; set;}

    }
}

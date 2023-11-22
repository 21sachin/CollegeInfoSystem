namespace CollegeInfoSystem.Models
{
    public class Teacher
    {
        public int Tid { get; set; }
        public string Tname { get; set; }
        public string Subject { get; set; }

        public IList<Student>students { get; set; }

    }
}

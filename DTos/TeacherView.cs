namespace CollegeInfoSystem.DTos
{
    public class TeacherView
    {
        public string TeacherName {  get; set; }
        public string Subject { get; set; }
        public int StudentCount { get; set; } = 0;
        public List<StudentView> studentViews { get; set; }
    }
}

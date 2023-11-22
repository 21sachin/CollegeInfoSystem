using CollegeInfoSystem.Models;
using CollegeInfoSystem.DTos;

namespace CollegeInfoSystem.Repository
{


    public interface ICollege
    {
        Task AddStudent(Student student);
        Task AddTeacher(Teacher teacher);
        Task<List<TeacherView>>GetTeacher(int TeacherId);
        Task<List<StudentView>> GetAllStudent();
    }
}

using CollegeInfoSystem.Context;
using CollegeInfoSystem.DTos;
using CollegeInfoSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeInfoSystem.Repository
{
    public class CollegeRepo:ICollege
    {
        private readonly MyContext _context;
        public CollegeRepo(MyContext context)
        {
            _context = context;
        }

        public async Task AddStudent(Student student)
        {
          
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task AddTeacher(Teacher teacher)
        {
            await _context.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentView>> GetAllStudent()
        {
            _context.students.ExecuteDeleteAsync()
            return await _context.students.Select(s => new StudentView
                  {
                        StudentName = s.Sname,
                        StudentEmail = s.Email,
                        StudentPhone =s.PhoneNo
                  }).ToListAsync(); 
            
        }

        public async Task<List<TeacherView>> GetTeacher(int TeacherId)
        {
          return await _context.teachers.Where(t => t.Tid == TeacherId)
                                    .Include(t => t.students)
                                    .Select(t => new TeacherView
                                    {
                                        TeacherName = t.Tname,
                                        Subject = t.Subject,
                                        studentViews = t.students.Select(s => new StudentView
                                        {
                                            StudentName = s.Sname,
                                            StudentEmail = s.Email,
                                            StudentPhone = s.PhoneNo,

                                        }).ToList()

                                    }).ToListAsync();
            
            
        }
    }
}

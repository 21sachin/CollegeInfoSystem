using CollegeInfoSystem.DTos;
using CollegeInfoSystem.Helper;
using CollegeInfoSystem.Models;
using CollegeInfoSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;

namespace CollegeInfoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollege _college;
        private readonly Messages _messages;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="college"></param>
        /// <param name="messages"></param>
        public CollegeController(ICollege college, IOptions<Messages> messages)
        {
            _college = college;
            _messages = messages.Value;
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudent()
        { 
            return Ok(await _college.GetAllStudent());
        }



        [HttpGet("Details/{TeacherId}")]
        public async Task<IActionResult> GetTeacherdetails(int TeacherId)
        {
            var deal = await _college.GetTeacher(TeacherId);
            return Ok(deal);
        }


        /// <summary>
        /// Use to add teacher
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost("Add-Teacher")]
        public async Task<IActionResult> AddTeacherDetail([FromBody]TeacherDTO teacher)
        {
            if (teacher == null) return BadRequest();
            Teacher tech = new()
            {
                Tname=teacher.TeacherName,
                Subject=teacher.Subject
            };
            await _college.AddTeacher(tech);
            return Ok(_messages.SucessMessage);
        }

        /// <summary>
        /// Add Student 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost("Add-Student")]
        public async Task<IActionResult> AddStudentDetail([FromBody] StudentDTO student)
        {
            if (student == null) return BadRequest();
            Student std = new()
            {
                Sname=student.StudentName,
                PhoneNo=student.StudentPhone,
                Email=student.StudentEmail,
                Tid=student.TeacherId
            };
            await _college.AddStudent(std);
            return Ok(_messages.SucessMessage);
        }

       
    }
}

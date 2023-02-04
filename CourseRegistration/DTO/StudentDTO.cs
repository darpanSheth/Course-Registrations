using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.DTO
{
	public class StudentDTO : PersonDTO
	{
        public int StudentId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public List<StudentCourseDTO> StudentCourses { get; set; }
    }
}


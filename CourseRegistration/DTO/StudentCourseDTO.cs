using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.DTO
{
	public class StudentCourseDTO
	{


        [Required]
        public int StudentId { get; set; }
        public StudentDTO Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }
    }
}


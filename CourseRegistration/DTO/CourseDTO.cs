using System;
using System.ComponentModel.DataAnnotations;
namespace CourseRegistration.DTO
{
	public class CourseDTO
	{
        public int CourseId { get; set; }

        [Required]
        public string CourseNumber { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string Description { get; set; }

        public List<StudentCourseDTO> StudentCourses { get; set; }

        
    }
}


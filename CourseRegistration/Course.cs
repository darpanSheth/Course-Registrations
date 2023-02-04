using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration
{
	public class Course
	{
		public int CourseId { get; set; }

		[Required]
		public string CourseNumber { get; set; }

		[Required]
		public string CourseName { get; set; }

		[Required]
		public string Description { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }

		
    }
}


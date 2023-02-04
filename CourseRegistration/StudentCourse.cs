using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration
{
	public class StudentCourse
	{
		[Required]
		public int StudentId { get; set; }
		public Student Student { get; set; }

		[Required]
		public int CourseId { get; set; }
		public Course Course { get; set; }

	}
}


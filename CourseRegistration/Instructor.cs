using System;
using System.ComponentModel.DataAnnotations;
namespace CourseRegistration
{
	public class Instructor : Person
	{
		public int InstructorId { get; set; }

		
		public int CourseId { get; set; }

		public Course Course { get; set; }
    }
}


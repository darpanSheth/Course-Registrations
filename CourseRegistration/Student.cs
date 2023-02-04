using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration
{
	public class Student : Person
	{
		public int StudentId { get; set; }

		[Required]
		public string PhoneNumber { get; set; }
		
        public List<StudentCourse> StudentCourses{ get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration
{
	public class Person
	{
		[Required]
		public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }
		
	}
}


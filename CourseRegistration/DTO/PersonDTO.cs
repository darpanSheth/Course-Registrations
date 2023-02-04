using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.DTO
{
	public class PersonDTO
	{
		[Required]
		public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

	}
}


using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.DTO
{
	public class InstructorDTO : PersonDTO
	{
        public int InstructorId { get; set; }

        
        public int CourseId { get; set; }

        public CourseDTO Course { get; set; }
    }
}


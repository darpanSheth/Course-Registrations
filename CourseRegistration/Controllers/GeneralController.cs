using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Models;
using System.Net;
using System.Net.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseRegistration.Controllers
{


    [Route("api/[controller]")]
    public class GeneralController : Controller
    {

        private static readonly IMapper _productsMapper;

        static GeneralController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, DTO.CourseDTO>()
                    .ForMember(dto => dto.CourseId, opt => opt.MapFrom(course => course.CourseId))
                    .ForMember(dto => dto.CourseName, opt => opt.MapFrom(course => course.CourseName))
                    .ForMember(dto => dto.CourseNumber, opt => opt.MapFrom(course => course.CourseNumber))
                    .ForMember(dto => dto.Description, opt => opt.MapFrom(course => course.Description))
                    .ForMember(dto => dto.StudentCourses, opt => opt.MapFrom(course => course.StudentCourses));


                cfg.CreateMap<DTO.CourseDTO, Course>()
                    .ForMember(course => course.CourseId, opt => opt.MapFrom(dto => dto.CourseId))
                    .ForMember(course => course.CourseName, opt => opt.MapFrom(dto => dto.CourseName))
                    .ForMember(course => course.CourseNumber, opt => opt.MapFrom(dto => dto.CourseNumber))
                    .ForMember(course => course.Description, opt => opt.MapFrom(dto => dto.Description))
                    .ForMember(course => course.StudentCourses, opt => opt.MapFrom(dto => dto.StudentCourses));


                cfg.CreateMap<Instructor, DTO.InstructorDTO>()
                    .ForMember(dto => dto.Course, opt => opt.MapFrom(instructor => instructor.Course))
                    .ForMember(dto => dto.CourseId, opt => opt.MapFrom(instructor => instructor.CourseId))
                    .ForMember(dto => dto.FirstName, opt => opt.MapFrom(instructor => instructor.FirstName))
                    .ForMember(dto => dto.LastName, opt => opt.MapFrom(instructor => instructor.LastName))
                    .ForMember(dto => dto.EmailAddress, opt => opt.MapFrom(instructor => instructor.EmailAddress))
                    .ForMember(dto => dto.InstructorId, opt => opt.MapFrom(instructor => instructor.InstructorId));

                cfg.CreateMap<DTO.InstructorDTO, Instructor>()
                    .ForMember(instructor => instructor.Course, opt => opt.MapFrom(dto => dto.Course))
                    .ForMember(instructor => instructor.CourseId, opt => opt.MapFrom(dto => dto.CourseId))
                    .ForMember(instructor => instructor.FirstName, opt => opt.MapFrom(dto => dto.FirstName))
                    .ForMember(instructor => instructor.LastName, opt => opt.MapFrom(dto => dto.LastName))
                    .ForMember(instructor => instructor.EmailAddress, opt => opt.MapFrom(dto => dto.EmailAddress))
                    .ForMember(instructor => instructor.InstructorId, opt => opt.MapFrom(dto => dto.InstructorId));

                cfg.CreateMap<Student, DTO.StudentDTO>()
                    .ForMember(dto => dto.EmailAddress, opt => opt.MapFrom(student => student.EmailAddress))
                    .ForMember(dto => dto.LastName, opt => opt.MapFrom(student => student.LastName))
                    .ForMember(dto => dto.FirstName, opt => opt.MapFrom(student => student.FirstName))
                    .ForMember(dto => dto.StudentId, opt => opt.MapFrom(student => student.StudentId))
                    .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(student => student.PhoneNumber))
                    .ForMember(dto => dto.StudentCourses, opt => opt.MapFrom(student => student.StudentCourses));

                cfg.CreateMap<DTO.StudentDTO, Student>()
                    .ForMember(student => student.EmailAddress, opt => opt.MapFrom(dto => dto.EmailAddress))
                    .ForMember(student => student.LastName, opt => opt.MapFrom(dto => dto.LastName))
                    .ForMember(student => student.FirstName, opt => opt.MapFrom(dto => dto.FirstName))
                    .ForMember(student => student.StudentId, opt => opt.MapFrom(dto => dto.StudentId))
                    .ForMember(student => student.PhoneNumber, opt => opt.MapFrom(dto => dto.PhoneNumber))
                    .ForMember(student => student.StudentCourses, opt => opt.MapFrom(dto => dto.StudentCourses));

                cfg.CreateMap<StudentCourse, DTO.StudentCourseDTO>()
                    .ForMember(dto => dto.Course, opt => opt.MapFrom(studentCourse => studentCourse.Course))
                    .ForMember(dto => dto.CourseId, opt => opt.MapFrom(studentCourse => studentCourse.CourseId))
                    .ForMember(dto => dto.Student, opt => opt.MapFrom(studentCourse => studentCourse.Student))
                    .ForMember(dto => dto.StudentId, opt => opt.MapFrom(studentCourse => studentCourse.StudentId));


                cfg.CreateMap<DTO.StudentCourseDTO, StudentCourse>()
                    .ForMember(studentCourse => studentCourse.Course, opt => opt.MapFrom(dto => dto.Course))
                    .ForMember(studentCourse => studentCourse.CourseId, opt => opt.MapFrom(dto => dto.CourseId))
                    .ForMember(studentCourse => studentCourse.Student, opt => opt.MapFrom(dto => dto.Student))
                    .ForMember(studentCourse => studentCourse.StudentId, opt => opt.MapFrom(studentCourse => studentCourse.StudentId));

            });
            _productsMapper = config.CreateMapper();
        }


        [HttpGet]
        [Route("Courses")]
        public IActionResult Courses()
        {
            var context = new StudentRegistrationContext();
            List<Course> courses = context.Courses.Include(c => c.StudentCourses).ThenInclude(c => c.Student).ToList();
            var coursesDto = new CoursesViewModel
            {
                Courses = _productsMapper.Map<List<DTO.CourseDTO>>(courses)
            };

            return View(coursesDto);

        }

        [HttpGet]
        [Route("Students")]
        public IActionResult Students()
        {
            var context = new StudentRegistrationContext();
            List<Student> students = context.Students.ToList();
            var studentsDto = new StudentsViewModel
            {
                Students = _productsMapper.Map<List<DTO.StudentDTO>>(students)
            };

            return View(studentsDto);

        }

        [HttpGet]
        [Route("Instructors")]
        public IActionResult Instructors()
        {
            var context = new StudentRegistrationContext();
            List<Instructor> instructors = context.Instructors.ToList();
            var instructorsDto = new InstructorsViewModel
            {
                Instructors = _productsMapper.Map<List<DTO.InstructorDTO>>(instructors)
            };

            return View(instructorsDto);

        }

        [HttpPost]
        [Route("SaveCourse")]
        public IActionResult SaveCourse(DTO.CourseDTO dtoCourse)
        {

            Course course = _productsMapper.Map<DTO.CourseDTO, Course>(dtoCourse);

            using (var context = new StudentRegistrationContext()) {
                context.Courses.Add(course);
                context.SaveChanges();
            }

            return RedirectToAction(nameof(Courses));
        }

        [Route("CreateCourse")]
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveStudent")]
        public IActionResult SaveStudent(DTO.StudentDTO dtoStudent)
        {

            Student student = _productsMapper.Map<DTO.StudentDTO, Student>(dtoStudent);

            using (var context = new StudentRegistrationContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }

            return RedirectToAction(nameof(Students));
        }

        [Route("CreateStudent")]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveInstructor")]
        public IActionResult SaveInstructor(DTO.InstructorDTO dtoInstructor)
        {

            Instructor instructor = _productsMapper.Map<DTO.InstructorDTO, Instructor>(dtoInstructor);

            using (var context = new StudentRegistrationContext())
            {
                var tempCourseList = context.Courses.ToArray();

                bool courseIsCreated = false;
                for (int i = 0; i < tempCourseList.Length; i++)
                {
                    if (tempCourseList[i].CourseId == instructor.CourseId)
                    {
                        courseIsCreated = true;
                    }

                }

                if (!courseIsCreated)
                {
                    return NotFound("Course is not yet created");
                }
                else
                {
                    context.Instructors.Add(instructor);
                    context.SaveChanges();
                }

            }

            return RedirectToAction(nameof(Instructors));
        }

        [Route("CreateInstructor")]
        public IActionResult CreateInstructor()
        {
            return View();
        }


        [HttpPost]
        [Route("RegisterStudentForCourse")]
        public IActionResult RegisterStudentForCourse(DTO.StudentCourseDTO dtoStudentCourse)
        {

            StudentCourse studentCourse = _productsMapper.Map<DTO.StudentCourseDTO, StudentCourse>(dtoStudentCourse);

            using (var context = new StudentRegistrationContext())
            {
                var tempStudents = context.Students.ToArray();
                var tempCourses = context.Courses.ToArray();

                var tempStudentCourse = context.StudentCourses.ToArray();

                bool studentIsAlreadyRegistered = false;

                bool studentIsThere = false;
                bool courseIsThere = false;

                for (int i = 0; i < tempStudents.Length; i++)
                {
                    if (tempStudents[i].StudentId == studentCourse.StudentId)
                    {
                        studentIsThere = true;
                    }

                }

                for (int i = 0; i < tempStudentCourse.Length; i++)
                {
                    if ((tempStudentCourse[i].CourseId == studentCourse.CourseId) && (tempStudentCourse[i].StudentId == studentCourse.StudentId))
                    {
                        studentIsAlreadyRegistered = true;
                    }

                }

                for (int i = 0; i < tempCourses.Length; i++)
                {
                    if (tempCourses[i].CourseId == studentCourse.CourseId)
                    {
                        courseIsThere = true;
                    }

                }

                if (!studentIsThere)
                {
                    return NotFound("Any student does not hvae this Id");
                }
                if (!courseIsThere)
                {
                    return NotFound("Any course does not hvae this Id");
                }
                if (studentIsAlreadyRegistered)
                {
                    return BadRequest("This Student is already registered for this course");
                }
                else
                {
                    context.StudentCourses.Add(studentCourse);
                    context.SaveChanges();
                }

            }

            return RedirectToAction(nameof(CreateStudentCourse));
        }

        [Route("CreateStudentCourse")]
        public IActionResult CreateStudentCourse()
        {
            return View();
        }

        [HttpGet]
        [Route("GetInstructorToEdit/{id}")]
        public IActionResult GetInstructorToEdit(int id)
        {
            var context = new StudentRegistrationContext();
            Instructor instructor = context.Instructors.Where(i => i.InstructorId == id).FirstOrDefault();


            DTO.InstructorDTO instructorDTO = _productsMapper.Map<Instructor, DTO.InstructorDTO>(instructor);
            return View(instructorDTO);
        }

        [HttpPost]
        [Route("GetInstructorToEdit/{id}")]
        public ActionResult GetInstructorToEdit(DTO.InstructorDTO instructorDTO)
        {
            var context = new StudentRegistrationContext();
            Instructor instructor = _productsMapper.Map<DTO.InstructorDTO, Instructor>(instructorDTO);

            Instructor tempInstructor = context.Instructors.Where(i => i.InstructorId == instructor.InstructorId).FirstOrDefault();

            var tempCourseList = context.Courses.ToArray();

            bool courseIsCreated = false;
            for (int i = 0; i < tempCourseList.Length; i++)
            {
                if (tempCourseList[i].CourseId == instructor.CourseId)
                {
                    courseIsCreated = true;
                }

            }

            if (!courseIsCreated)
            {
                return NotFound("Course is not yet created");
            }

            context.Instructors.Remove(tempInstructor);
            context.Instructors.Add(instructor);

            context.SaveChanges();
            return RedirectToAction("Instructors");
        }

        [HttpGet]
        [Route("GetStudentToEdit/{id}")]
        public IActionResult GetStudentToEdit(int id)
        {
            var context = new StudentRegistrationContext();
            Student student = context.Students.Where(i => i.StudentId == id).FirstOrDefault();


            DTO.StudentDTO studentDTO = _productsMapper.Map<Student, DTO.StudentDTO>(student);
            return View(studentDTO);
        }

        [HttpPost]
        [Route("GetStudentToEdit/{id}")]
        public ActionResult GetStudentToEdit(DTO.StudentDTO studentDTO)
        {
            var context = new StudentRegistrationContext();
            Student student = _productsMapper.Map<DTO.StudentDTO, Student>(studentDTO);

            Student tempStudent = context.Students.Where(i => i.StudentId == student.StudentId).FirstOrDefault();

            

            
            context.Students.Remove(tempStudent);
            context.Students.Add(student);

            context.SaveChanges();
            return RedirectToAction("Students");
        }

        [HttpGet]
        [Route("GetCourseToEdit/{id}")]
        public IActionResult GetCourseToEdit(int id)
        {
            var context = new StudentRegistrationContext();
            Course course = context.Courses.Where(i => i.CourseId == id).FirstOrDefault();


            DTO.CourseDTO courseDTO = _productsMapper.Map<Course, DTO.CourseDTO>(course);
            return View(courseDTO);
        }

        [HttpPost]
        [Route("GetCourseToEdit/{id}")]
        public ActionResult GetCourseToEdit(DTO.CourseDTO courseDTO)
        {
            var context = new StudentRegistrationContext();
            Course course = _productsMapper.Map<DTO.CourseDTO, Course>(courseDTO);

            Course tempCourse = context.Courses.Where(i => i.CourseId == course.CourseId).FirstOrDefault();




            context.Courses.Remove(tempCourse);
            context.Courses.Add(course);

            context.SaveChanges();
            return RedirectToAction("Courses");
        }

        [HttpGet]
        [Route("GetInstructorToDelete/{id}")]
        public IActionResult GetInstructorToDelete(int id)
        {
            var context = new StudentRegistrationContext();
            Instructor instructor = context.Instructors.Where(i => i.InstructorId == id).FirstOrDefault();


            DTO.InstructorDTO instructorDTO = _productsMapper.Map<Instructor, DTO.InstructorDTO>(instructor);
            return View(instructorDTO);
        }

        [HttpPost]
        [Route("DeleteInstructor")]
        public ActionResult DeleteInstructor(DTO.InstructorDTO instructorDTO)
        {
            var context = new StudentRegistrationContext();
            Instructor instructor = context.Instructors.Where(i => i.InstructorId == instructorDTO.InstructorId).FirstOrDefault();


            context.Instructors.Remove(instructor);
            context.SaveChanges();
            
            return RedirectToAction("Instructors");
        }

        [HttpGet]
        [Route("GetStudentToDelete/{id}")]
        public IActionResult GetStudentToDelete(int id)
        {
            var context = new StudentRegistrationContext();
            Student student = context.Students.Where(i => i.StudentId == id).FirstOrDefault();


            DTO.StudentDTO studentDTO = _productsMapper.Map<Student, DTO.StudentDTO>(student);
            return View(studentDTO);
        }

        [HttpPost]
        [Route("DeleteStudent")]
        public ActionResult DeleteStudent(DTO.StudentDTO studentDTO)
        {
            var context = new StudentRegistrationContext();
            Student student = context.Students.Where(i => i.StudentId == studentDTO.StudentId).FirstOrDefault();


            context.Students.Remove(student);
            context.SaveChanges();

            return RedirectToAction("Students");
        }

        [HttpGet]
        [Route("GetCourseToDelete/{id}")]
        public IActionResult GetCourseToDelete(int id)
        {
            var context = new StudentRegistrationContext();
            Course course = context.Courses.Where(i => i.CourseId == id).FirstOrDefault();


            DTO.CourseDTO courseDTO = _productsMapper.Map<Course, DTO.CourseDTO>(course);
            return View(courseDTO);
        }

        [HttpPost]
        [Route("DeleteCourse")]
        public ActionResult DeleteCourse(DTO.CourseDTO courseDTO)
        {
            var context = new StudentRegistrationContext();
            Course course = context.Courses.Where(i => i.CourseId == courseDTO.CourseId).FirstOrDefault();


            context.Courses.Remove(course);
            context.SaveChanges();

            return RedirectToAction("Courses");
        }
    }
}


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Models;
using AutoMapper;

namespace CourseRegistration.Controllers;

public class HomeController : Controller
{
    //private static readonly IMapper _productsMapper;

    //static HomeController()
    //{
    //    var config = new MapperConfiguration(cfg =>
    //    {
    //        cfg.CreateMap<Course, DTO.CourseDTO>()
    //            .ForMember(dto => dto.CourseId, opt => opt.MapFrom(course => course.CourseId))
    //            .ForMember(dto => dto.CourseName, opt => opt.MapFrom(course => course.CourseName))
    //            .ForMember(dto => dto.CourseNumber, opt => opt.MapFrom(course => course.CourseNumber))
    //            .ForMember(dto => dto.Description, opt => opt.MapFrom(course => course.Description))
    //            .ForMember(dto => dto.StudentCourses, opt => opt.MapFrom(course => course.StudentCourses));

    //        cfg.CreateMap<Instructor, DTO.InstructorDTO>()
    //            .ForMember(dto => dto.Course, opt => opt.MapFrom(instructor => instructor.Course))
    //            .ForMember(dto => dto.CourseId, opt => opt.MapFrom(instructor => instructor.CourseId))
    //            .ForMember(dto => dto.FirstName, opt => opt.MapFrom(instructor => instructor.FirstName))
    //            .ForMember(dto => dto.LastName, opt => opt.MapFrom(instructor => instructor.LastName))
    //            .ForMember(dto => dto.EmailAddress, opt => opt.MapFrom(instructor => instructor.EmailAddress))
    //            .ForMember(dto => dto.InstructorId, opt => opt.MapFrom(instructor => instructor.InstructorId));

    //        cfg.CreateMap<Student, DTO.StudentDTO>()
    //            .ForMember(dto => dto.EmailAddress, opt => opt.MapFrom(student => student.EmailAddress))
    //            .ForMember(dto => dto.LastName, opt => opt.MapFrom(student => student.LastName))
    //            .ForMember(dto => dto.FirstName, opt => opt.MapFrom(student => student.FirstName))
    //            .ForMember(dto => dto.StudentId, opt => opt.MapFrom(student => student.StudentId))
    //            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(student => student.PhoneNumber))
    //            .ForMember(dto => dto.StudentCourses, opt => opt.MapFrom(student => student.StudentCourses));

    //        cfg.CreateMap<StudentCourse, DTO.StudentCourseDTO>()
    //            .ForMember(dto => dto.Course, opt => opt.MapFrom(studentCourse => studentCourse.Course))
    //            .ForMember(dto => dto.CourseId, opt => opt.MapFrom(studentCourse => studentCourse.CourseId))
    //            .ForMember(dto => dto.Student, opt => opt.MapFrom(studentCourse => studentCourse.Student))
    //            .ForMember(dto => dto.StudentId, opt => opt.MapFrom(studentCourse => studentCourse.StudentId));

    //    });
    //    _productsMapper = config.CreateMapper();
    //}



    //public IActionResult Courses()
    //{
    //    var context = new StudentRegistrationContext();
    //    List<Course> courses = context.Courses.ToList();
    //    var coursesDto = new CoursesViewModel
    //    {
    //        Courses = _productsMapper.Map<List<DTO.CourseDTO>>(courses)
    //    };

    //    return View(coursesDto);

    //}

    //public IActionResult Students()
    //{
    //    var context = new StudentRegistrationContext();
    //    List<Student> students = context.Students.ToList();
    //    var studentsDto = new StudentsViewModel
    //    {
    //        Students = _productsMapper.Map<List<DTO.StudentDTO>>(students)
    //    };

    //    return View(studentsDto);

    //}

    //public IActionResult Instructors()
    //{
    //    var context = new StudentRegistrationContext();
    //    List<Instructor> instructors = context.Instructors.ToList();
    //    var instructorsDto = new InstructorsViewModel
    //    {
    //        Instructors = _productsMapper.Map<List<DTO.InstructorDTO>>(instructors)
    //    };

    //    return View(instructorsDto);

    //}

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


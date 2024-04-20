using Microsoft.AspNetCore.Mvc;
using ASPNETProdactAndCategory.Context;
using ASPNETProdactAndCategory.Models;

namespace ASPNETProdactAndCategory.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    //public class StudentController : ControllerBase
    //{
    //    private readonly AppDbContext _studentContext;

    //    public StudentController(AppDbContext studentContext)
    //    {
    //        _studentContext = studentContext;
    //    }
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _courseContext;

        public CourseController(AppDbContext courseContext)
        {
            _courseContext = courseContext;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Student>> Students()
        //{
        //    var students = _studentContext.Students;
        //    return Ok(students);
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Student> GetStudent(int id)
        //{
        //    var student = _studentContext.Students.Find(id);
        //    if (student != null)
        //        return Ok(student);
        //    else
        //        return NotFound();
        //}

        //[HttpGet]
        //public ActionResult<Student> GetStudentWithParam([FromQuery] int id)
        //{
        //    var student = _studentContext.Students.Find(id);
        //    if (student != null)
        //        return Ok(student);
        //    else
        //        return NotFound();
        //}
        //[HttpPost]
        //public ActionResult AddStudent([FromBody] Student student)
        //{
        //    _studentContext.Students.Add(student);
        //    _studentContext.SaveChanges();
        //    return Ok();
        //}

        //[HttpGet]
        //public ActionResult GetAction()
        //{
        //    return RedirectToAction(nameof(Students));
        //}

        //[HttpPut]
        //public ActionResult<bool> UpdateStudent([FromQuery] int id, [FromBody] Student student)
        //{
        //    var result = _studentContext.Students.Find(id);
        //    if (result != null)
        //    {
        //        result.FirstName = student.FirstName;
        //        result.LastName = student.LastName;
        //        result.BirthDate = student.BirthDate;
        //        _studentContext.Students.Update(result);
        //        _studentContext.SaveChanges();
        //        return Ok(true);
        //    }
        //    else
        //    {
        //        return NotFound(false);
        //    }
        //}

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    var result = _studentContext.Students.Find(id);
        //    if (result != null)
        //    {
        //        _studentContext.Students.Remove(result);
        //        _studentContext.SaveChanges();
        //        return Ok();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpGet]
        //public ActionResult<IQueryable<Student>> GetStudents([FromQuery] string name = null, [FromQuery] string birthDate = null,
        //    [FromQuery] int page = 1, [FromQuery] int pageSize = 4)
        //{
        //    var students = _studentContext.Students.OrderBy(s => s.BirthDate).ToList();
        //    if (name != null)
        //    {
        //        students = students.Where(x => x.FirstName.Equals(name)).ToList();
        //    }
        //    if (birthDate != null && birthDate.Contains("desc"))
        //    {
        //        students = students.OrderByDescending(students => students.BirthDate).ToList();
        //    }

        //    var totalCount = students.Count();
        //    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        //    students = students.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    var result = new
        //    {
        //        TotalCount = totalCount,
        //        TotalPages = totalPages,
        //        CurrentPage = page,
        //        PageSize = pageSize,
        //        Students = students
        //    };
        //    return Ok(result);
        //}

        [HttpGet]
        public ActionResult<IEnumerable<Course>> Courses()
        {
            var courses = _courseContext.Courses;
            return Ok(courses); 
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = _courseContext.Courses.Find(id);
            if (course != null)
                return Ok(course);
            else
                return NotFound();
        }

        [HttpGet]
        public ActionResult<Student> GetStudentWithParam([FromQuery] int id)
        {
            var course = _courseContext.Courses.Find(id);
            if (course != null)
                return Ok(course);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult AddCourse([FromBody] Course course)
        {
            _courseContext.Courses.Add(course);
            _courseContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAction()
        {
            return RedirectToAction(nameof(Courses));
        }

        [HttpPut]
        public ActionResult<bool> UpdateStudent([FromQuery] int id, [FromBody] Course course)
        {
            var result = _courseContext.Courses.Find(id);
            if (result != null)
            {
                result.Id = course.Id;
                result.CourseName = course.CourseName;
                result.Credits = course.Credits;
                _courseContext.Courses.Update(result);
                _courseContext.SaveChanges();
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _courseContext.Courses.Find(id);
            if (result != null)
            {
                _courseContext.Courses.Remove(result);
                _courseContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
            public ActionResult<IQueryable<Course>> GetStudents([FromQuery] string name = null, [FromQuery] string credits = null,
                [FromQuery] int page = 1, [FromQuery] int pageSize = 4)
            {
                var courses = _courseContext.Courses.OrderBy(s => s.Credits).ToList();
                if (name != null)
                {
                    courses = courses.Where(x => x.CourseName.Equals(name)).ToList();
                }
                if (credits != null && credits.Contains("desc"))
                {
                    courses = courses.OrderByDescending(courses => courses.Credits).ToList();
                }

                var totalCount = courses.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                courses = courses.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var result = new
                {
                    TotalCount = totalCount,
                    TotalPages = totalPages,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Courses = courses
                };
                return Ok(result);
            }
        
    }
}
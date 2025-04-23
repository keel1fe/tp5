using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tp5.Models;

namespace tp5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DatabaseCourseController : Controller
    {
        private static List<Predmet> courses = new List<Predmet>();
        private static int _currentId = 1;

        public IActionResult Index()
        {
            TempData["UseExternalHelper"] = true;
            return View(courses);
        }

        public IActionResult Details(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseId == id);
            return course == null ? NotFound() : View(course);
        }

        public IActionResult Create()
        {
            Response.Cookies.Append("CurrentCourseId", _currentId.ToString());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Predmet course)
        {
            if (!ModelState.IsValid) return View(course);

            course.CourseId = _currentId++;
            courses.Add(course);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseId == id);
            return course == null ? NotFound() : View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Predmet course)
        {
            if (id != course.CourseId) return NotFound();

            if (!ModelState.IsValid) return View(course);

            var existingCourse = courses.FirstOrDefault(c => c.CourseId == id);
            if (existingCourse == null) return NotFound();

            existingCourse.CourseName = course.CourseName;
            existingCourse.Description = course.Description;
            existingCourse.StartDate = course.StartDate;
            existingCourse.EndDate = course.EndDate;
            existingCourse.Instructor = course.Instructor;
            existingCourse.InstructorPhone = course.InstructorPhone;

            return RedirectToAction(nameof(Index));
        }

        public static IHtmlContent ExternalCoursesHelper(IHtmlHelper htmlHelper, IEnumerable<Predmet> courses)
        {
            var builder = new HtmlContentBuilder();
            int i = 0;
            var coursesList = courses.ToList();

            while (i < coursesList.Count)
            {
                builder.AppendHtml("<div class='course-item'>");
                builder.AppendHtml(htmlHelper.LabelForModel());
                builder.AppendHtml(htmlHelper.DisplayForModel(coursesList[i]));
                builder.AppendHtml("</div>");
                i++;
            }
            return builder;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Predmet>), 200)]
        public IActionResult GetAll()
        {
            return Ok(courses);
        }

        /// <summary>
        /// Получить курс по ID
        /// </summary>
        /// <param name="id">Идентификатор курса</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Predmet), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseId == id);
            return course == null ? NotFound() : Ok(course);
        }
    }
}

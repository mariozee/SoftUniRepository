namespace LearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Interfaces;
    using Utilities;
    using Models;

    public class CoursesController : Controller
    {     
        public CoursesController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public View All()
        {
            return View(this.Data.CoursesData.GetAll()
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Students.Count));
        }

        public View Details(int courseId)
        {
            var course = Data.CoursesData.Get(courseId);
            
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!User.Courses.Contains(course))
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            return this.View(course);
        }

        public View Enroll(int courseId)
        {
            EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = Data.CoursesData.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.User);

            return View(course);
        }

        private Course GetCourse(int id)
        {
            var course = this.Data.CoursesData.Get(id);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", id));
            }

            return course;
        }

        public View Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            var course = new Course(name);
            Data.CoursesData.Add(course);

            return View(course);
        }

        public View AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            Course course = GetCourse(courseId);
            course.AddLecture(new Lecture(lectureName));

            return View(course);
        }
    }
}

namespace LearningSystem.Data
{
    using Interfaces;
    using Models;

    public class BangaloreUniversityDate : IBangaloreUniversityDate
    {
        public BangaloreUniversityDate()
        {
            this.UsersData = new UsersRepository();
            this.CoursesData = new CourseRepository();
        }

        public UsersRepository UsersData { get; internal set; }

        public CourseRepository CoursesData { get; internal set; }
    }
}

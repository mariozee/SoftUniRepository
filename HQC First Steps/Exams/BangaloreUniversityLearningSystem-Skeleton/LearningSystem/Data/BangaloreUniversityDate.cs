namespace LearningSystem.Data
{
    using Interfaces;
    using Models;

    public class BangaloreUniversityDate : IBangaloreUniversityDate
    {
        public BangaloreUniversityDate()
        {
            this.UsersData = new UsersRepository();
            this.CoursesData = new Repository<Course>();
        }

        public UsersRepository UsersData { get; internal set; }

        public IRepository<Course> CoursesData { get; internal set; }
    }
}

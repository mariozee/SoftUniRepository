namespace LearningSystem.Interfaces
{
    using Data;
    using Models;

    public interface IBangaloreUniversityDate
    {
        UsersRepository UsersData { get; }

        IRepository<Course> CoursesData { get; }
    }
}

namespace LearningSystem.Interfaces
{
    using Data;
    using Models;

    public interface IBangaloreUniversityDate
    {
        UsersRepository UsersData { get; }

        CourseRepository CoursesData { get; }
    }
}

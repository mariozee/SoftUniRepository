namespace LearningSystem.Data
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersRepository : Repository<User>
    {
        public User GetByUsername(string username)
        {
            return this.items.FirstOrDefault(u => u.Username == username);
        }
    }
}

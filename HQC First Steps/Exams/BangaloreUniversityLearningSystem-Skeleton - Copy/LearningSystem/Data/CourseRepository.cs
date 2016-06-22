using LearningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Data
{
    public class CourseRepository : Repository<Course>
    {
        public override IEnumerable<Course> GetAll()
        {
            return this.items.OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count);
        }
    }
}

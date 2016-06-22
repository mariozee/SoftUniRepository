namespace RestaurantManagement.Interfaces
{
    using Enum;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMainCourse : IMeal
    {
        MainCourseType Type { get; }
    }
}

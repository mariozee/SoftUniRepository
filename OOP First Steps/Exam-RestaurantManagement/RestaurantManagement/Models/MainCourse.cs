namespace RestaurantManagement.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Enum;

    class MainCourse : AbstractRecipe, IMainCourse
    {
        public MainCourse(
            string name, 
            decimal price, 
            int calories, 
            int quantity, 
            int timeToPrepare,
            bool isVegan,
            MainCourseType type)
            : base(name, price, calories, quantity, timeToPrepare)
        {
            this.IsVegan = isVegan;
            this.Type =   type;
        }

        public bool IsVegan { get; private set; }

        public MainCourseType Type
        { get;
        }

        public void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }
    }
}

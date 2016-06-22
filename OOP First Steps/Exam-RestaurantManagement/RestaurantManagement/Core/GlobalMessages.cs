using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Core
{
    public static class GlobalMessages
    {
        public const string RestaurantDoesNotExist = "The restaurant {0} does not exist";
        public const string RecipeDoesNotExist = "The recipe {0} does not exist";
        public const string ToggleSugarNotApplicable = "The command ToggleSugar " +
            "is not applicable to recipe {0}";
        public const string ToggleVeganNotApplicable = "The command ToggleVegan " +
            "is not applicable to recipe {0}";
    }
}

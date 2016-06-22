namespace RestaurantManagement.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRestaurant
    {
        string Name { get; }

        string Location { get; }

        IList<IRecipe> Recipes { get; }

        void AddRecipe(IRecipe recipe);

        void RemoveRecipe(IRecipe recipe);

        string PrintMenu();
    }
}

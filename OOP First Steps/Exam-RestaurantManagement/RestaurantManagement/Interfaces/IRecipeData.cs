namespace RestaurantManagement.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRecipeData
    {
        IList<IRecipe> Recipes { get; }

        void AddRecipeToData(IRecipe recipe);

        void RemoveRecipeFromData(IRecipe recipe);
    }
}

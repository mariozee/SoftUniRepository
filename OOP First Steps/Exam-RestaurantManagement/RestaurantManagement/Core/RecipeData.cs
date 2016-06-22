namespace RestaurantManagement.Core
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RecipeData : IRecipeData
    {
        public IList<IRecipe> Recipes { get; }

        public void AddRecipeToData(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipeFromData(IRecipe recipe)
        {
            this.Recipes.Remove(recipe);
        }
    }
}

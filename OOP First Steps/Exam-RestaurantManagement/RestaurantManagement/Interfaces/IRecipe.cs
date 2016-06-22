namespace RestaurantManagement.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRecipe
    {
        string Name { get; }

        decimal Price { get; }
        
        int Calories { get; }

        int Quantity { get; }

        int TimeToPrepare { get; }
    }
}

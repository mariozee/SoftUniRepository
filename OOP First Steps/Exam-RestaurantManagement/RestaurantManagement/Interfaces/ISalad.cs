﻿namespace RestaurantManagement.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISalad : IMeal
    {
        bool ContainPasta { get; }
    }
}

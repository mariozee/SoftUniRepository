﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Interfaces
{
    public interface IScheduledPartProduce
    {
        bool CanProducePart { get; }
    }
}

﻿using Empires.Interfaces;
using Empires.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            switch (unitType)
            {
                case "Archer":
                    return new Archer();
                case "Swordsman":
                    return new Swordsman();
                default:
                    throw new ArgumentException("Unknow unit type");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Enums;
using Empires.Interfaces;
using static Empires.Enums.ResourceType;

namespace Empires.Models.Buildings
{
    public class Barrack : Building
    {
        private const string BarrackUnitType = "Swordsman";
        private const int BarrackUnitCycleLenght = 4;

        private const ResourceType BarrackResourceType = Steal;
        private const int BarrackResourceCycleLenght = 3;
        private const int BarrackResourceQuantity = 10;

        public Barrack(IUnitFactory unitFactory, IResourceFactory resourceFactory)
            : base(
                  BarrackUnitType, 
                  BarrackUnitCycleLenght, 
                  BarrackResourceType, 
                  BarrackResourceCycleLenght, 
                  BarrackResourceQuantity,
                  unitFactory, 
                  resourceFactory)
        {
        }
    }
}

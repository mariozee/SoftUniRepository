using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Empires.Enums.ResourceType;
using Empires.Interfaces;
using Empires.Enums;

namespace Empires.Models.Buildings
{
    public class Archery : Building
    {
        private const string ArcheryUnitType = "Archer";
        private const int ArcheryUnitCycleLenght = 3;

        private const ResourceType ArcheryResourceType = Gold;
        private const int ArcheryResourceCycleLenght = 2;
        private const int ArcharyResourceQuantity = 5;

        public Archery(IUnitFactory unitFactory, IResourceFactory resourceFactory)
            : base(
                  ArcheryUnitType, 
                  ArcheryUnitCycleLenght, 
                  ArcheryResourceType, 
                  ArcheryUnitCycleLenght,
                  ArcharyResourceQuantity,
                  unitFactory, 
                  resourceFactory)
        {
        }
    }
}

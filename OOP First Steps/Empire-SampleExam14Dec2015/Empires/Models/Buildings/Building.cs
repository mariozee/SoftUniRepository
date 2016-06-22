using Empires.Enums;
using Empires.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        private const int ProdtionDelay = 1;

        private int cyclesCount = 0;

        private string unitType;
        private int unitCycleLenght;
        private ResourceType resourceType;
        private int resourseCycleLenght;
        private int resourceQuantity;
        private IUnitFactory unitFactory;
        private IResourceFactory resourceFactory;

        public Building(
            string unitType,
            int unitCycleLenght,
            ResourceType resourceType,
            int resourceCycleLenght,
            int resourceQuantity,
            IUnitFactory unitFactory,
            IResourceFactory resourceFactory)
        {
            this.unitType = unitType;
            this.unitCycleLenght = unitCycleLenght;
            this.resourceType = resourceType;
            this.resourseCycleLenght = resourceCycleLenght;
            this.resourceQuantity = resourceQuantity;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
        }

        public bool CanProduceResource
        {
            get
            {
                bool canProduceResource = this.cyclesCount > ProdtionDelay &&
                    (this.cyclesCount - ProdtionDelay) % this.resourseCycleLenght == 0;

                return canProduceResource;
            }
        }

        public bool CanProduceUnit
        {
            get
            {
                bool canProduceUnit = this.cyclesCount > ProdtionDelay &&
                    (this.cyclesCount - ProdtionDelay) % this.unitCycleLenght == 0;

                return canProduceUnit;
            }

        }

        public IResourse ProduceResource()
        {
            var resource = this.resourceFactory.CreateResource(this.resourceType, this.resourceQuantity);

            return resource;
        }

        public IUnit ProduceUnit()
        {
            var unit = this.unitFactory.CreateUnit(this.unitType);

            return unit;
        }

        public void Update()
        {
            this.cyclesCount++;
        }

        public override string ToString()
        {
            int turnsUntilResourc = this.resourseCycleLenght - ((this.cyclesCount - ProdtionDelay) % this.resourseCycleLenght);
            int turnsUntilUnit = this.unitCycleLenght - ((this.cyclesCount - ProdtionDelay) % this.unitCycleLenght);
            var result =
                string.Format("{0}: {1} turns ({2}, turns until {3}, {4} turns until {5})",
                this.GetType().Name,
                this.cyclesCount - ProdtionDelay,
                turnsUntilUnit,
                this.unitType,
                turnsUntilResourc,
                this.resourceType);

            return result;
        }
    }
}

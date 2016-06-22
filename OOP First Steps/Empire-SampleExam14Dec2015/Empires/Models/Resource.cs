using Empires.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Enums;

namespace Empires.Models
{
    public class Resource : IResourse
    {
        public Resource(ResourceType type, int quantity)
        {
            this.ResourceType = type;
            this.Quantity = quantity;
        }

        public int Quantity { get; }

        public ResourceType ResourceType { get; }
    }
}

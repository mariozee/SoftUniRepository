using Empires.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Interfaces
{
    public interface IResourceFactory
    {
        IResourse CreateResource(ResourceType resourceType, int quantity);
    }
}

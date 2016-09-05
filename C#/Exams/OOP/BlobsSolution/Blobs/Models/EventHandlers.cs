using Blobs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Models
{   
    public delegate void OnToggleBehaviorEventHandler(IBlob sender, EventArgs eventArgs);

    public delegate void OnBlobDeathEventHandler(IBlob sender, EventArgs eventArgs);
}

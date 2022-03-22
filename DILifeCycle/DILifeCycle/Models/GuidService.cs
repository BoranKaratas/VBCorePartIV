using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DILifeCycle.Models
{
    public class GuidService
    {
        public Guid ScopedGuid { get; set; }
        public Guid SingletonGuid { get; set; }
        public Guid TransientGuid { get; set; }
        public GuidService(IScoped scoped, ISingleton singleton, ITransient transient)
        {
            ScopedGuid = scoped.GetGuid();
            SingletonGuid = singleton.GetGuid();
            TransientGuid = transient.GetGuid();
        }
    }
}

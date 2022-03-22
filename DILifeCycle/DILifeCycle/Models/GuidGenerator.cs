using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DILifeCycle.Models
{

    public interface IGuidGenerator
    {
        Guid GetGuid();
    }

    public interface IScoped:IGuidGenerator
    {

    }

    public interface ISingleton: IGuidGenerator
    {

    }

    public interface ITransient: IGuidGenerator
    {

    }

    public class Scoped : IScoped
    {
        private Guid guid;
        public Scoped()
        {
            guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return guid;
        }
    }

    public class Singleton : ISingleton
    {
        private Guid guid;
        public Singleton()
        {
            guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return guid;
        }
    }

    public class Transient : ITransient
    {
        private Guid guid;

        public Transient()
        {
            guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return guid;
        }
    }
}

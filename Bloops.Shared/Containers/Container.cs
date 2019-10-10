using System.Collections.Generic;

namespace Bloops.Shared.Containers
{
    public abstract class Container<T>
    {
        protected Dictionary<int, T> Dictionary { get; set; }

        public Container()
        {
            Dictionary = new Dictionary<int, T>();
            Initialize();
        }

        protected abstract void Initialize();

        public T Get(int id)
        {
            return Dictionary[id];
        }
    }
}

using Bloops.Shared.Entities;
using System.Collections.Generic;

namespace Bloops.Shared
{
    public class ObjectRepository
    {
        public static ObjectRepository Instance
        {
            get { return _instance.Value; }
        }
        private static System.Lazy<ObjectRepository> _instance = 
            new System.Lazy<ObjectRepository>(() => new ObjectRepository());

        private Dictionary<int, Object> Objects { get; }

        private ObjectRepository()
        {
            Objects = new Dictionary<int, Object>();
        }

        public Object Get(int id)
        {
            if (Objects.TryGetValue(id, out Object obj))
            {
                return obj;
            }
            return null;
        }

        public void Register(Object obj)
        {
            Objects[obj.Id] = obj;
        }
    }
}

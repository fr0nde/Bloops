using Bloops.Shared.Entities;
using System.Collections.Generic;

namespace Bloops.Shared.Containers
{
    public class ItemContainer : Container<Item>
    {
        protected override void Initialize()
        {
            Dictionary = new Dictionary<int, Item>();
        }
    }
}

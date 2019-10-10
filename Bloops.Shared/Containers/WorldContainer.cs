using System.Collections.Generic;
using Bloops.Shared.Entities;

namespace Bloops.Shared.Containers
{
    public class WorldContainer : Container<World>
    {
        protected override void Initialize()
        {
            Dictionary = new Dictionary<int, World>() {
                {1, new World(1, "Plaine")},
                {2, new World(2, "Fôret Magique")},
                {3, new World(3, "Désert")},
                {4, new World(4, "Océan")},
                {5, new World(5, "Neige")},
                {6, new World(6, "Cave")},
                {7, new World(7, "Volcan")}
            };
        }
    }
}

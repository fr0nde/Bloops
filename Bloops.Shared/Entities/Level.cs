using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bloops.Shared.Entities
{
    /// <summary>
    /// Niveau.
    /// </summary>
    public class Level
    {
        /// <summary>
        /// Sérialisation d'un niveau.
        /// </summary>
        /// <param name="level">Niveau.</param>
        /// <returns>JSON.</returns>
        public static string Serialize(Level level)
        {
            return JsonConvert.SerializeObject(level);
        }

        /// <summary>
        /// Désérialisation d'un niveau.
        /// </summary>
        /// <param name="json">JSON.</param>
        /// <returns>Niveau.</returns>
        public static Level Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Level>(json);
        }

        /// <summary>
        /// Position de départ.
        /// </summary>
        public int StartPosition { get; set; }

        /// <summary>
        /// Position de fin.
        /// </summary>
        public int EndPosition { get; set; }

        /// <summary>
        /// Gravité.
        /// </summary>
        public int Gravity { get; set; }

        /// <summary>
        /// Liste d'obstacles.
        /// </summary>
        public List<Obstacle> Obstacles { get; set; }
    }
}

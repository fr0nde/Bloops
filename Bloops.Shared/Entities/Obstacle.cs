using Newtonsoft.Json;
using System;

namespace Bloops.Shared.Entities
{
    /// <summary>
    /// Obstacle.
    /// </summary>
    public class Obstacle
    {
        /// <summary>
        /// Identifiant de l'objet.
        /// </summary>
        public int ObjectId
        {
            get { return _objectId; }
            set
            {
                _objectId = value;
                _object = null;
            }
        }
        private int _objectId;

        /// <summary>
        /// Objet.
        /// </summary>
        [JsonIgnore]
        public Object Object
        {
            get
            {
                if (_object == null)
                {
                    _object = ObjectRepository.Instance.Get(ObjectId);
                }
                return _object;
            }
        }
        private Object _object;

        /// <summary>
        /// Position.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Rotation.
        /// </summary>
        public int Rotation { get; set; }
    }
}

using GTA;
using GTA.Math;

namespace GTATest.Architecture
{
    public class Sketch
    {
        /// <summary>
        /// Initializes an instance of the <see cref="Sketch"/> class.
        /// </summary>
        /// <param name="entity">The entity object.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <param name="position">The position.</param>
        public Sketch(Entity entity, Blueprint parent, string name, Position<Vector3> position)
        {
            Entity = entity;
            Parent = parent;
            Name = name;
            Position = position;
        }

        /// <summary>
        /// Gets the <see cref="Entity"/> of this <see cref="Sketch"/>.
        /// </summary>
        public Entity Entity { get; }

        /// <summary>
        /// Gets the parent <see cref="Blueprint"/> of this <see cref="Sketch"/>.
        /// </summary>
        public Blueprint Parent { get; }

        /// <summary>
        /// Gets the name of this <see cref="Sketch"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the locations of this <see cref="Sketch"/>.
        /// </summary>
        public Position<Vector3> Position { get; }
    }

}

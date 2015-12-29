using GTA.Math;

namespace GTATest.Architecture
{
    /// <summary>
    /// Represents a position which is more exact than a <see cref="Vector3"/> or <see cref="Vector2"/>.
    /// </summary>
    public class Position<T> where T : struct
    {
        /// <summary>
        /// Initializes an instance of the <see cref="Position{T}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="heading">The heading.</param>
        public Position(string name, T location, T rotation, float heading)
        {
            Name = name;
            Location = location;
            Rotation = rotation;
            Heading = heading;
        }

        /// <summary>
        /// Gets the name of this <see cref="Position{T}"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the position of this <see cref="Position{T}"/>.
        /// </summary>
        public T Location { get; }

        /// <summary>
        /// Gets the rotation of this <see cref="Position{T}"/>.
        /// </summary>
        public T Rotation { get; }

        /// <summary>
        /// Gets the heading of this <see cref="Position{T}"/>.
        /// </summary>
        public float Heading { get; }
    }
}

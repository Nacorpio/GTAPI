using GTA.Math;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Vector3"/>.
    /// </summary>
    public class JVector3 : JSerializable<JVector3, Vector3>
    {
        /// <summary>
        /// Initializes an instance of the JVector3 class.
        /// </summary>
        /// <param name="vector">The vector.</param>
        public JVector3(Vector3 vector) : base(vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        /// <summary>
        /// Gets the X-coordinate of this JVector3.
        /// </summary>
        public float X { get; }

        /// <summary>
        /// Gets the Y-coordinate of this JVector3.
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// Gets the Z-coordinate of this JVector3.
        /// </summary>
        public float Z { get; }
    }
}

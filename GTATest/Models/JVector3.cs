using GTA.Math;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Vector3"/>.
    /// </summary>
    public class JVector3 : JsonModel<Vector3>
    {
        /// <summary>
        /// Initializes an instance of the JVector3 class.
        /// </summary>
        /// <param name="vector">The vector.</param>
        public JVector3(Vector3 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        /// <summary>
        /// Creates an instance of this <see cref="JsonModel{T}"/>.
        /// </summary>
        public override Vector3 Create()
        {
            return new Vector3(X, Y, Z);
        }

        /// <summary>
        /// Gets the X-coordinate of this JVector3.
        /// </summary>
        [JsonProperty("x", Order=0)]
        public float X { get; }

        /// <summary>
        /// Gets the Y-coordinate of this JVector3.
        /// </summary>
        [JsonProperty("y", Order=1)]
        public float Y { get; }

        /// <summary>
        /// Gets the Z-coordinate of this JVector3.
        /// </summary>
        [JsonProperty("z", Order=2)]
        public float Z { get; }
    }
}

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
        /// Gets the X-coordinate of this JVector3.
        /// </summary>
        [JsonProperty("x")]
        public float X { get; }

        /// <summary>
        /// Gets the Y-coordinate of this JVector3.
        /// </summary>
        [JsonProperty("y")]
        public float Y { get; }

        /// <summary>
        /// Gets the Z-coordinate of this JVector3.
        /// </summary>
        [JsonProperty("z")]
        public float Z { get; }
    }
}

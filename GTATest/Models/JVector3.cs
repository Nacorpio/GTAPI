using System;
using GTA.Math;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Vector3"/>.
    /// </summary>
    public struct JVector3
    {
        /// <summary>
        /// Initializes an instance of the JVector3 structure.
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
        public float X { get; }

        /// <summary>
        /// Gets the Y-coordinate of this JVector3.
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// Gets the Z-coordinate of this JVector3.
        /// </summary>
        public float Z { get; }

        /// <summary>
        /// Converts the specified <see cref="Vector3"/> to a <see cref="JVector3"/>.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public static JVector3 ToJVector3(Vector3 vector)
        {
            return new JVector3(vector);
        }

        /// <summary>
        /// Converts this <see cref="JVector3"/> to a JSON-serialized string.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}

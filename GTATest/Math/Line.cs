using System.Drawing;
using GTA.Math;
using GTA.Native;

namespace GTATest.Math
{
    public class Line
    {
        /// <summary>
        /// Defines a new Line.
        /// </summary>
        /// <param name="p1">The first point.</param>
        /// <param name="p2">The second point.</param>
        /// <param name="color">The color.</param>
        public Line(Vector3 p1, Vector3 p2, Color color)
        {
            Point1 = p1;
            Point2 = p2;
            Color = color;
        }

        /// <summary>
        /// Returns the first point of this Line.
        /// </summary>
        public Vector3 Point1 { get; set; }

        /// <summary>
        /// Returns the second point of this Line.
        /// </summary>
        public Vector3 Point2 { get; set; }

        /// <summary>
        /// Returns the Color of this Line.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Returns the length between the two points.
        /// </summary>
        /// <returns></returns>
        public float Length()
        {
            return Point1.DistanceTo(Point2);
        }

        /// <summary>
        /// Draws this Line.
        /// </summary>
        public void Draw()
        {
            Function.Call(Hash.DRAW_LINE,
                Point1.X, Point1.Y, Point1.Z,
                Point2.X, Point2.Y, Point2.Z,
                Color.R, Color.G, Color.B, Color.A
            );
        }
    }
}
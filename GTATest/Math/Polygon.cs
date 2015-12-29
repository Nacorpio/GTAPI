using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GTA;
using GTA.Math;

namespace GTATest.Math
{
    public class Polygon
    {
        private Color _color = Color.Red;

        /// <summary>
        /// Defines a new Polygon.
        /// </summary>
        public Polygon()
        { }

        /// <summary>
        /// Connects a new Line to the last point of this Polygon.
        /// </summary>
        /// <param name="point">The point.</param>
        public void Line(Vector3 point)
        {

            if (Lines.Count == 0 && Points.Count == 0)
            {

                Vector3 pos = point;

                Lines.Add(new Line(pos, point, Color));

                Points.Add(pos);
                Points.Add(point);

                return;

            }

            Points.Add(point);
            Lines.Add(new Line(Lines[Lines.Count - 1].Point2, point, Color));

        }

        /// <summary>
        /// Draws this Polygon.
        /// </summary>
        public void Draw()
        {
            Lines.ForEach(l => l.Draw());
        }

        /// <summary>
        /// Returns the Color of this Polygon.
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                Lines.ForEach(l => l.Color = value);
            }
        }

        /// <summary>
        /// Returns the first point of this Polygon.
        /// </summary>
        public Vector3 StartingPoint => Points[0];

        /// <summary>
        /// Returns the lines of this Polygon.
        /// </summary>
        public List<Line> Lines { get; } = new List<Line>();

        /// <summary>
        /// Returns the points of this Polygon.
        /// </summary>
        public List<Vector3> Points { get; } = new List<Vector3>();

        /// <summary>
        /// Returns whether the specified array of Vector3 is within the bounds of this Polygon.
        /// </summary>
        /// <param name="positions">The array of Vector3.</param>
        /// <returns></returns>
        public bool IsWithin(params Vector3[] positions)
        {
            return positions.ToList().All(IsWithin);
        }

        /// <summary>
        /// Returns whether the specified Polygon is within the bounds of this Polygon.
        /// </summary>
        /// <param name="poly">The Polygon.</param>
        /// <returns></returns>
        public bool IsWithin(Polygon poly)
        {
            return poly.Lines.All(poly.IsWithin);
        }

        /// <summary>
        /// Returns whether the specified Line is within the bounds of this Polygon.
        /// </summary>
        /// <param name="line">The Line.</param>
        /// <returns></returns>
        public bool IsWithin(Line line)
        {
            return IsWithin(line.Point1) && IsWithin(line.Point2);
        }

        /// <summary>
        /// Returns whether the specified Vector3 is within the bounds of this Polygon.
        /// </summary>
        /// <param name="pos">The Vector3.</param>
        /// <returns></returns>
        public bool IsWithin(Vector3 pos)
        {
            return Math3D.IsPointInPolygon(Points.ToArray(), pos);
        }

        /// <summary>
        /// Returns whether the specified Entity is within the bounds of this Polygon.
        /// </summary>
        /// <param name="entity">The Entity.</param>
        /// <returns></returns>
        public bool IsWithin(Entity entity)
        {
            return IsWithin(entity.Position);
        }

        /// <summary>
        /// Returns whether this Polygon has its start- and end point connected.
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return Lines[Lines.Count - 1].Point2 == StartingPoint;
        }
    }
}
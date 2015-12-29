using System.Drawing;
using System.Linq;
using GTA;
using GTA.Math;
using GTA.Native;

namespace GTATest.Math
{
    public static class Math3D
    {

        public const string PolygonPath = "BigTime/Polygons";
        public const string StructurePath = "BigTime/Structures";
        public const string PositionsPath = "BigTime/Positions";

        public static Vector3 Translate(Vector3 points3D, Vector3 oldOrigin, Vector3 newOrigin)
        {
            //Moves a 3D point based on a moved reference point
            Vector3 difference = new Vector3(newOrigin.X - oldOrigin.X, newOrigin.Y - oldOrigin.Y, newOrigin.Z - oldOrigin.Z);
            points3D.X += difference.X;
            points3D.Y += difference.Y;
            points3D.Z += difference.Z;
            return points3D;
        }

        public static Vector2 World3DToVector2D(Vector3 pos)
        {
            Point pt = World3DToScreen2D(pos);
            return new Vector2(pt.X, pt.Y);
        }

        public static Point World3DToScreen2D(Vector3 pos)
        {

            OutputArgument x2Dp = new OutputArgument(),
                           y2Dp = new OutputArgument();

            Function.Call<bool>(Hash._WORLD3D_TO_SCREEN2D, pos.X, pos.Y, pos.Z, x2Dp, y2Dp);
            return new Point((int)(UI.WIDTH * x2Dp.GetResult<float>()), (int)(UI.HEIGHT * y2Dp.GetResult<float>()));

        }

        public static Vector3[] Translate(Vector3[] points3D, Vector3 oldOrigin, Vector3 newOrigin)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = Translate(points3D[i], oldOrigin, newOrigin);
            }
            return points3D;
        }

        public static Vector3 RotateX(Vector3 point3D, float degrees)
        {
            double cDegrees = (System.Math.PI * degrees) / 180.0f; //Convert degrees to radian for .Net Cos/Sin functions
            double cosDegrees = System.Math.Cos(cDegrees);
            double sinDegrees = System.Math.Sin(cDegrees);

            float y = (float)((point3D.Y * cosDegrees) + (point3D.Z * sinDegrees));
            float z = (float)((point3D.Y * -sinDegrees) + (point3D.Z * cosDegrees));

            return new Vector3(point3D.X, y, z);
        }

        public static Vector3 RotateY(Vector3 point3D, float degrees)
        {
            double cDegrees = (System.Math.PI * degrees) / 180.0; //Radians
            double cosDegrees = System.Math.Cos(cDegrees);
            double sinDegrees = System.Math.Sin(cDegrees);

            float x = (float)((point3D.X * cosDegrees) + (point3D.Z * sinDegrees));
            float z = (float)((point3D.X * -sinDegrees) + (point3D.Z * cosDegrees));

            return new Vector3(x, point3D.Y, z);
        }

        public static Vector3 RotateZ(Vector3 point3D, float degrees)
        {
            double cDegrees = (System.Math.PI * degrees) / 180.0; //Radians
            double cosDegrees = System.Math.Cos(cDegrees);
            double sinDegrees = System.Math.Sin(cDegrees);

            float x = (float)((point3D.X * cosDegrees) + (point3D.Y * sinDegrees));
            float y = (float)((point3D.X * -sinDegrees) + (point3D.Y * cosDegrees));

            return new Vector3(x, y, point3D.Z);
        }

        public static Vector3[] RotateX(Vector3[] points3D, float degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateX(points3D[i], degrees);
            }
            return points3D;
        }

        public static Vector3[] RotateY(Vector3[] points3D, float degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateY(points3D[i], degrees);
            }
            return points3D;
        }

        public static Vector3[] RotateZ(Vector3[] points3D, float degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = RotateZ(points3D[i], degrees);
            }
            return points3D;
        }

        public static Vector3 Rotate(Vector3 point, float angle)
        {
            var q1 = Quaternion.RotationAxis(point, angle);
            return new Vector3(q1.X, q1.Y, q1.Z);
        }

        public static bool IsPointInPolygon(Vector3[] polygon, Vector3 point)
        {
            var isInside = false;
            for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }

        public static bool IsInPolygon(Vector3[] poly, Vector3 point)
        {
            var coef = poly.Skip(1).Select((p, i) =>
                (point.Y - poly[i].Y) * (p.X - poly[i].X)
                - (point.X - poly[i].X) * (p.Y - poly[i].Y))
                .ToList();

            if (coef.Any(p => p == 0))
                return true;

            for (int i = 1; i < coef.Count(); i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                    return false;
            }
            return true;
        }

        public static Vector2 RotateAroundVector2(Vector3 p1, Vector3 p2, float angle)
        {
            return RotateAroundVector2(new Vector2(p1.X, p1.Y), new Vector2(p2.X, p2.Y), angle);
        }

        public static Vector3 RotateAroundVector3(Vector3 p1, Vector3 p2, float angle)
        {
            var vec = RotateAroundVector2(p1, p2, angle);
            return new Vector3(vec.X, vec.Y, 0);
        }

        public static Vector2 RotateAroundVector2(Vector2 p1, Vector2 p2, float angle)
        {
            float x = (float)(System.Math.Cos(angle) * (p1.X - p2.X) - System.Math.Sin(angle) * (p1.Y - p2.Y) + p1.X);
            float y = (float)(System.Math.Sin(angle) * (p1.X - p2.X) - System.Math.Cos(angle) * (p1.Y - p2.Y) + p1.Y);
            return new Vector2(x, y);
        }

        public static Vector3 QuaternionToEulerAngles(GTA.Math.Quaternion q)
        {
            var t = q.X * q.Y + q.Z * q.W;
            if (t > 0.499)
            {
                return new Vector3((float)(2 * System.Math.Atan2(q.X, q.W)), (float)(System.Math.PI / 2), 0);
            }
            else if (t < -0.499)
            {
                return new Vector3((float)(-2 * System.Math.Atan2(q.X, q.W)), (float)(-System.Math.PI / 2), 0);
            }
            else
            {
                return new Vector3((float)System.Math.Atan2(2 * q.Y * q.W - 2 * q.X * q.Z, 1 - 2 * q.Y * q.Y - 2 * q.Z * q.Z),
                    (float)System.Math.Asin(2 * t),
                    (float)System.Math.Atan2(2 * q.X * q.W - 2 * q.Y * q.Z, 1 - 2 * q.X * q.X - 2 * q.Z * q.Z));
            }
        }

        /// <summary>
        /// Returns the specified Vector3 in a text representation.
        /// </summary>
        /// <param name="vector">The Vector3.</param>
        /// <returns></returns>
        public static string ToString(Vector3 vector)
        {
            return "(" + vector.X + ", " + vector.Y + ", " + vector.Z + ")";
        }

        /// <summary>
        /// Returns the specified Vector2 in a text representation.
        /// </summary>
        /// <param name="vector">The Vector2.</param>
        /// <returns></returns>
        public static string ToString(Vector2 vector)
        {
            return "(" + vector.X + ", " + vector.Y + ")";
        }

        /// <summary>
        /// Converts the specified String to a Vector3.
        /// </summary>
        /// <param name="str">The text representation.</param>
        /// <returns></returns>
        public static Vector3 ToVector3(string str)
        {

            var result = str.Trim().Split('(')[1].Split(')')[0];
            var parts = result.Split(',');

            return new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]));

        }

    }
}
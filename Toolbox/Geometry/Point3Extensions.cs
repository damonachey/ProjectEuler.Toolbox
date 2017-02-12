namespace ProjectEuler.Toolbox
{
    public static class Point3Extensions
    {
        public static Point3double Cross(this Point3double p1, Point3double p2) =>
            new Point3double(
                p1.Y * p2.Z - p1.Z * p2.Y,
                p1.Z * p2.X - p1.X * p2.Z,
                p1.X * p2.Y - p1.Y * p2.X
                );

        public static double Dot(this Point3double p1, Point3double p2) =>
            p1.X * p2.X + p1.Y * p2.Y + p1.Z * p2.Z;
    }
}

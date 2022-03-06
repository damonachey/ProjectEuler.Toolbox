namespace ProjectEuler.Toolbox;

public static class Circle2Extensions
{
    public static double Area(this Circle2double c) =>
        Math.PI * c.R * c.R;

    public static double Circumfrence(this Circle2double c) =>
        2 * Math.PI * c.R;

    public static double ChordAngle(double length, double radius) =>
        2 * Math.Asin((length / 2) / radius);

    public static double SegmentArea(double angle, double radius) =>
        (radius * radius) / 2 * (angle - Math.Sin(angle));
}

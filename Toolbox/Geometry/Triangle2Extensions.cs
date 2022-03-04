namespace ProjectEuler.Toolbox;

public static class Triangle2Extensions
{
    public static double Area(this Triangle2double t) =>
        0.5 * Math.Abs(
            (t.P1.X - t.P3.X) *
            (t.P2.Y - t.P1.Y) -
            (t.P1.X - t.P2.X) *
            (t.P3.Y - t.P1.Y));
}

namespace ProjectEuler.Toolbox;

public struct Circle2double : IEquatable<Circle2double>
{
    public Point2double C { get; }
    public double R { get; }

    public Circle2double(Point2double c, double r)
    {
        C = c;
        R = r;
    }

    public double Area => Math.PI * R * R;

    public double Circumfrence => 2 * Math.PI * R;

    public override string ToString() => $"{C} R = {R}";

    public override bool Equals(object? obj) => obj is Circle2double p && Equals(p);

    public bool Equals(Circle2double other) => C == other.C && R == other.R;

    public override int GetHashCode() => C.GetHashCode() ^ R.GetHashCode();

    public static bool operator ==(Circle2double c1, Circle2double c2) => c1.Equals(c2);

    public static bool operator !=(Circle2double c1, Circle2double c2) => !c1.Equals(c2);
}

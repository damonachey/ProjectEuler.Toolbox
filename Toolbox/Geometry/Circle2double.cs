namespace ProjectEuler.Toolbox;

public readonly record struct Circle2double(Point2double C, double R)
{ 
    public double Area => Math.PI * R * R;

    public double Circumfrence => 2 * Math.PI * R;

    public override string ToString() => $"{C} R = {R}";
}

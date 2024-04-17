using System.Numerics;

namespace ProjectEuler.Toolbox;

public readonly record struct Circle2<T>(Point2<T> C, T R) where T : IFloatingPoint<T>
{ 
    public T Area => T.Pi * R * R;

    public T Circumference => T.Tau * R;
    
    public override string ToString() => $"{C} R = {R}";
}

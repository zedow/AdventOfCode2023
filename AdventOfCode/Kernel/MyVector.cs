using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Kernel;

public class MyVector(int x, int y) : IEquatable<MyVector>
{
    public int X = x;
    public int Y = y;

    public static MyVector operator *(MyVector a, MyVector b) => new(a.X * b.X, b.Y * a.Y);
    public static MyVector operator /(MyVector a, MyVector b) => new(a.X / b.X, b.Y / a.Y);
    public static MyVector operator +(MyVector a, MyVector b) => new(a.X + b.X, a.Y + b.Y);
    public static MyVector operator -(MyVector a, MyVector b) => new(a.X - b.X, a.Y - b.Y);
    public static bool operator !=(MyVector a, MyVector b) => a.X != b.X || a.Y != b.Y;
    public static bool operator ==(MyVector a, MyVector b) => a.X == b.X && a.Y == b.Y;
    public static MyVector operator -(MyVector a) => new(a.X * - 1, a.Y * -1);
    public static MyVector Abs(MyVector vector) => new(Math.Abs(vector.X), Math.Abs(vector.Y));
    public MyVector SafeDivideBy(MyVector other) 
        => new(other.X == 0 ? 0 : X / other.X, other.Y == 0 ? 0 : Y / other.Y); 
    public static MyVector Left => new(-1,0);
    public static MyVector Right => new(1,0);
    public static MyVector Up => new(0,-1);
    public static MyVector Down => new(0,1);
    public static MyVector[] Directions => [Left,Right,Up,Down];
    public override string ToString() => $"<{X},{Y}>";

    public bool Equals(MyVector? other)
    {
        return other?.X == X && other?.Y == Y;
    }

    public override bool Equals(object obj) => Equals(obj as MyVector);
    public override int GetHashCode() => (X,Y).GetHashCode();
}


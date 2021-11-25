using UnityEngine;

[System.Serializable]
public struct MyVector3
{
    public float X, Y, Z;

    public float Magnitude => Mathf.Sqrt(SqrMagnitude);
    public float SqrMagnitude => X*X + Y*Y + Z*Z;
    public MyVector3 Normalized => this*(1.0f/Magnitude);
    
    public MyVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public MyVector3 Add(in MyVector3 other)
    {
        return new MyVector3(X + other.X, Y + other.Y, Z + other.Z);
    }

    public MyVector3 ScaleBy(float a)
    {
        return new MyVector3(X * a, Y * a, Z * a);
    }

    public static MyVector3 operator +(in MyVector3 a, in MyVector3 b)
    {
        return a.Add(b);
    }

    public static MyVector3 operator *(in MyVector3 v, float a)
    {
        return v.ScaleBy(a);
    }

    public static implicit operator Vector3(MyVector3 vec)
    {
        return new Vector3(vec.X, vec.Y, vec.Z);
    }
}


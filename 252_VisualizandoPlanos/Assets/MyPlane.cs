using UnityEngine;

[System.Serializable]
public struct MyPlane
{
    public Vector3 Point;
    public Vector3 Normal;

    public float Distance => Vector3.Dot(Point, Normal);

    public MyPlane(in Vector3 p1, in Vector3 p2, in Vector3 p3)
    {
        Point = p1;
        Normal = Vector3.Cross(p2 - p1, p3 - p1).normalized;
    }

    public bool IsInFront(in Vector3 p)
    {
        return Vector3.Dot(p, Normal) > Distance;
    }

    public Vector3 ProjectVector(in Vector3 vec)
    {
        return vec - Vector3.Dot(vec, Normal) * Normal;
    }

    public Vector3 ProjectPoint(in Vector3 p)
    {
        return Point + ProjectVector(p - Point);
    }
}

using UnityEngine;

[System.Serializable]
public struct MyPlane
{
    public Vector3 Point;
    public Vector3 Normal;

    public MyPlane(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Point = p1;
        Normal = Vector3.Cross(p2 - p1, p3 - p1).normalized;
    }

    public Vector3 ProjectVector(in Vector3 vec)
    {
        return vec - Vector3.Dot(vec, Normal) * Normal;
    }
}

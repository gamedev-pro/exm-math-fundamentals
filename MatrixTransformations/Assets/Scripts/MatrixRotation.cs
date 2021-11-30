using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixRotation : MeshTransformation
{
    [SerializeField] private float rotZ;
    public override void TransformPoints(Vector3[] points)
    {
        var sinZ = Mathf.Sin(rotZ * Mathf.Deg2Rad);
        var cosZ = Mathf.Cos(rotZ * Mathf.Deg2Rad);
        var rotZMatrix = new Matrix3x3(cosZ, -sinZ, 0, sinZ, cosZ, 0, 0, 0, 1);
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = rotZMatrix * points[i];
        }
    }
}

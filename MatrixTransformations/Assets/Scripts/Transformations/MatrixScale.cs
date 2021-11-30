using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixScale : MeshTransformation
{
    [SerializeField] private Vector3 scale = Vector3.one;
    public override void TransformPoints(Vector3[] points)
    {
        var scaleMatrix = new Matrix3x3(scale.x, 0, 0, 0, scale.y, 0, 0, 0, scale.z);
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = scaleMatrix * points[i];
        }
    }
}

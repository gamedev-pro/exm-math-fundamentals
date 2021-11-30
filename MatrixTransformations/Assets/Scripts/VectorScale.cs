using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorScale : MeshTransformation
{
    [SerializeField] private Vector3 scale = Vector3.one;
    public override void TransformPoints(Vector3[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            ref var point = ref points[i];
            point.x *= scale.x;
            point.y *= scale.y;
            point.z *= scale.z;
        }
    }
}

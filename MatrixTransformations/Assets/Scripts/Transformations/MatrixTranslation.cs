using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTranslation : MeshTransformation
{
    [SerializeField]
    private Vector3 translation;

    public override void TransformPoints(Vector3[] points)
    {
        var translationMatrix = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(translation.x, translation.y, translation.z, 1)
        );

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = translationMatrix.MultiplyPoint(points[i]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlaneOperation
{
    None, VectorProjection
}

public class PlaneVisualizer : MonoBehaviour
{
    [SerializeField] private Vector3 p1, p2, p3;

    [SerializeField] private Vector3 vec;
    [SerializeField] private PlaneOperation operation;

    private const float vecThickness = 5;

    private void OnDrawGizmos()
    {
        var plane = new MyPlane(p1, p2, p3);
        DrawBase();
        DrawPlanePoints();

        if (operation == PlaneOperation.VectorProjection)
        {
            DrawVectorProjection(plane);
        }

        DrawPlane(plane);
    }

    private void DrawVectorProjection(in MyPlane plane)
    {
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(p1, vec, vecThickness);

        Gizmos.color = Color.blue;
        var projected = plane.ProjectVector(vec);
        GizmosUtils.DrawVector(p1, projected, vecThickness * 0.5f);

        var projectedNormal = projected - vec;
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(p1 + vec, projectedNormal, 0.1f);
    }

    private void DrawPlane(in MyPlane plane)
    {
        Gizmos.color = Color.white;
        GizmosUtils.DrawVectorAtOrigin(p1, 0.1f);

        var size = Mathf.Max((p2 - p1).magnitude, (p3 - p1).magnitude);
        GizmosUtils.DrawPlane(plane, Vector2.one * size * 2);

        Gizmos.color = Color.magenta;
        GizmosUtils.DrawVector(p1, plane.Normal, vecThickness);
    }

    private void DrawPlanePoints()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(p1, 0.1f);
        Gizmos.DrawSphere(p2, 0.1f);
        Gizmos.DrawSphere(p3, 0.1f);
    }

    private void DrawBase()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(Vector3.right, vecThickness);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(Vector3.up, vecThickness);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVectorAtOrigin(Vector3.forward, vecThickness);
    }
}

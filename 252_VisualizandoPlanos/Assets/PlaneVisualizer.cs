using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlaneOperation
{
    None, IsInFront, ProjectDirection, ProjectPoint
}

public class PlaneVisualizer : MonoBehaviour
{
    [SerializeField] private Vector3 p1, p2, p3;

    [SerializeField] private Vector3 point;
    [SerializeField] private PlaneOperation operation;

    private const float vecThickness = 5;

    private void OnDrawGizmos()
    {
        var plane = new MyPlane(p1, p2, p3);
        DrawBase();

        if (plane.IsInFront(point))
        {
            DrawPlane(plane);
            DrawPlaneOperation(plane);
        }
        else
        {
            DrawPlaneOperation(plane);
            DrawPlane(plane);
        }
    }

    private void DrawPlaneOperation(in MyPlane plane)
    {
        switch (operation)
        {
            case PlaneOperation.IsInFront:
                DrawIsInFront(plane);
                break;
            case PlaneOperation.ProjectDirection:
                DrawVectorProjection(plane);
                break;
            case PlaneOperation.ProjectPoint:
                DrawPointProjection(plane);
                break;
        }
    }

    private void DrawIsInFront(in MyPlane plane)
    {
        Gizmos.color = plane.IsInFront(point) ? Color.green : Color.red;
        Gizmos.DrawSphere(point, 0.1f);
    }

    private void DrawVectorProjection(in MyPlane plane)
    {
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(p1, point, vecThickness);

        Gizmos.color = Color.blue;
        var projected = plane.ProjectVector(point);
        GizmosUtils.DrawVector(p1, projected, vecThickness * 0.5f);

        // vp = v - vn -> vn = -(v - vp) => vn = vp - v

        var projectedNormal = -Vector3.Dot(point, plane.Normal) * plane.Normal;
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(p1 + point, projectedNormal, 0.1f);
    }

    private void DrawPointProjection(in MyPlane plane)
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(point, 0.1f);

        Gizmos.color = Color.blue;
        var projected = plane.ProjectPoint(point);
        GizmosUtils.DrawVectorAtOrigin(projected, vecThickness * 0.5f);
        Gizmos.DrawSphere(projected, 0.1f);

        var projectedNormal = projected - point;
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(point, projectedNormal, 0.1f);
    }

    private void DrawPlane(in MyPlane plane)
    {
        Gizmos.color = Color.white;
        var distanceVec = plane.Distance * plane.Normal;
        GizmosUtils.DrawVectorAtOrigin(distanceVec, 0.1f);

        var size = Mathf.Max((p2 - p1).magnitude, (p3 - p1).magnitude);
        GizmosUtils.DrawPlane(plane.Normal, plane.Point, Vector2.one * size * 2);

        Gizmos.color = Color.magenta;
        GizmosUtils.DrawVector(p1, plane.Normal, vecThickness);

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

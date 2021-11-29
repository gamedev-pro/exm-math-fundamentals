using UnityEngine;

public static class SimpleRenderer
{
    public static void DrawCube(Vector3[] cubePoints)
    {
        for (int i = 1; i < 4; i++)
        {
            var fromPoint = cubePoints[i - 1];
            var toPoint = cubePoints[i];
            Gizmos.DrawLine(fromPoint, toPoint);
        }
        Gizmos.DrawLine(cubePoints[3], cubePoints[0]);

        for (int i = 5; i < 8; i++)
        {
            var fromPoint = cubePoints[i - 1];
            var toPoint = cubePoints[i];
            Gizmos.DrawLine(fromPoint, toPoint);
        }
        Gizmos.DrawLine(cubePoints[7], cubePoints[4]);

        for (int i = 0; i < 4; i++)
        {
            var fromPoint = cubePoints[i];
            var toPoint = cubePoints[i + 4];
            Gizmos.DrawLine(fromPoint, toPoint);
        }

        const float pointSize = 0.1f;
        foreach (var point in cubePoints)
        {
            Gizmos.DrawSphere(point, pointSize);
        }
    }
}

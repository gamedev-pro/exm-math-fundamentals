using UnityEngine;

public static class FieldOfViewUtils
{
    public static bool IsInsideFieldOfView(Vector2 fovOrigin, Vector2 target, float viewDistance, float viewAngle)
    {
        var sqrDist = DistanceBetweenToPoints(fovOrigin, target);
        if (sqrDist > viewDistance)
        {
            return false;
        }
        var frontPoint = new Vector2(fovOrigin.x, target.y);
        var cat = DistanceBetweenToPoints(frontPoint, target);

        var sinAngle = cat / sqrDist;
        var sinHalfViewAngle = Mathf.Sin(Mathf.Deg2Rad * viewAngle * 0.5f);

        return sinAngle <= sinHalfViewAngle;
    }

    private static float DistanceBetweenToPoints(Vector2 a, Vector2 b)
    {
        var dx = a.x - b.x;
        var dy = a.y - b.y;
        return Mathf.Sqrt(dx * dx + dy * dy);
    }
}

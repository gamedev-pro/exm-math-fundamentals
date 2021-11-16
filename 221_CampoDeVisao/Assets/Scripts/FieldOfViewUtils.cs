using UnityEngine;

public static class FieldOfViewUtils
{
    public static bool IsInsideFieldOfView(Vector2 fovOrigin, Vector2 target, float viewDistance, float viewAngle)
    {
        //fovOrigin = posicao do inimigo
        //target = posicao do player

        if (target.y < fovOrigin.y)
        {
            return false;
        }

        var dist = DistanceBetweenToPoints(fovOrigin, target);
        if (dist > viewDistance)
        {
            return false;
        }

        var cat = Mathf.Abs(target.x - fovOrigin.x);
        var sinAngle = cat / dist;//seno de teta
                                  // var teta = Mathf.Asin(sinAngle);
                                  // return teta <= viewAngle * 0.5f;

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

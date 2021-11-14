using UnityEngine;

public static class MathUtils
{
    public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
    {
        return a;
    }
    public static bool LineLineIntersection(Vector2 s1, Vector2 e1, Vector2 s2, Vector2 e2, out Vector2 intersection)
    {
        intersection = Vector2.zero;
        return false;
    }

    public static float InverseLerp(Vector2 a, Vector2 b, Vector2 point)
    {
        return 0;
    }
}

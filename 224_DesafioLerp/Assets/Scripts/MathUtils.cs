using UnityEngine;

public static class MathUtils
{
    public static Vector2 LerpUncampled(Vector2 a, Vector2 b, float t)
    {
        return a + (b - a) * t;
    }

    public static float LerpUncampled(float a, float b, float t)
    {
        return a + (b - a) * t;
    }

    public static void FindLineEquation(Vector2 a, Vector2 b, out float m, out float c)
    {
        m = (b.y - a.y) / (b.x - a.x);
        c = -m * a.x + a.y;
    }
}
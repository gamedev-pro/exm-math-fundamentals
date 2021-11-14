using UnityEngine;

public static class MathUtils
{
    public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
    {
        return a + (b - a) * t;
    }
    public static bool LineLineIntersection(Vector2 s1, Vector2 e1, Vector2 s2, Vector2 e2, out Vector2 intersection)
    {
        var m1 = (e1.y - s1.y) / (e1.x - s1.x);
        var m2 = (e2.y - s2.y) / (e2.x - s2.x);

        if (Mathf.Approximately(m1, m2))
        {
            intersection = Vector2.zero;
            return false;
        }

        var c1 = -m1 * s1.x + s1.y;
        var c2 = -m2 * s2.x + s2.y;

        var intersectX = (c2 - c1) / (m1 - m2);
        var intersectY = m1 * intersectX + c1;

        intersection = new Vector2(intersectX, intersectY);
        return true;
    }

    public static void GetLineEquation(Vector2 lineStart, Vector2 lineEnd, out float m, out float c)
    {
        m = (lineEnd.y - lineStart.y) / (lineEnd.x - lineStart.x);
        c = -m * lineStart.x + lineStart.y;
    }

    public static bool CircleLineIntersection(Vector2 center, float radius, Vector2 lineStart, Vector2 lineEnd, out Vector2 p1, out Vector2 p2)
    {
        GetLineEquation(lineStart, lineEnd, out var m, out var lineC);
        var a = (m * m) + 1;
        var b = 2 * m * (lineC - center.y) - (2 * center.x);
        var c = (center.x * center.x) + (lineC - center.y) * (lineC - center.y) - radius * radius;

        var delta = (b * b) - (4 * a * c);

        if (delta < 0)
        {
            p1 = p2 = Vector2.zero;
            return false;
        }

        var deltaSqrt = Mathf.Sqrt(delta);
        var x1 = (-b + deltaSqrt) / (2 * a);
        var x2 = (-b - deltaSqrt) / (2 * a);

        var y1 = (m * x1) + lineC;
        var y2 = (m * x2) + lineC;

        p1 = new Vector2(x1, y1);
        p2 = new Vector2(x2, y2);

        return true;
    }

    public static bool IsPointInFiniteLine(Vector2 lineStart, Vector2 lineEnd, Vector2 point)
    {
        var t = MathUtils.InverseLerp(lineStart, lineEnd, point);
        return t >= 0 && t <= 1;
    }

    public static float InverseLerp(Vector2 a, Vector2 b, Vector2 point)
    {
        return (point.x - a.x) / (b.x - a.x);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;

    [SerializeField] private float t = 0;

    private const float pointSize = 0.1f;

    private Vector2 A => a.transform.position;
    private Vector2 B => b.transform.position;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(A, new Vector2(B.x, A.y));
        Gizmos.DrawLine(A, new Vector2(A.x, B.y));
        Gizmos.DrawLine(MathUtils.LerpUncampled(A, B, -3), MathUtils.LerpUncampled(A, B, 3));

        Gizmos.color = Color.blue;
        DrawPoint(A);
        DrawPoint(B);
        Gizmos.DrawLine(A, B);

        Gizmos.color = Color.green;
        var lerpPoint = MathUtils.LerpUncampled(A, B, t);
        DrawPoint(lerpPoint);

        Gizmos.color = Color.white;
        var lerpX = MathUtils.LerpUncampled(A.x, B.x, t);
        DrawPoint(new Vector2(lerpX, A.y));

        var lerpY = MathUtils.LerpUncampled(A.y, B.y, t);
        DrawPoint(new Vector2(A.x, lerpY));
    }

    private void DrawPoint(Vector2 position)
    {
        Gizmos.DrawSphere(position, pointSize);
    }
}
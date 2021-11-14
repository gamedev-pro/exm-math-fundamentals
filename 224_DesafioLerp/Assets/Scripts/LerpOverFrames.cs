using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpOverFrames : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;

    [SerializeField] private float moveTime = 1;
    [SerializeField] private float waitTime = 1.5f;

    private const float pointSize = 0.1f;

    private Vector2 A => a.transform.position;
    private Vector2 B => b.transform.position;

    Vector2 lerp1;
    Vector2 lerp2;

    private void Awake()
    {
        StartCoroutine(MovePoints());
    }

    private IEnumerator MovePoints()
    {
        lerp1 = A;
        lerp2 = A;
        var speed = 1.0f / moveTime;
        var t = 0.0f;

        yield return new WaitForSeconds(waitTime);
        while (true)
        {
            t += Time.deltaTime * speed;
            t = Mathf.Clamp01(t);
            lerp1 = MathUtils.LerpUncampled(A, B, t);
            lerp2 = MathUtils.LerpUncampled(lerp2, B, Time.deltaTime * speed);
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        DrawPoint(A);
        DrawPoint(B);

        Gizmos.color = Color.green;
        DrawPoint(lerp1);

        Gizmos.color = Color.red;
        DrawPoint(lerp2);
    }

    private void DrawPoint(Vector2 pos)
    {
        Gizmos.DrawSphere(pos, pointSize);
    }
}

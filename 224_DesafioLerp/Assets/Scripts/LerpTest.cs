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
        Gizmos.color = Color.blue;
        DrawPoint(A);
        DrawPoint(B);
    }

    private void DrawPoint(Vector2 position)
    {
        Gizmos.DrawSphere(position, pointSize);
    }
}
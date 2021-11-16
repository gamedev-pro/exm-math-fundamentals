using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpOverFrames : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;

    [SerializeField] private float moveTime = 2.0f;

    private const float pointSize = 0.1f;

    private Vector2 A => a.position;
    private Vector2 B => b.position;

    private Vector2 pos1;
    private Vector2 pos2;

    private void Awake()
    {
        StartCoroutine(MoveFromAToB());
    }

    private IEnumerator MoveFromAToB()
    {
        pos1 = A;
        pos2 = A;

        yield return new WaitForSeconds(1);

        var speed = 1.0f / moveTime; //v = ds/dt
        var t = 0.0f;

        while (true)
        {
            //Lerp tradicional
            t += Time.deltaTime * speed;
            pos1 = Vector2.Lerp(A, B, t);

            //Lerp recursivo
            pos2 = Vector2.Lerp(pos2, B, Time.deltaTime * speed);
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(A, pointSize);
        Gizmos.DrawSphere(B, pointSize);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(pos1, pointSize);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pos2, pointSize);
    }
}







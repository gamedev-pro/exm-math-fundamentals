using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionLerpVisualizer : MonoBehaviour
{
    [SerializeField] private Vector3 rotFrom;
    [SerializeField] private Vector3 rotTo;

    [SerializeField]
    [Range(0, 1)]
    private float t;

    [SerializeField] private float radius = 1;

    private void OnDrawGizmos()
    {
        var vecToRotate = Vector3.right * radius;//i

        var from = Quaternion.Euler(rotFrom);
        var fromVec = from * vecToRotate;//direcao rotacionada

        var to = Quaternion.Euler(rotTo);
        var toVec = to * vecToRotate;

        var interpolatedRot = Quaternion.Slerp(from, to, t);
        var interpolatedVec = interpolatedRot * vecToRotate;

        const float pointSize = 0.1f;
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position + fromVec, pointSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + toVec, pointSize);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + interpolatedVec, pointSize);

        Color32 color = Color.blue;
        color.a = 125;//0 - 255
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}

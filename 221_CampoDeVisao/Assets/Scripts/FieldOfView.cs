using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float viewDistance = 2;

    [Range(0, 180)]
    [SerializeField] private float viewAngle = 30;
    [SerializeField] private Transform target;

    private void OnDrawGizmos()
    {
        var isVisible = FieldOfViewUtils.IsInsideFieldOfView(transform.position, target.position, viewAngle);

        Gizmos.color = isVisible ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, viewAngle * 0.5f) * Vector3.up * viewDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, -viewAngle * 0.5f) * Vector3.up * viewDistance);
    }
}

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
        var isVisible = FieldOfViewUtils.IsInsideFieldOfView(transform.position, target.position, viewDistance, viewAngle);

        Gizmos.color = isVisible ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
        var xDelta = viewDistance * Mathf.Sin(Mathf.Deg2Rad * viewAngle * 0.5f);
        var yDelta = viewDistance * Mathf.Cos(Mathf.Deg2Rad * viewAngle * 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(xDelta, yDelta, 0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-xDelta, yDelta, 0));
    }
}

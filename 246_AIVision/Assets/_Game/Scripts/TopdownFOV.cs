using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownFOV : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float angle;

#if UNITY_EDITOR
    [SerializeField] private Transform TEST_target;
#endif

    public bool CanSeeTarget(Transform target)
    {
        if (target == null)
        {
            return false;
        }

        var toTarget = (target.position - transform.position);
        if (toTarget.sqrMagnitude > radius * radius)
        {
            return false;
        }

        var dot = Vector3.Dot(toTarget, transform.forward);
        if (dot < 0)
        {
            return false;
        }

        var cosHalfAngleToTarget = dot / (toTarget.magnitude * transform.forward.magnitude);
        var halfAngleToTarget = Mathf.Acos(cosHalfAngleToTarget) * Mathf.Rad2Deg;
        return halfAngleToTarget <= (angle * 0.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = CanSeeTarget(TEST_target) ? Color.green : Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);

        var leftDir = Quaternion.Euler(0, angle * 0.5f, 0) * transform.forward;
        var rightDir = Quaternion.Euler(0, -angle * 0.5f, 0) * transform.forward;

        Gizmos.DrawRay(transform.position, leftDir.normalized * radius);
        Gizmos.DrawRay(transform.position, rightDir.normalized * radius);
    }
}

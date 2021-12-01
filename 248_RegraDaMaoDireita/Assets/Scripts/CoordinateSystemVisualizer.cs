using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Handedness
{
    Left = 1, Right = -1
}

public class CoordinateSystemVisualizer : MonoBehaviour
{
    [SerializeField] private Vector3 v;
    [SerializeField] private Vector3 w;

    [SerializeField] private Handedness handedness;

    [SerializeField] private bool forceOrthogonalSystem = true;

    private void OnDrawGizmos()
    {
        var vCopy = v;
        var wCopy = w;
        var n = Vector3.Cross(v, w) * (int)handedness;

        if (forceOrthogonalSystem)
        {
            vCopy.Normalize();
            n.Normalize();
            wCopy = (Vector3.Cross(n, vCopy) * (int)handedness).normalized;
        }

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(vCopy);

        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(n);

        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(wCopy);
    }
}

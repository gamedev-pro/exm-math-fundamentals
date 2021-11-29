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
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v);

        var n = Vector3.Cross(v, w) * (int)handedness;
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(n);

        if (forceOrthogonalSystem)
        {
            var normalToVAndN = Vector3.Cross(n, v) * (int)handedness;
            Gizmos.color = Color.red;
            GizmosUtils.DrawVectorAtOrigin(normalToVAndN);
        }
        else
        {
            Gizmos.color = Color.green;
            GizmosUtils.DrawVectorAtOrigin(w);
        }
    }
}

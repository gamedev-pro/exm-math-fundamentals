using UnityEngine;

public class LineFollower : MonoBehaviour
{
    [SerializeField] private Transform from;
    [SerializeField] private Transform to;

    [SerializeField] private float t = 0;

    [SerializeField] private Transform wallStart;
    [SerializeField] private Transform wallEnd;

    private const float pointSize = 0.1f;

    private void OnDrawGizmos()
    {
        var playerColor = Color.green;
        if (MathUtils.LineLineIntersection(from.position, to.position, wallStart.position, wallEnd.position, out var intersectPoint))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(intersectPoint, pointSize * 0.5f);
            var intersectT = MathUtils.InverseLerp(from.position, to.position, intersectPoint);
            if (t > intersectT)
            {
                t = intersectT;
                playerColor = Color.red;
            }
        }

        transform.position = MathUtils.LerpUnclamped(from.position, to.position, t);
        Gizmos.color = playerColor;
        Gizmos.DrawSphere(transform.position, pointSize);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(wallStart.position, wallEnd.position);

        Gizmos.color = Color.grey;
        Gizmos.DrawLine(from.position, to.position);
    }
}

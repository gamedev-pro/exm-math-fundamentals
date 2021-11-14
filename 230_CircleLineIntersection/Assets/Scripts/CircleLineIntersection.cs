using UnityEngine;

public class CircleLineIntersection : MonoBehaviour
{
    [Header("Circle")]
    [SerializeField] private Transform circleCenter;
    [SerializeField] private float radius;


    [Header("Line")]
    [SerializeField] private Transform lineStart;
    [SerializeField] private Transform lineEnd;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(circleCenter.position, radius);

        var lineColor = Color.white;

        if (MathUtils.CircleLineIntersection(circleCenter.position, radius, lineStart.position, lineEnd.position, out var p1, out var p2))
        {
            const float pointSize = 0.1f;

            var isP1Valid = MathUtils.IsPointInFiniteLine(lineStart.position, lineEnd.position, p1);
            var isP2Valid = MathUtils.IsPointInFiniteLine(lineStart.position, lineEnd.position, p2);

            lineColor = isP1Valid || isP2Valid ? Color.green : Color.white;

            Gizmos.color = Color.red;
            if (isP1Valid)
            {
                Gizmos.DrawSphere(p1, pointSize);
            }
            if (isP2Valid)
            {
                Gizmos.DrawSphere(p2, pointSize);
            }
        }

        Gizmos.color = lineColor;
        Gizmos.DrawLine(lineStart.position, lineEnd.position);
    }
}
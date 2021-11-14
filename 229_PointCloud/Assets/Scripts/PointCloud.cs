using System.Collections.Generic;
using UnityEngine;

public class PointCloud : MonoBehaviour
{
    [SerializeField] private int pointCount = 500;
    [SerializeField] private float maxDistance = 20;

    private Vector2[] points = new Vector2[0];
    private List<int> outermostPointIndexes = new List<int>();

    public void GeneratePoints()
    {
        points = new Vector2[pointCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = Random.insideUnitCircle * maxDistance;
        }

        outermostPointIndexes = PointCloudChallengeSolution.FindOutermostPointIndexes(Vector2.zero, points);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(Vector2.zero, maxDistance);

        const float pointSize = 0.05f;
        Gizmos.color = Color.white;
        foreach (var p in points)
        {
            Gizmos.DrawSphere(p, pointSize);
        }

        Gizmos.color = Color.green;
        foreach (var index in outermostPointIndexes)
        {
            var point = points[index];
            Gizmos.DrawSphere(point, pointSize);
        }
    }
}

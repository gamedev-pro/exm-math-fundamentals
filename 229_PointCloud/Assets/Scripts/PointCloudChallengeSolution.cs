using System.Collections.Generic;
using UnityEngine;

public static class PointCloudChallengeSolution
{
    private struct Plane
    {
        public Vector2 Point;
        public Vector2 Normal;

        public bool IsPointInFrontOfPlane(Vector2 point)
        {
            var dir = point - Point;
            return Vector2.Dot(dir, Normal) >= 0;
        }
    }

    public static List<int> FindOutermostPointIndexes(Vector2 center, Vector2[] points)
    {
        var edgePoints = new List<int>();
        for (var i = 0; i < points.Length; i++)
        {
            var planeForPoint = new Plane
            {
                Point = points[i],
                Normal = points[i] - center
            };

            var isEdgePoint = true;
            for (var j = 0; j < points.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                if (planeForPoint.IsPointInFrontOfPlane(points[j]))
                {
                    isEdgePoint = false;
                    break;
                }
            }

            if (isEdgePoint)
            {
                edgePoints.Add(i);
            }
        }
        return edgePoints;
    }
}

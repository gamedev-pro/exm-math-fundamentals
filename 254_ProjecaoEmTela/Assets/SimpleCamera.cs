using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    [SerializeField]
    [Min(0.001f)]
    private float screenDistance;

    [SerializeField] private Vector2 screenSize = new Vector2(20, 10);

    [SerializeField] private Cube cube;

    private void OnDrawGizmos()
    {
        var viewDirection = transform.forward;
        var nearClipPlane = new MyPlane(transform.position + viewDirection * screenDistance, viewDirection);

        Gizmos.DrawSphere(transform.position, 0.5f);
        Gizmos.DrawRay(transform.position, transform.forward * screenDistance * 10);

        GizmosUtils.DrawPlane(nearClipPlane, screenSize);

        if (cube != null)
        {
            Vector3[] cubePoints = new Vector3[8];
            System.Array.Copy(cube.Points, cubePoints, cubePoints.Length);
            bool shouldRender = true;
            for (int i = 0; i < cubePoints.Length; i++)
            {
                shouldRender &= ProjectPoint(cubePoints[i], nearClipPlane, out var projectedCubePoint);
                cubePoints[i] = projectedCubePoint;

                if (!shouldRender)
                {
                    break;
                }
            }

            if (shouldRender)
            {
                Gizmos.color = Color.white;
                SimpleRenderer.DrawCube(cubePoints);
            }
        }
    }

    private bool ProjectPoint(in Vector3 point, in MyPlane projectionPlane, out Vector3 projectedPoint)
    {
        var s = transform.position;
        var v = point - s;
        var n = projectionPlane.Normal;

        var dotNv = Vector3.Dot(v, n);

        if (dotNv <= 0)
        {
            projectedPoint = Vector3.zero;
            return false;
        }

        var t = (projectionPlane.Distance - Vector3.Dot(n, s)) / dotNv;

        projectedPoint = s + v * t;

        if ((projectedPoint - projectionPlane.Point).sqrMagnitude > screenSize.sqrMagnitude)
        {
            projectedPoint = Vector3.zero;
            return false;
        }

        return true;
    }
}

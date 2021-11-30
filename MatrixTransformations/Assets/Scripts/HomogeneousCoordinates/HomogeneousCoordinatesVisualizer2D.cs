using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomogeneousCoordinatesVisualizer2D : MonoBehaviour
{
    [SerializeField]
    private Vector2 translation;

    [SerializeField]
    private float wCoordinate = 1;

    [SerializeField]
    private bool showHomogeneousPoint = false;

    private Vector3 i => new Vector3(1, 0, 0);
    private Vector3 j => new Vector3(0, 1, 0);
    private Vector3 w => new Vector3(0, 0, 1);

    private const float baseSize = 3;

    private void OnDrawGizmos()
    {
        var translationMatrix = new Matrix3x3(
            1, 0, translation.x,
            0, 1, translation.y,
            0, 0, 1);

        DrawAxisW(translationMatrix);
        DrawHomogeneousPlane();
        Draw2DBaseAxis();

        if (showHomogeneousPoint)
        {
            DrawHomogeneousPoint(translationMatrix);
        }

        DrawTranslatedPoint(translationMatrix);
    }

    private void DrawTranslatedPoint(in Matrix3x3 translationMatrix)
    {
        var translatedPoint = translationMatrix * new Vector3(0, 0, 1);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(translatedPoint.z * w, translatedPoint.x * i);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(translatedPoint.z * w + translatedPoint.x * i, translatedPoint.y * j);

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(translatedPoint, 0.1f);
    }

    private void DrawHomogeneousPoint(in Matrix3x3 translationMatrix)
    {
        var transformedPointHc = translationMatrix * new Vector3(0, 0, wCoordinate);
        Gizmos.color = Color.grey;
        Gizmos.DrawSphere(transformedPointHc, 0.1f);
    }

    private void Draw2DBaseAxis()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(i * baseSize);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(j * baseSize);
    }

    private void DrawHomogeneousPlane()
    {
        var wPlane = new MyPlane(new Vector3(0, 0, 1), w);
        GizmosUtils.DrawPlane(wPlane, new Vector2(10, 10));
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(0, 0, 1), 0.05f);
    }

    private void DrawAxisW(in Matrix3x3 translationMatrix)
    {
        var transformedW = translationMatrix * w;
        Gizmos.color = Color.magenta;
        GizmosUtils.DrawVectorAtOrigin(w * baseSize);
        GizmosUtils.DrawVectorAtOrigin(transformedW * baseSize, 2);
    }
}

using UnityEngine;

[RequireComponent(typeof(CubeMesh), typeof(TransformComponent))]
public class CubeMeshRenderer : MonoBehaviour
{
    private CubeMesh mesh;
    private CubeMesh Mesh => mesh == null ? (mesh = GetComponent<CubeMesh>()) : mesh;

    private TransformComponent transformComponent;

    private TransformComponent TransformComponent => transformComponent == null
        ? (transformComponent = GetComponent<TransformComponent>())
        : transformComponent;

    private Vector3[] transformedMeshPoints = new Vector3[8];

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(TransformComponent.Position, TransformComponent.Right);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(TransformComponent.Position, TransformComponent.Up);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(TransformComponent.Position, TransformComponent.Forward);

        System.Array.Copy(Mesh.Points, transformedMeshPoints, Mesh.Points.Length);
        for (int i = 0; i < transformedMeshPoints.Length; i++)
        {
            transformedMeshPoints[i] = TransformComponent.TransformPoint(transformedMeshPoints[i]);
        }
        Gizmos.color = Mesh.Color;
        SimpleRenderer.DrawCube(transformedMeshPoints);
    }
}

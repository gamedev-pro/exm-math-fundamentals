using UnityEngine;

[RequireComponent(typeof(CubeMesh))]
public class CubeMeshRenderer : MonoBehaviour
{
    [SerializeField] private MeshTransformation[] transformations;
    private CubeMesh mesh;
    private CubeMesh Mesh => mesh == null ? (mesh = GetComponent<CubeMesh>()) : mesh;

    private Vector3[] transformedMeshPoints = new Vector3[8];

    private void OnDrawGizmos()
    {
        System.Array.Copy(Mesh.Points, transformedMeshPoints, Mesh.Points.Length);
        foreach (var transformation in transformations)
        {
            transformation.TransformPoints(transformedMeshPoints);
        }
        Gizmos.color = Mesh.Color;
        SimpleRenderer.DrawCube(transformedMeshPoints);
    }
}

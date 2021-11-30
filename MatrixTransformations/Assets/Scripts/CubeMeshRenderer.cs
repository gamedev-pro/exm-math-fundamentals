using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeMesh))]
public class CubeMeshRenderer : MonoBehaviour
{
    private CubeMesh mesh;
    private CubeMesh Mesh => mesh == null ? (mesh = GetComponent<CubeMesh>()) : mesh;
    private void OnDrawGizmos()
    {
        Gizmos.color = Mesh.Color;
        SimpleRenderer.DrawCube(Mesh.Points);
    }
}

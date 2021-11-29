using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float size = 1;
    public Vector3[] points = new Vector3[8];

    public Vector3[] Points
    {
        get
        {
            points[0] = transform.position + new Vector3(1, 1, 1) * size;
            points[1] = transform.position + new Vector3(-1, 1, 1) * size;
            points[2] = transform.position + new Vector3(-1, -1, 1) * size;
            points[3] = transform.position + new Vector3(1, -1, 1) * size;

            points[4] = transform.position + new Vector3(1, 1, -1) * size;
            points[5] = transform.position + new Vector3(-1, 1, -1) * size;
            points[6] = transform.position + new Vector3(-1, -1, -1) * size;
            points[7] = transform.position + new Vector3(1, -1, -1) * size;

            return points;
        }
    }

    private void OnDrawGizmos()
    {
        var worldSpacePoints = Points;
        SimpleRenderer.DrawCube(worldSpacePoints);
    }
}
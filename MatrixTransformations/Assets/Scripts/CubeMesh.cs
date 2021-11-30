using UnityEngine;

public class CubeMesh : MonoBehaviour
{
    [SerializeField] private Color color = Color.green;
    private Vector3[] points = null;

    public Color Color => color;
    public Vector3[] Points
    {
        get
        {
            if (points == null || points.Length == 0)
            {
                points = new Vector3[8];
                points[0] = new Vector3(1, 1, 1);
                points[1] = new Vector3(-1, 1, 1);
                points[2] = new Vector3(-1, -1, 1);
                points[3] = new Vector3(1, -1, 1);

                points[4] = new Vector3(1, 1, -1);
                points[5] = new Vector3(-1, 1, -1);
                points[6] = new Vector3(-1, -1, -1);
                points[7] = new Vector3(1, -1, -1);
            }

            return points;
        }
    }
}
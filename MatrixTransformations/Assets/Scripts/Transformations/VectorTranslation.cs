using UnityEngine;

public class VectorTranslation : MeshTransformation
{
    [SerializeField]
    private Vector3 translation;

    public override void TransformPoints(Vector3[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] += translation;
        }
    }
}

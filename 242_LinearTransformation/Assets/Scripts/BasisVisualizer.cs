using UnityEngine;
using UnityEngine.UI;

public class BasisVisualizer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Text infoText;

    [SerializeField] private Vector2 v;

    [SerializeField] private Matrix2x2[] matrices = new Matrix2x2[0];

    private Vector2 i => composedTransformations * Vector2.right;
    private Vector2 j => composedTransformations * Vector2.up;

    private const float vectorThickness = 5.0f;

    private Matrix2x2 composedTransformations;

    private void OnDrawGizmos()
    {
        UpdateComposedTransformations();
        DrawBase();

        var transformedV = v.x * i + v.y * j;

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(transformedV, vectorThickness);

        infoText.text = $"v = ({transformedV.x}, {transformedV.y})\n{composedTransformations}";
    }

    private void UpdateComposedTransformations()
    {
        composedTransformations = Matrix2x2.Identity;
        for (int i = 0; i < matrices.Length; ++i)
        {
            composedTransformations = matrices[i] * composedTransformations;
        }
    }

    private void DrawBase()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(i);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(j);
    }
}


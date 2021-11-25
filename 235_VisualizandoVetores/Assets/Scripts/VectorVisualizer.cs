using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum VectorOperation
{
    None, Add, Scale, Normalize
}

public class VectorVisualizer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Text infoText;

    [Header("Values")]
    [SerializeField] MyVector3 v;
    [SerializeField] MyVector3 w;
    [SerializeField] float a;

    [Space]
    [Space]
    [SerializeField] VectorOperation operation = VectorOperation.None;

    private const float vectorThickness = 5.0f;
    const float axisSize = 5.0f;

    private void OnDrawGizmos()
    {
        DrawAxis();
        infoText.text = "";

        switch (operation)
        {
            case VectorOperation.None:
                DrawVectorWithGuidelines(v, vectorThickness);
                break;
            case VectorOperation.Add:
                DrawAdd();
                break;
            case VectorOperation.Scale:
                DrawScale();
                break;
            case VectorOperation.Normalize:
                DrawNormalize();
                break;
        }
    }


    private void DrawAdd()
    {
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v, vectorThickness);
        Gizmos.color = Color.grey;
        GizmosUtils.DrawVector(v, w, vectorThickness);
        var result = v + w;
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(result, vectorThickness);

        infoText.text = $"Result ({result.X}, {result.Y}, {result.Z})";
    }

    private void DrawScale() 
    {
        var result = v* a;
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v, vectorThickness);
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(result, vectorThickness);
        infoText.text = $"Scaled Magnitude {result.Magnitude}";
    }

    private void DrawNormalize()
    {
        var result = v.Normalized;
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v, vectorThickness);
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(result, vectorThickness);

        infoText.text = $"Normalized Magnitude {result.Magnitude}";
    }

    private void DrawVectorWithGuidelines(MyVector3 vector, float thickness)
    {
        var vx = new MyVector3(vector.X, 0, 0);
        var vy = new MyVector3(0, vector.Y, 0);
        var vz = new MyVector3(0, 0, vector.Z);

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(vector, thickness);
        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(vx, vz, 1, false);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(vz, vx, 1, false);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(vx + vz, vy, 1, false);

        infoText.text = $"Magnitude {vector.Magnitude}";
    }

    private void DrawAxis()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(Vector3.right * axisSize);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(Vector3.up * axisSize);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVectorAtOrigin(Vector3.forward * axisSize);
    }


}


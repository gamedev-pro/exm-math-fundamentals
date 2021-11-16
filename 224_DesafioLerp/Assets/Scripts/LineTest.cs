using UnityEngine;
using UnityEngine.UI;

public class LineTest : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;

    [SerializeField] private Text lineEquationText;

    private const float pointSize = 0.1f;

    private Vector2 A => a.transform.position;
    private Vector2 B => b.transform.position;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(A, new Vector2(B.x, A.y));

        Gizmos.color = Color.blue;
        DrawPoint(A);
        DrawPoint(B);
        Gizmos.DrawLine(A, B);

        MathUtils.FindLineEquation(A, B, out var m, out var c);
        var angle = Mathf.Atan(m) * Mathf.Rad2Deg;
        lineEquationText.text = $"y = {m}x + {c} (Angle => {angle})";
    }

    private void DrawPoint(Vector2 position)
    {
        Gizmos.DrawSphere(position, pointSize);
    }
}

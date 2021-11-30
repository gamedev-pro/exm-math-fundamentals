using UnityEngine;

public class MatrixRotation : MeshTransformation
{
    [SerializeField] private Vector3 rot;
    public override void TransformPoints(Vector3[] points)
    {
        var rotX = RotationMatrixX();
        var rotY = RotationMatrixY();
        var rotZ = RotationMatrixZ();
        var rotMatrix = rotY * rotX * rotZ;

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = rotMatrix * points[i];
        }
    }

    private Matrix3x3 RotationMatrixX()
    {
        var sinX = Mathf.Sin(rot.x * Mathf.Deg2Rad);
        var cosX = Mathf.Cos(rot.x * Mathf.Deg2Rad);
        var rotX = new Matrix3x3(1, 0, 0, 0, cosX, -sinX, 0, sinX, cosX);
        return rotX;
    }

    private Matrix3x3 RotationMatrixY()
    {
        var sinY = Mathf.Sin(rot.y * Mathf.Deg2Rad);
        var cosY = Mathf.Cos(rot.y * Mathf.Deg2Rad);
        var rotY = new Matrix3x3(cosY, 0, sinY, 0, 1, 0, -sinY, 0, cosY);
        return rotY;
    }

    private Matrix3x3 RotationMatrixZ()
    {
        var sinZ = Mathf.Sin(rot.z * Mathf.Deg2Rad);
        var cosZ = Mathf.Cos(rot.z * Mathf.Deg2Rad);
        var rotZ = new Matrix3x3(cosZ, -sinZ, 0, sinZ, cosZ, 0, 0, 0, 1);
        return rotZ;
    }
}

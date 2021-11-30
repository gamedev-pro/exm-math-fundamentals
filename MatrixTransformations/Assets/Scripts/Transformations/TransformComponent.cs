using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformComponent : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private Vector3 scale = Vector3.one;

    private Matrix4x4 modelMatrix;
    private Matrix4x4 rotationMatrix;

    public Vector3 Position
    {
        get => position;
        set
        {
            position = value;
            UpdateModelMatrix();
        }
    }

    public Vector3 Rotation
    {
        get => rotation;
        set
        {
            rotation = value;
            UpdateModelMatrix();
        }
    }

    public Vector3 Scale
    {
        get => scale;
        set
        {
            scale = value;
            UpdateModelMatrix();
        }
    }

    public Vector3 Right => rotationMatrix * Vector3.right;

    public Vector3 Up => rotationMatrix * Vector3.up;
    public Vector3 Forward => rotationMatrix * Vector3.forward;

    public Vector3 TransformPoint(in Vector3 point)
    {
        return modelMatrix.MultiplyPoint(point);
    }

    private void Awake()
    {
        UpdateModelMatrix();
    }

    private void UpdateModelMatrix()
    {
        var scaleMatrix = new Matrix4x4(
            new Vector4(scale.x, 0, 0, 0),
            new Vector4(0, scale.y, 0, 0),
            new Vector4(0, 0, scale.z, 0),
            new Vector4(0, 0, 0, 1)
        );

        var rotX = RotationMatrixX();
        var rotY = RotationMatrixY();
        var rotZ = RotationMatrixZ();
        rotationMatrix = rotY * rotX * rotZ;

        var translationMatrix = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(position.x, position.y, position.z, 1)
        );

        modelMatrix = translationMatrix * rotationMatrix * scaleMatrix;
    }

    private Matrix4x4 RotationMatrixX()
    {
        var sinX = Mathf.Sin(rotation.x * Mathf.Deg2Rad);
        var cosX = Mathf.Cos(rotation.x * Mathf.Deg2Rad);
        var rotX = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, cosX, sinX, 0),
            new Vector4(0, -sinX, cosX, 0),
            new Vector4(0, 0, 0, 1)
        );
        return rotX;
    }

    private Matrix4x4 RotationMatrixY()
    {
        var sinY = Mathf.Sin(rotation.y * Mathf.Deg2Rad);
        var cosY = Mathf.Cos(rotation.y * Mathf.Deg2Rad);
        var rotY = new Matrix4x4(
            new Vector4(cosY, 0, -sinY, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(sinY, 0, cosY, 0),
            new Vector4(0, 0, 0, 1)
        );
        return rotY;
    }

    private Matrix4x4 RotationMatrixZ()
    {
        var sinZ = Mathf.Sin(rotation.z * Mathf.Deg2Rad);
        var cosZ = Mathf.Cos(rotation.z * Mathf.Deg2Rad);
        var rotZ = new Matrix4x4(
            new Vector4(cosZ, sinZ, 0, 0),
            new Vector4(-sinZ, cosZ, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1)
        );
        return rotZ;
    }

    private void OnValidate()
    {
        UpdateModelMatrix();
    }
}

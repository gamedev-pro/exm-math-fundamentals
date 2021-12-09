using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformComponent : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private Vector3 scale = Vector3.one;

    private Matrix4x4 modelMatrix;

    [Space]
    [Space]
    [SerializeField]
    private Quaternion rotationQuaternion;

    public Vector3 Position
    {
        get => position;
        set
        {
            position = value;
            UpdateModelMatrix();
        }
    }

    public Quaternion Rotation
    {
        get => rotationQuaternion;
        set
        {
            rotationQuaternion = value;
            rotation = rotationQuaternion.eulerAngles;
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

    public Vector3 Up => rotationQuaternion * Vector3.up;
    public Vector3 Right => rotationQuaternion * Vector3.right;
    public Vector3 Forward => rotationQuaternion * Vector3.forward;

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

        rotationQuaternion = Quaternion.Euler(rotation);
        var rotationMatrix = Matrix4x4.Rotate(rotationQuaternion);

        var translationMatrix = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(position.x, position.y, position.z, 1)
        );

        modelMatrix = translationMatrix * rotationMatrix * scaleMatrix;
    }

    private void OnValidate()
    {
        UpdateModelMatrix();
    }
}

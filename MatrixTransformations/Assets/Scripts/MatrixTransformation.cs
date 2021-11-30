using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MatrixTransformation : MonoBehaviour
{
    public abstract Matrix4x4 Transformation { get; }
}

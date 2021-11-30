using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeshTransformation : MonoBehaviour
{
    public abstract void TransformPoints(Vector3[] points);
}

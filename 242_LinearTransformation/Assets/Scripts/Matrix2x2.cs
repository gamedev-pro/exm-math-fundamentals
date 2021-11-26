using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Matrix2x2
{
    [SerializeField]
    private float m00, m01, m10, m11;

    public static Matrix2x2 Identity = new Matrix2x2(1, 0, 0, 1);

    public Matrix2x2(float m00, float m01, float m10, float m11)
    {
        this.m00 = m00;
        this.m01 = m01;
        this.m10 = m10;
        this.m11 = m11;
    }

    public static Matrix2x2 operator +(in Matrix2x2 a, in Matrix2x2 b)
    {
        var result = new Matrix2x2();
        result.m00 = a.m00 + b.m00;
        result.m01 = a.m01 + b.m01;
        result.m10 = a.m10 + b.m10;
        result.m11 = a.m11 + b.m11;
        return result;
    }

    public static Vector2 operator *(in Matrix2x2 m, in Vector2 v)
    {
        var result = new Vector2();
        result.x = v.x * m.m00 + v.y * m.m01;
        result.y = v.x * m.m10 + v.y * m.m11;
        return result;
    }

    public static Matrix2x2 operator *(in Matrix2x2 a, in Matrix2x2 b)
    {
        var result = new Matrix2x2();
        result.m00 = a.m00 * b.m00 + a.m01 * b.m10;
        result.m01 = a.m00 * b.m01 + a.m01 * b.m11;
        result.m10 = a.m10 * b.m00 + a.m11 * b.m10;
        result.m11 = a.m10 * b.m01 + a.m11 * b.m11;
        return result;
    }

    public static Matrix2x2 operator *(in Matrix2x2 m, float a)
    {
        var result = m;
        result.m00 *= a;
        result.m01 *= a;
        result.m10 *= a;
        result.m11 *= a;
        return result;
    }

    public static Matrix2x2 operator *(float a, in Matrix2x2 m)
    {
        return m * a;
    }

    public override string ToString()
    {
        return $"  {m00} {m01}\n  {m10} {m11}";
    }
}
//Reference: https://gist.github.com/anyuser/bf3b6b76937f778636771153d8ba4ff6

using UnityEngine;

public struct Matrix3x3
{
    // m#row#col
    public float m00;
    public float m01;
    public float m02;
    public float m10;
    public float m11;
    public float m12;
    public float m20;
    public float m21;
    public float m22;

    public Matrix3x3(
        float m00,
        float m01,
        float m02,
        float m10,
        float m11,
        float m12,
        float m20,
        float m21,
        float m22)
    {

        this.m00 = m00;
        this.m01 = m01;
        this.m02 = m02;
        this.m10 = m10;
        this.m11 = m11;
        this.m12 = m12;
        this.m20 = m20;
        this.m21 = m21;
        this.m22 = m22;
    }

    public Matrix3x3(Matrix3x3 m)
    {
        m00 = m.m00;
        m10 = m.m10;
        m20 = m.m20;
        m01 = m.m01;
        m11 = m.m11;
        m21 = m.m21;
        m02 = m.m02;
        m12 = m.m12;
        m22 = m.m22;
    }

    public static Matrix3x3 identity
    {
        get
        {
            Matrix3x3 matrix = new Matrix3x3();
            matrix.m00 = 1;
            matrix.m11 = 1;
            matrix.m22 = 1;
            return matrix;
        }
    }

    public static Vector3 MultiplyVector3(Matrix3x3 m1, Vector3 inVector)
    {
        Vector3 outVector = new Vector3();
        outVector.x = m1.m00 * inVector.x + m1.m01 * inVector.y + m1.m02 * inVector.z;
        outVector.y = m1.m10 * inVector.x + m1.m11 * inVector.y + m1.m12 * inVector.z;
        outVector.z = m1.m20 * inVector.x + m1.m21 * inVector.y + m1.m22 * inVector.z;
        return outVector;
    }

    public static Matrix3x3 MultiplyMatrix3x3(Matrix3x3 m1, Matrix3x3 m2)
    {
        Matrix3x3 m = new Matrix3x3();

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                float sum = 0.0f;
                for (int k = 0; k < 3; k++)
                    sum += m1[i, k] * m2[k, j];
                m[i, j] = sum;
            }

        return m;
    }

    public float this[int i, int j]
    {
        get
        {
            if (i == 0)
            {
                if (j == 0) return m00;
                if (j == 1) return m01;
                if (j == 2) return m02;
            }
            if (i == 1)
            {
                if (j == 0) return m10;
                if (j == 1) return m11;
                if (j == 2) return m12;
            }
            if (i == 2)
            {
                if (j == 0) return m20;
                if (j == 1) return m21;
                if (j == 2) return m22;
            }

            throw new System.IndexOutOfRangeException($"({i}, {j})");
        }
        set
        {
            if (i == 0)
            {
                if (j == 0) m00 = value;
                if (j == 1) m01 = value;
                if (j == 2) m02 = value;
            }
            if (i == 1)
            {
                if (j == 0) m10 = value;
                if (j == 1) m11 = value;
                if (j == 2) m12 = value;
            }
            if (i == 2)
            {
                if (j == 0) m20 = value;
                if (j == 1) m21 = value;
                if (j == 2) m22 = value;
            }
        }
    }

    public static Matrix3x3 operator *(Matrix3x3 m1, Matrix3x3 m2)
    {
        return Matrix3x3.MultiplyMatrix3x3(m1, m2);
    }

    public static Vector3 operator *(Matrix3x3 m, Vector3 v)
    {
        return Matrix3x3.MultiplyVector3(m, v);
    }
}
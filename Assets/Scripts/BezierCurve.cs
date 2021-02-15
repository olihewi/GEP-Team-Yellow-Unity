using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BezierCurve
{
    public Vector2[] points;

    public Vector2 GetPoint(float _time)
    {
        int numPoints = points.Length;
        Vector2[] tmp = new Vector2[numPoints];
        for (int j = 0; j < numPoints; j++)
        {
            tmp[j] = points[j];
        }
        int i = numPoints - 1;
        while (i > 0)
        {
            for (int k = 0; k < i; k++)
            {
                tmp[k] = tmp[k] + _time * (tmp[k + 1] - tmp[k]);
            }
            i--;
        }
        Vector2 result = tmp[0];
        return result;
    }
}

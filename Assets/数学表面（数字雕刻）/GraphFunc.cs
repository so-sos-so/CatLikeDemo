using UnityEngine;

public static class GraphFunc
{
    public static float SinFunc(float positionX)
    {
        return Mathf.Sin(Mathf.PI * positionX);
    }

    public static float MulSinFunc(float positionX)
    {
        float y = Mathf.Sin(Mathf.PI * positionX);
        y += Mathf.Sin(2 * Mathf.PI * positionX) / 2;
        return y;
    }
}
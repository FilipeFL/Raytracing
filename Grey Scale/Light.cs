using System;
using System.Numerics;

public class Light
{
    public Vector3 position;
    public int color;

    public Light(Vector3 p, int c)
    {
        position = p;
        color = c;
    }
}

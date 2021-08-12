using System;
using System.Numerics;

public class Material
{
    public int color; // 0 a 255
    public float ambiente; // 0 a 1
    public float especularidade; // 5 a 100

    public Material(int c, float a, float e)
    {
        color = c;
        ambiente = a;
        especularidade = e;
    }
}

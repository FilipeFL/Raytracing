using Raytracing;
using System;
using System.Numerics;
using System.Reflection.PortableExecutable;

public class Material
{
    //color agora é um Vector3, para implementação do RGB no material.
    public Vector3 color; // 0 a 255
    public float ambiente; // 0 a 1
    public float especularidade; // 5 a 100

    //Mesma mudança já citada nesse .cs, mas implementada na classe base.
    public Material(Vector3 c, float a, float e)
    {
        color = c;
        ambiente = a;
        especularidade = e;
    }
}

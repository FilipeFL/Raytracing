using Raytracing;
using System;
using System.Numerics;

public class Light
{
    public Vector3 position;
    //color agora é um Vector3, para implementação do RGB na luz.
    public Vector3 color;

    //Mesma mudança já citada nesse .cs, mas implementada na classe base.
    public Light(Vector3 p, Vector3 c)
    {
        position = p;
        color = c;
    }
}

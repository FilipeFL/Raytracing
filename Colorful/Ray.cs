using System.Numerics;

public class Ray
{
    public Vector3 position;
    public Vector3 direction;

    public Ray(Vector3 p, Vector3 d)
    {
        position = p;
        direction = d;
    }
}

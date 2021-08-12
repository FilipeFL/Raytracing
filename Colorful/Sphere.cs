using System;
using System.Numerics;

public class Sphere
{
    public Vector3 center;
    public float radius;
    public Material material;

    public Sphere(Vector3 c, float r, Material m)
    {
        center = c;
        radius = r;
        material = m;
    }

    public bool Intersection(Vector3 rayorig, Vector3 raydir, ref float t0, ref float t1)
    {
        Vector3 d = center - rayorig;
        float tca = Vector3.Dot(d, raydir);
        
        if (tca < 0)
        {
            return false;
        }

        float d2 = Vector3.Dot(d, d) - tca * tca;

        if (d2 > radius * radius)
        {
            return false;
        }

        float thc = (float)Math.Sqrt(radius * radius - d2);
        t0 = tca - thc;
        t1 = tca + thc;

        return true;
    }
}

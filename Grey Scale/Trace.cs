using System.Numerics;
using System;

public class Trace
{
    public static int getColor(Ray ray, Sphere[] spheres, Light light)
    {
        float hit = Constantes.INFINITY;
        int obj_index = -1;

        for (int i = 0; i < spheres.Length; i++)
        {
            float t0 = Constantes.INFINITY;
            float t1 = Constantes.INFINITY;

            if (spheres[i].Intersection(ray.position, ray.direction, ref t0, ref t1))
            {
                if (t0 < hit)
                {
                    hit = t0;
                    obj_index = i;
                }
            }
        }

        if (obj_index == -1)
        {
            return Background.getColor((int)ray.position.X, (int)ray.position.Y);
        }

        Vector3 hit_point = ray.position + ray.direction * hit;
        Vector3 normal = hit_point - spheres[obj_index].center;
        normal = Vector3.Normalize(normal);

        Vector3 lightDir = light.position - hit_point;
        lightDir = Vector3.Normalize(lightDir);

        float NdotL = Vector3.Dot(normal, lightDir);

        float shadow = 1.0f;
        for (int i = 0; i < spheres.Length; i++)
        {
            if (i != obj_index)
            {
                float t0 = 0;
                float t1 = 0;
                if (spheres[i].Intersection(hit_point, lightDir, ref t0, ref t1))
                {
                    shadow = 0.0f;
                }
            }
        }

        Vector3 reflexao = lightDir - normal * 2.0f * Vector3.Dot(lightDir, normal);
        float valorBase = System.Math.Max(0, Vector3.Dot(reflexao, ray.direction));
        float especular = (float)System.Math.Pow(valorBase, spheres[obj_index].material.especularidade) * light.color; // valor entre 5 e 100

        float ambiente = spheres[obj_index].material.color * spheres[obj_index].material.ambiente;
        float difusa = spheres[obj_index].material.color * ((NdotL < 0) ? NdotL : 0.0f);

        return (int)Math.Clamp((ambiente + difusa + especular) * shadow, 0, 255);
    }
}

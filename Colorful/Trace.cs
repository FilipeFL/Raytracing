using System.Numerics;
using System;
using Raytracing;

public class Trace
{
    //A função "getColor" agora retornará um valor Vector3.
    public static Vector3 getColor(Ray ray, Sphere[] spheres, Light light)
    {
        float hit = Constants.INFINITY;
        int obj_index = -1;

        for (int i = 0; i < spheres.Length; i++)
        {
            float t0 = Constants.INFINITY;
            float t1 = Constants.INFINITY;

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
                float t0 = 0.0f;
                float t1 = 0.0f;
                if (spheres[i].Intersection(hit_point, lightDir, ref t0, ref t1))
                {
                    shadow = 0.0f;
                }
            }
        }

        Vector3 reflexao = lightDir - normal * 2.0f * Vector3.Dot(lightDir, normal);
        float valorBase = Math.Max(0, Vector3.Dot(reflexao, ray.direction));

        //As variáveis "especular", "ambiente" e "difusa" agora são Vector3.
        Vector3 especular = (float)Math.Pow(valorBase, spheres[obj_index].material.especularidade) * light.color; // valor entre 5 e 100
        Vector3 ambiente = spheres[obj_index].material.color * spheres[obj_index].material.ambiente;
        Vector3 difusa = spheres[obj_index].material.color * ((NdotL > 0) ? NdotL : 0.0f);

        //A variável de retorno da cor int "c", foi desmembrada em diversos int cx, cy e cz.
        int cx = (int)Math.Clamp((ambiente.X + difusa.X + especular.X) * shadow, 0, 255);
        int cy = (int)Math.Clamp((ambiente.Y + difusa.Y + especular.Y) * shadow, 0, 255);
        int cz = (int)Math.Clamp((ambiente.Z + difusa.Z + especular.Z) * shadow, 0, 255);

        //As novas variáveis que retornam um int da cor são dispostas num new Vector3 que será retornado ao final da função,
        //caso uma esfera seja encontrada no algoritmo, já gerando assim a sua cor.
        return new Vector3(cx, cy, cz);
    }
}

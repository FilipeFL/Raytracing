using System;
using System.Numerics;

namespace Raytracing
{
    class Program
    {
        static void Main(string[] args)
        {

            Material m1 = new Material(180, 0.3f, 5.0f);
            Material m2 = new Material(230, 0.2f, 30.0f);
            Material m3 = new Material(255, 0.3f, 100.0f);

            Sphere sphere1 = new Sphere(new Vector3(40, 80, 850), 40, m1);
            Sphere sphere2 = new Sphere(new Vector3(60, 140, 850), 20, m2);
            Sphere sphere3 = new Sphere(new Vector3(200, -1900, 1500), 2000, m3);
            Sphere[] spheres = new Sphere[3];
            spheres[0] = sphere1;
            spheres[1] = sphere2;
            spheres[2] = sphere3;

            Ray camera = new Ray(new Vector3(50, 50, 0), new Vector3(0, 0, 1));
            Light light = new Light(new Vector3(50, 200, 750), 255);

            string outFile = "";
            for (int y = Constantes.MAX_HEIGHT; y > 0; y--)
            {
                for (int x = 0; x < Constantes.MAX_WIDTH; x++)
                {
                    camera.position = new Vector3(x, y, 0);
                    int cor = Trace.getColor(camera, spheres, light);
                    outFile += cor + " ";
                }
                outFile += "\n";
            }
            FileManager.SaveImage(outFile);
        }
    }
}

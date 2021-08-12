using System;
using System.Numerics;
using System.Reflection.PortableExecutable;

namespace Raytracing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Implementação das variáveis Vector3 para representação das cores em formato RGB, no main.
            Vector3 beige = new Vector3(255, 180, 90);
            Vector3 blue = new Vector3(0, 0, 255);
            Vector3 red = new Vector3(255, 0, 0);
            Vector3 green = new Vector3(0, 255, 0);
            Vector3 white = new Vector3(255, 255, 255);

            //Implementação de variáveis Material que agora recebem um Vector3 como primeiro parâmetro.
            Material m_beige = new Material(beige, 0.3f, 5.0f);
            Material m_blue = new Material(blue, 0.2f, 30.0f);
            Material m_red = new Material(red, 0.3f, 100.0f);
            Material m_green = new Material(green, 0.3f, 200.0f);

            //Adição de uma esfera para suprir a demanda do trabalho.
            Sphere sphere1 = new Sphere(new Vector3(40, 120, 10), 40, m_blue);
            Sphere sphere2 = new Sphere(new Vector3(150, 150, 10), 20, m_red);
            Sphere sphere3 = new Sphere(new Vector3(100, 100, 90), 60, m_green);
            Sphere sphere4 = new Sphere(new Vector3(40, 1150, 280), 1000, m_beige);

            //Vetor de Sphere também modificado para comportar todas as esferas implementadas.
            Sphere[] spheres = new Sphere[4];

            spheres[0] = sphere1;
            spheres[1] = sphere2;
            spheres[2] = sphere3;
            spheres[3] = sphere4;

            Ray camera = new Ray(new Vector3(50, 50, 0), new Vector3(0, 0, 1));

            //Luz recebe agora como último parâmetro um Vector3 que representa a cor branca ("white");
            Light light = new Light(new Vector3(50, -200, -150), white);

            string outFile = "";

            //Houve uma mudança na direção da iteração de geração da imagem.
            for (int y = 0; y < Constants.MAX_HEIGHT; y++)
            {
                for (int x = 0; x < Constants.MAX_WIDTH; x++)
                {
                    //Posição da câmera em z, foi para 1.
                    camera.position = new Vector3(x, y, 1);
                    Vector3 cor = Trace.getColor(camera, spheres, light);

                    // a variável "outFile" recebe 3 variáveis agora mais seus respectivos espaços, para implementação correta
                    //de cada cor no arquivo final.
                    outFile += cor.X + " " + cor.Y + " " + cor.Z + " ";
                }
                outFile += "\n";
            }
            FileManager.SaveImage(outFile);
        }
    }
}

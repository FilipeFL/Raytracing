using System;
using System.IO;

public class FileManager
{
    //a variável string "COLORMODE" mudou de "P2" para "P3", por cota da mudança de proposta do trabalho, já que o arquivo .ppm não será
    //mais em escala de cinza e sim colorido.
    const string COLORMODE = "P3";
    const string MAXCOLORS = "255";
    const string FILENAME = "imagem.ppm";

    public static void SaveImage(string s)
    {
        int height = Constants.MAX_HEIGHT;
        int width = Constants.MAX_WIDTH;

        string head = COLORMODE + "\n" + height + " " + width + "\n" + MAXCOLORS + "\n";

        string FinalFile = head + s;
        //File.WriteAllText(FILENAME, FinalFile);
        Console.WriteLine(FinalFile);
    }
}

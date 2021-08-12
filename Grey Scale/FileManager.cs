using System;
using System.IO;

public class FileManager
{
    const string COLORMODE = "P2";
    const string MAXCOLORS = "255";
    const string FILENAME = "imagem.ppm";

    public static void SaveImage(string s)
    {
        int height = Constantes.MAX_HEIGHT;
        int width = Constantes.MAX_WIDTH;

        string head = COLORMODE + "\n" + height + " " + width + "\n" + MAXCOLORS + "\n";

        string FinalFile = head + s;
        //File.WriteAllText(FILENAME, FinalFile);
        Console.WriteLine(FinalFile);
    }
}

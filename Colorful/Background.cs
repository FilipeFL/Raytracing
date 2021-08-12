using System.Numerics;

public class Background
{
    //This section will
    public static Vector3 getColor(int x, int y)
    {
        int width = Constants.MAX_WIDTH / 5;
        int height = Constants.MAX_HEIGHT / 5;
        int c = (((x / width + y / height) % 2) * 255);

        //Modifiquei a cor que retorna para um vector3 que recebe 3 variáveis int c, assim o background poderá ser colorido.
        return new Vector3(c, c, c);
    }
}

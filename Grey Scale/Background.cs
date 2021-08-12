public class Background
{
    public static int getColor(int x, int y)
    {
        int width = Constantes.MAX_WIDTH / 5;
        int height = Constantes.MAX_HEIGHT / 5;
        int c = (((x / width + y / height) % 2) * 255);

        return c;
    }
}

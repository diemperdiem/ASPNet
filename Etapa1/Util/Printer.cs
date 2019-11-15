namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {         
            System.Console.WriteLine("".PadLeft(tam, '='));
        }

        public static void writeTitle(string titulo)
        {         
            DrawLine(titulo.Length + 4);
            System.Console.WriteLine($"| {titulo} |");
            DrawLine(titulo.Length + 4);
        }


    }
}
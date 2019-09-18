using System;

namespace CoreEscuela
{
    class Escuela
    {
        public string nombre; 
        public string direccion;
        public int añofundacion;

        public string CEO  = "Freddy Vega";

        public void Timbrar()
        {
            Console.Beep(2000,3000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var miEscuela = new Escuela();
            miEscuela.nombre = "Platzi Academi";
            miEscuela.direccion = "Bogota";
            miEscuela.añofundacion = 2010;
            Console.WriteLine("Timbredot");
            //Console.WriteLine("Hello World!");
        }
    }
}

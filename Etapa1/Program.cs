using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;    // te evita estar escribiendo el system.console antes del writeline, deja fija la ruta

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Eskul", 2010, TiposEscuela.Secundaria, ciudad: "sdfsdf");

            escuela.Cursos = new List<Curso>()
            {
                new Curso(){Nombre = "101"},
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "301"}
            };

            escuela.Cursos.Add(new Curso() { Nombre = "401", Jornada = TiposJornada.Noche });

            Console.WriteLine(escuela);
            System.Console.WriteLine("---------------------");
            //ImprimirCursos(arregloCursos);
            imprimirCursosEscuela(escuela);
            WriteLine("\n");
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            if (escuela?.Cursos != null)  //signo de interrogacion valida si no es
            {
                foreach (var item in escuela.Cursos)
                {
                    System.Console.WriteLine($"#Curso: {item.Nombre}, ID:{item.UniqueId}, Jornada: {item.Jornada}");
                }
            }
        }
    }
}

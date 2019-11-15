using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using Etapa1.Entidades;
using static System.Console;    // te evita estar escribiendo el system.console antes del writeline, deja fija la ruta

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.writeTitle("Bienvenidos a la Escuela");
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Console.WriteLine(engine.Escuela);
            imprimirCursosEscuela(engine.Escuela);
            //int dummy = 0; //variable dummy 

            var listaObjetos = engine.getObjetosEscuela
            (
                out int ConteoEvaluaciones,
                out int ConteoCursos,
                out int ConteoAsignaturas,
                out int ConteoAlumnos,
                true, 
                true, 
                true, 
                true
            );

            // var listaLugar = from obj in listaObjetos  //Se usa LINQ, esto es un query para filtrar
            //                  where obj is ILugar       //el where de SQL donde el objeto sea de cierto tipo
            //                  select (ILugar)obj;       //seleccionar el objeto con un casting de tipo x
#region pruebas polimorfismo            
            //engine.Escuela.LimpiarLugar();
// 
//             Printer.DrawLine(20);
//             Printer.DrawLine(20);
//             Printer.DrawLine(20);
//             Printer.writeTitle("Pruebas de polimorfismo");
//             var alumnoTest = new Alumno{Nombre = "Claire Underwood"};
//             ObjetoEscuelaBase ob = alumnoTest;

//             Printer.writeTitle("Alumno");
//             WriteLine($"Alumno: {alumnoTest.Nombre}");
//             WriteLine($"Alumno: {alumnoTest.UniqueID}");
//             WriteLine($"Alumno: {alumnoTest.GetType()}");

//             Printer.writeTitle("Objeto Escuela");
//             WriteLine($"Alumno: {ob.Nombre}");
//             WriteLine($"Alumno: {ob.UniqueID}");
//             WriteLine($"Alumno: {ob.GetType()}");

//         // var objDummy = new ObjetoEscuelaBase(){ Nombre = "Frank Underwood"};

//         // Printer.writeTitle("Objeto Escuela Base");
//         // WriteLine($"Alumno: {objDummy.Nombre}");
//         // WriteLine($"Alumno: {objDummy.UniqueID}");
//         // WriteLine($"Alumno: {objDummy.GetType()}"); 

//             alumnoTest = (Alumno) ob;

//             //Se puede trabajar un objeto con caracteristicas de padre a hijo pero de hijo a padre no
//             //al menos que tenga la informacion sea del mismo tipo

//             var evaluacionx = new Evaluacion(){Nombre = "Evaluacion de math", Nota = 4.5f}; 
//             Printer.writeTitle("Evaluacion");
//             WriteLine($"evaluacion: {evaluacionx.Nombre}");
//             WriteLine($"evaluacion: {evaluacionx.UniqueID}");
//             WriteLine($"evaluacion: {evaluacionx.Nota}");
//             WriteLine($"evaluacion: {evaluacionx.GetType()}");

//             if (ob is Alumno)
//             {
//                 Alumno alumnoRecuperado = (Alumno)ob;
//             }
// 
//             Alumno alumnoRecuperado2 = ob as Alumno; // el as valida si es del tipo si no solo devuelve null
#endregion
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            Printer.writeTitle("Cursos de la Escuela");
            if (escuela?.Cursos != null)  //signo de interrogacion valida si no es
            {
                foreach (var item in escuela.Cursos)
                {
                    System.Console.WriteLine($"#Curso: {item.Nombre}, ID:{item.UniqueID}, Jornada: {item.Jornada}");
                }
            }
        }
    }
}

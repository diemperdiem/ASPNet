using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public sealed class EscuelaEngine   // El "sealed" hace que la clase aun se puedan crear instancias pero no se permite heredar de ella
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academi", 2012, TiposEscuela.Primaria,
                                    ciudad: "Bogota", pais: "Colombia"
                                 );

            //delegado lambda
            //Escuela.Cursos.RemoveAll((cur) => cur.Nombre == "501" && cur.Jornada == TiposJornada.Mañana);   //borra cuando recibe true         

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumn in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} EV#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumn
                            };
                            alumn.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignauras = new List<Asignatura>()
                {
                    new Asignatura{Nombre = "Matematicas"},
                    new Asignatura{Nombre = "Educacion Fisica"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignauras;
            }
        }

        private List<Alumno> CrearAlumnos(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolas" };
            string[] apellido = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Morty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al) => al.UniqueID).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>()
            {
                new Curso(){Nombre = "101"},
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "301"}
            };

            Escuela.Cursos.Add(new Curso() { Nombre = "401", Jornada = TiposJornada.Noche });

            var otrCursos = new List<Curso>()
            {
                new Curso(){Nombre = "501", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "601", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "701", Jornada = TiposJornada.Mañana}
            };

            Random rnd = new Random();


            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = CrearAlumnos(cantRandom);
            }
        }

        public List<ObjetoEscuelaBase> getObjetosEscuela   // (List<ObjetoEscuelaBase>, int) Se puede hacer un metodo que regrese 2 tipos de datos
        (
            out int ConteoEvaluaciones,   //Se pueden asignar parametros de salida, los parametros opcionales deben de ir al fina
            out int ConteoCursos,
            out int ConteoAsignaturas,
            out int ConteoAlumnos,
            bool traeEvaluaciones = true, //Cuando se mandan variables predeterminadas se puede correr el metodo sin mandar nada, a menos de que se quiera delimitar algo
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            ConteoEvaluaciones = ConteoAsignaturas = ConteoAlumnos = 0;
            var ListaOBJ = new List<ObjetoEscuelaBase>();
            ListaOBJ.Add(Escuela);

            if (traeCursos)
                ListaOBJ.AddRange(Escuela.Cursos);
                ConteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                if (traeAsignaturas)
                    ListaOBJ.AddRange(curso.Asignaturas);
                    ConteoAsignaturas += curso.Asignaturas.Count;
                if (traeAlumnos)
                    ListaOBJ.AddRange(curso.Alumnos);
                    ConteoAlumnos += curso.Alumnos.Count;
                if (traeEvaluaciones)
                {
                    foreach (var Alumnos in curso.Alumnos)
                    {
                        ListaOBJ.AddRange(Alumnos.Evaluaciones);
                        ConteoEvaluaciones += Alumnos.Evaluaciones.Count;
                    }
                }
            }

            return ListaOBJ;
        }
    }


}
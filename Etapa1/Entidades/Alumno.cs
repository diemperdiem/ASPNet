using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.Entidades
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>(); //Para inivializar la lista desde la creacion de la clase 
    }
}
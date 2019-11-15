using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using Etapa1.Entidades;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
       

        public int  añoDeCreacon{get; set;}

        public string Pais { get; set; }

        public string ciudad { get; set; }

        public string Direccion { get; set; }

        public TiposEscuela TipoEscuela { set; get; }

        public List<Curso> Cursos { get; set; }

        // public Escuela (string nombre, int año) => (Nombre, añoDeCreacon) = (nombre, año);

        public Escuela (string nombre, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            (Nombre, añoDeCreacon) = (nombre, año);
            this.Pais = pais;
            this.ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"\nNombre: {Nombre}\nTipo: {TipoEscuela}\nPais: {Pais}\nCiudad: {ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento...");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Console.WriteLine($"Escuela {Nombre} Limpia"); 
        }
    }
}
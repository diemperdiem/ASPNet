using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;
        public string Nombre
        {
            get{return nombre;}
            set{nombre = value.ToUpper();}
        }

        public int  añoDeCreacon{get; set;}

        public string Pais { get; set; }

        public string ciudad { get; set; }

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
    }
}
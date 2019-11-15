using System;

namespace CoreEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase //el abstract es para no poder instanciar la clase 
    {
        public string UniqueID { get; private set; }
        public string Nombre { get; set; }

        public  ObjetoEscuelaBase ()
        {
            UniqueID = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{UniqueID}";
        }
    }
}
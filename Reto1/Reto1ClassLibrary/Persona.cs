namespace Reto1ClassLibrary
{
    using System.Collections.Generic;

    public class Persona
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Edad.Equals(((Persona)obj).Edad)
                && this.Nombre.Equals(((Persona)obj).Nombre);
        }

        public override int GetHashCode()
        {
            return this.Nombre.GetHashCode() * 21 + this.Edad.GetHashCode() * 17;
        }

        internal sealed class PersonaComparer : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                int result = y.Edad.CompareTo(x.Edad);
                if (result == 0)
                {
                    result = x.Nombre.CompareTo(y.Nombre);
                }

                return result;
            }
        }
    }
}

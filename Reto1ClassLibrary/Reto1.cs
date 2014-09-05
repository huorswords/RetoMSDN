namespace Reto1ClassLibrary
{
    using System.Collections.Generic;

    public class Reto1
    {
        public static List<Persona> OrdenarLista(List<Persona> lista)
        {
            if (null != lista)
            {
                lista.Sort(new Persona.PersonaComparer());
            }

            return lista;
        }
    }
}

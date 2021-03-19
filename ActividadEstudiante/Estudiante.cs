using System;
using System.Collections.Generic;
using System.Text;

namespace ActividadEstudiante

{
    
    /*
        Datos públicos, privados y protegidos.
        
    Supongamos que una clase es como una casa; entonces sus atributos (o sea, las variables que están adentro) habitan en
    la clase, y sus métodos (las funciones que están adentro) también se quedan en la clase.

    Si una clase, un atributo o un método es público, significa que "Personas" fuera de la clase pueden acceder a ellos; o usarlos.
    Si un atributo o un método es privado, significa que solamente existen dentro de la clase.
    Si un atributo o un método es protegido, solo existen dentro de la clase, y en sus hijos.


    */
    public class Estudiante // Clase pública de "Estudiante", este es el molde para crear los datos de un estudiante
    {
        
        // get = obtener, set = renombrar o asignar.

        // cod = código es un dato público que se puede obtener y cambiar.
        public int cod { get; set; } 
        // nom = nombre es un dato público que se puede obtener y cambiar.
        public string nom { get; set; }
        // se entiende la idea, ¿no? :V
        public string email { get; set; }
        public double n1 { get; set; }
        public double n2 { get; set; }
        public double n3 { get; set; }
        public double suma { get; set; }
        public double div { get; set; }

        /* El get de cod es lo mismo que esta función:
        public int codGet() {
            return cod;
        }

        y el set de cod es lo mismo que esta función:
        public void codSet(int nuevoCod) {
            cod = nuevoCod;
        }

        */
    }
}

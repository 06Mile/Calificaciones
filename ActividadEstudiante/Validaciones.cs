using System;
using System.Text.RegularExpressions;

namespace ActividadEstudiante
{
    public class Validaciones
    {
        public bool Vacio(string texto)
        {
            if (texto.Equals(""))
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("|| .... Por Favor Deje de dar ENTER ...||");
                Console.WriteLine("-----------------------------------------");
                return true;
            }
            else
                return false;
        }

        public bool Numero(string texto)
        {

            Regex regla = new Regex("[0-9]{1,9}(\\.[0-9]{0,2})?$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("||....Por favor No Ingrese LETRAS !!!! ...||");
                Console.WriteLine("--------------------------------------------");
                return false;
            }

        }


        public bool TipoTexto(string texto)
        {
            Regex regla = new Regex("^[a-zA-Z ]*$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|| ...Por Favor No ingrese NUMEROS NI SIMBOLOS RAROS !!!! .||");
                Console.WriteLine("-------------------------------------------------------------");

                return false;
            }
        }

        public bool Mail(string texto)
        {

            Regex regla = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("|| ...Por Favor  Ingrese formato de Email valido !!! ..||");
                Console.WriteLine("---------------------------------------------------------");
                return false;
            }
        }

        public string ValidarDatos(string tipoDato, string mensaje)
        {
            string texto; // Lo que digitará el usuario
            bool dato = false; // Si cumple o no con el tipo de dato
            bool textoVal = false; // Si el texto es válido o no.

            do
            {
                Console.WriteLine(mensaje + ": ");
                texto = Console.ReadLine();
                switch (tipoDato)
                {
                    case "Numero":
                        dato = Numero(texto);
                        break;
                    case "Texto":
                        dato = TipoTexto(texto);
                        break;
                    case "Correo":
                        dato = Mail(texto);
                        break;
                    default:
                        break;
                }
                if (!Vacio(texto) && dato)
                    textoVal = true;

            } while (!textoVal);

            return texto;
        }
    }
}

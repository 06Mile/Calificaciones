using System;
using System.Collections.Generic;

using System.IO;
using System.Xml.Serialization;

namespace ActividadEstudiante

{
    class Program

    {
        static List<Estudiante> ListaEstudiantes = new List<Estudiante>();
        static Validaciones Validar = new Validaciones();
        static void Main(string[] args)
        {
            int Menu;
            int posX, posY;
            string aux;
            bool entradaVal = false;

            do
            {
                Console.Title = "Formutario de Estudiantes";
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                posY = 2;  // En la fila 2
                Random r = new Random(DateTime.Now.Millisecond);
                posX = r.Next(20, 40); // Columna al azar entre 20 y 40
                Console.SetCursorPosition(posX, posY);
                Console.WriteLine("Bienvenido");
                Console.WriteLine("____________________________________");
                Console.WriteLine(" Por favor digite alguna");
                Console.WriteLine(" de las opciones para realizar los siguientes procesos");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("|| 1) Agregar Estudiantes.        ||");
                Console.WriteLine("|| 2) Listar Estudiantes.         ||");
                Console.WriteLine("|| 3) Buscar Estudiantes.         ||");
                Console.WriteLine("|| 0) Salir                       ||");
                Console.WriteLine("|| 5) Guardar Archivo...          ||");
                Console.WriteLine("|| 6) Cargar Archivo...           ||");
                Console.WriteLine("|| 7) Documentacion de programa   ||");
                Console.WriteLine("------------------------------------");

                do
                {
                    Console.WriteLine("|| Digite una opcion:     ||");
                    aux = Console.ReadLine();
                    if (!Validar.Vacio(aux))
                        if (Validar.Numero(aux))
                            entradaVal = true;
                } while (!entradaVal);

                Menu = Convert.ToInt32(aux);

                switch (Menu)
                {
                    case 1:
                        AgregarEstudiantes();
                        break;
                    case 2:
                        ListarEstudiantes();
                        break;
                    case 3:
                        BuscarEstudiantes();
                        break;
                    case 5:
                        EscribirXml();
                        break;
                    case 6:
                        LeerXml();
                        break;
                    case 7:
                        DocumentacionXml();
                        break;
                    case 0:
                        Console.WriteLine("____________________________");
                        Console.WriteLine("|| Gracias y hasta luego  ||");
                        break;
                    default:
                        Console.WriteLine("|| Opcion incorrecta      ||");
                        break;

                }
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(" Presione cualquier tecla para continuar");
                Console.WriteLine("----------------------------------------");
                Console.ReadLine();
                Console.WriteLine("----------------------------------------");
            } while (Menu > 0);

        }

        static void AgregarEstudiantes()
        {
            string nombre, correo, codigo, nota1, nota2, nota3;
            int posX, posY;
            
            Console.Title = "ingresar datos ";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            posY = 2;  // En la fila 2
            Random r = new Random(DateTime.Now.Millisecond);
            posX = r.Next(20, 40); // Columna al azar entre 20 y 40
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine("Ingrese datos del estudiante");
            Console.WriteLine("___________________________________________________________________");

            //---------------------------------------------------------------
            // OPERADORES LÓGICOS.
            // p = esta lloviendo
            // q = tengo ganas de comer
            // p y q = p && q = esta lloviendo Y tengo ganas de comer.
            // p o q = p || q = esta lloviendo O tengo ganas de comer.
            // no p = !p = NO esta lloviendo.

                codigo = Validar.ValidarDatos("Numero", "|| Inserte el código del nuevo estudiante ||");

            if (Existe(Convert.ToInt32(codigo)))
                Console.WriteLine("|| El codigo " + codigo + " ya existe en el programa. ||");
            else
            {
                nombre = Validar.ValidarDatos("Texto", "|| Ingrese el nombre del nuevo estudiante ||");
                correo = Validar.ValidarDatos("Correo", "|| Ingrese el correo del nuevo estudiante ||");
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("|| Para las notas por favor digitelas con coma (,).||");
                nota1 = Validar.ValidarDatos("Numero", "|| Inserte su primera Nota ||");
                nota2 = Validar.ValidarDatos("Numero", "|| Inserte su segunda Nota ||");
                nota3 = Validar.ValidarDatos("Numero", "|| Inserte su tercera Nota ||");
                Console.WriteLine("-------------------------------------------------------------------");

                //----------------------------------------------------

                Estudiante myEstudiante = new Estudiante();
                myEstudiante.cod = Convert.ToInt32(codigo);
                myEstudiante.nom = nombre;
                myEstudiante.email = correo;
                myEstudiante.n1 = Double.Parse(nota1);
                myEstudiante.n2 = Double.Parse(nota2);
                myEstudiante.n3 = Double.Parse(nota3);

                //-----------------------------------------------------
                ListaEstudiantes.Add(myEstudiante);
            }
        }

        static void ListarEstudiantes() // Opción 2, mostrar lista de estudiantes
        {
            Double div = 0; // Definitiva (división)
            Double suma = 0; // Suma de 3 notas v: 
            string texto;
            int y = 9; // Altura de las letras
            int posX, posY;
            Console.Title = "Lista de estudiantes ";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            posY = 2;  // En la fila 2
            Random r = new Random(DateTime.Now.Millisecond);
            posX = r.Next(20, 40); // Columna al azar entre 20 y 40
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine("||    Lista de estudiantes        ||");
            Console.WriteLine("________________________________________________________________________________________");
            Console.WriteLine("La siguiente tabla, mostrara los tados del estudiante, su definitiva y si aprobo o no. ");
            /*
            El cursor es el punto desde el cuál se empieza a escribir el texto;
            Para mostrar el texto como si fuera una tabla, hay que cambiar la posición
            del cursor; SetCursorPosition(x, y) recibe 2 números, y cambia la posición del cursor
            a la posición (x, y); x siendo el movimiento de izquierda-derecha, y siendo la altura arriba-abajo.
            */

            // Ponemos el cursor en (5, 20) y escribimos "Codigo:"
            Console.SetCursorPosition(5, y); Console.Write("|| Codigo: ");
            // Ponemos el cursor en (15, 20) y escribimos "Nombre:"
            Console.SetCursorPosition(15, y); Console.Write("|Nombre: ");
            // etc.
            Console.SetCursorPosition(25, y); Console.WriteLine("Correo: ");
            Console.SetCursorPosition(55, y); Console.WriteLine("Nota 1 :");
            Console.SetCursorPosition(65, y); Console.WriteLine("Nota 2 : ");
            Console.SetCursorPosition(75, y); Console.WriteLine("Nota 3 : ");
            Console.SetCursorPosition(85, y); Console.WriteLine("Definitiva: ");
            Console.SetCursorPosition(105, y); Console.WriteLine("¿Aprobó?: ||");

            // Por cada "itemEstudiantes" = un estudiante, in = en la Lista de Estudiantes
            foreach (Estudiante itemEstudiantes in ListaEstudiantes)
            {
                y++; // Baja una linea
                suma = itemEstudiantes.n1 + itemEstudiantes.n2 + itemEstudiantes.n3; // Suma las notas
                div = suma / 3; // Divide la suma entre 3 (promedio).

                if (div >= 3.5)
                    texto = "Aprobado";
                else
                    texto = "Reprobado";


                // Y al igual que antes...
                // Ponemos el cursor en (5, 20) y escribimos "El código de los estudiantes" = cod
                Console.SetCursorPosition(5, y); Console.Write(itemEstudiantes.cod);
                // Bla bla bla...
                Console.SetCursorPosition(15, y); Console.Write(itemEstudiantes.nom);
                Console.SetCursorPosition(25, y); Console.Write(itemEstudiantes.email);
                Console.SetCursorPosition(55, y); Console.Write(string.Format("{0:0.##}", itemEstudiantes.n1));
                Console.SetCursorPosition(65, y); Console.Write(string.Format("{0:0.##}", itemEstudiantes.n2));
                Console.SetCursorPosition(75, y); Console.Write(string.Format("{0:0.##}", itemEstudiantes.n3));
                Console.SetCursorPosition(85, y); Console.Write(string.Format("{0:0.##}", div));
                Console.SetCursorPosition(105, y); Console.Write(texto);
            }

            Console.Write("\n");
        }

        static void BuscarEstudiantes()
        {
            string codigo;
            bool codigVal = false;
            int posX, posY;
            Console.Title = "Bucar Estudiante ";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            posY = 2;  // En la fila 2
            Random r = new Random(DateTime.Now.Millisecond);
            posX = r.Next(20, 40); // Columna al azar entre 20 y 40
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine("||   Buscar estudiante :    ||");
            Console.WriteLine("___________________________________________________________________________");

            do
            {
                Console.WriteLine("_________________________________");
                Console.Write("|| Digite el codigo del estudiante a buscar: ");
                codigo = Console.ReadLine();
                if (!Validar.Vacio(codigo))
                    if (Validar.Numero(codigo))
                        codigVal = true;
            } while (!codigVal);

            if (Existe(Convert.ToInt32(codigo)))
            {
                Estudiante myEstudiante = ObtenerDatos(Convert.ToInt32(codigo));

                Console.WriteLine("Codigo: " + myEstudiante.cod);
                Console.WriteLine("Nombre: " + myEstudiante.nom);
                Console.WriteLine("Correo: " + myEstudiante.email);
                Console.WriteLine("Nota 1: " + myEstudiante.n1);
                Console.WriteLine("Nota 2: " + myEstudiante.n2);
                Console.WriteLine("Nota 3: " + myEstudiante.n3);

            }
            else
                Console.WriteLine("El estudiante identificado con codigo " + codigo + " no existe...");

        }

        static bool Existe(int codigo)
        {
            bool aux = false;
            foreach (Estudiante objetoEstudiante in ListaEstudiantes)
            {
                if (objetoEstudiante.cod == codigo)
                {
                    aux = true;
                    break;
                }
            }
            return aux;
        }

        static Estudiante ObtenerDatos(int codigo)
        {
            foreach (Estudiante objetoEstudiante in ListaEstudiantes)
            {
                if (objetoEstudiante.cod == codigo)
                    return objetoEstudiante;
            }
            return null;
        }

        static void DocumentacionXml()
        {
            Console.Clear();
            int posX, posY;

            Console.Title = "Documentacion";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            posY = 2;  // En la fila 2
            Random r = new Random(DateTime.Now.Millisecond);
            posX = r.Next(20, 40); // Columna al azar entre 20 y 40
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine("Bienvenido");

            Console.ForegroundColor = ConsoleColor.Black;
            posX = r.Next(10, 55); // Columna al azar entre 10 y 40
            Console.WriteLine("___________________________________________________________________________________________");
            Console.WriteLine("Este programa tiene como función, realizar distintos procesos con uno o varios estudiantes");
            Console.WriteLine("tales procesos como:");
            Console.WriteLine("_______________________________");
            Console.WriteLine("• Agregar Estudiantes.        |");
            Console.WriteLine("• Listar Estudiantes.         |");
            Console.WriteLine("• Buscar Estudiantes.         |");
            Console.WriteLine("_______________________________");
            Console.WriteLine("además de contar  con funciones como:");
            Console.WriteLine("_______________________________");
            Console.WriteLine("• Salir                       |");
            Console.WriteLine("• Guardar Archivo...          |");
            Console.WriteLine("• Cargar Archivo...           |");
            Console.WriteLine("_______________________________");
            Console.WriteLine("Este programa tiene como entrada, datos específicos del estudiante el cuál le permitirá realizar");
            Console.WriteLine("estos procesos con dichos datos, además de calcular y mostrar las notas y su definitiva ");
            Console.WriteLine("Para la elbaoración de este programa se crearon clases, cuyas serán la base de nuestro objeto");
            Console.WriteLine(" (Estudiante) y sus respectivos métodos");
            Console.WriteLine("A lo largo de nuestro código encontraremos varios comentarios, en el cuál específica algunas");
            Console.WriteLine("lineas de código y recomendaciones, como recordatorio para la elaboración del mismo");
            Console.WriteLine("En lo personal, a lo largo de este programa, presente varios inconvenientes en su ejecucion, pero a medida");
            Console.WriteLine("  que iba desarrollando aclaraba mis dudas y entendia la implementacion de que  clases  son  la base");
            Console.WriteLine("  de un proma en el cual se puede implementar mas metodos o procesos, pero me hace feliz poder");
            Console.WriteLine(" lograr con el objetivo del ejercicio, en poder evidenciar mis conocimientos vistos en clase ");
            Console.WriteLine("Por ultimo recuerda (EN EL ESFUERZO ESTA EL EXITO)");
            Console.WriteLine("Finalmente, muchas gracias y espero que como usuario, tu esperiencia hayas sido un exito");
           

        }
        static void EscribirXml()
        {
            XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiante>));
            TextWriter escribirXml = new StreamWriter("C:/Proyectos_visual_Studio_2019/ActividadEstudiante.xml");
            codificador.Serialize(escribirXml, ListaEstudiantes);
            escribirXml.Close();
            Console.WriteLine(" Archivo Guardado ---- ");
        }

        static void LeerXml()
        {
            ListaEstudiantes.Clear();
            if (File.Exists("C:/Proyectos_visual_Studio_2019/ActividadEstudiante.xml"))
            {
                XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiante>));
                FileStream leerXml = File.OpenRead("C:/Proyectos_visual_Studio_2019/ActividadEstudiante.xml");
                ListaEstudiantes = (List<Estudiante>)codificador.Deserialize(leerXml);
                leerXml.Close();
            }
            Console.WriteLine("Archivo Cargado !!!!  ");
        }



    }
}

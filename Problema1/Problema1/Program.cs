using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*********************************  
 Autor: Cristian García Martín 
 Fecha creación:      01/02/2018  
 Última modificación: 02/02/2018   
 Versión: 1.01 
***********************************/

namespace Problema1
{
    class Program
    {
        static public List<Aula> lista_aulas = new List<Aula>();
        static Aula p;
        static public int contadoraulas = 0;
        static int naulas = 5;

        static void Main(string[] args)
        {
            MenuGestionOrdenadores();
        }

        static void MenuGestionOrdenadores()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t === GESTIÓN DE ORDENADORES ===\n");
                Console.WriteLine("\t1. Aulas/Salas del Centro\n");
                Console.WriteLine("\t2. Ordenadores\n");
                Console.WriteLine("\t3. Busquedas\n");
                Console.WriteLine("\t4. Listados\n");
                Console.WriteLine("\t5. Configuración\n");
                Console.WriteLine("\t0. Salir\n");
                Console.Write("\tElige Opción: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MenuAulas();
                        break;

                    case "2":
                        Console.Write("Menú2");
                        break;

                    case "3":
                        Console.Write("Menú3");
                        break;

                    case "4":
                        Console.Write("Menú4");
                        break;

                    case "5":
                        Console.Write("Menú5");
                        break;

                    case "0":
                        break;
                }
            } while (opcion != "1" || opcion != "2" || opcion != "3" || opcion != "4" || opcion != "5" || opcion != "6");
        }
        static void MenuAulas()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t === AULAS ===\n");
                Console.WriteLine("\t1. Ver Aulas.\n");
                Console.WriteLine("\t2. Añadir Aulas.\n");
                Console.WriteLine("\t3. Borrar Aulas.\n");
                Console.WriteLine("\t4. Modificar Aulas.\n");
                Console.WriteLine("\t0. Volver al Menú Principal.\n");
                Console.Write("\tElige Opción: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        VerDatosAulas();
                        break;

                    case "2":
                        AñadirAulas();
                        break;

                    case "3":
                        BorrarDatosAula();
                        break;

                    case "4":
                        ModificarDatosAula();
                        break;

                    case "0":
                        MenuGestionOrdenadores();
                        break;
                }
            } while (opcion != "1" || opcion != "2" || opcion != "3" || opcion != "4" || opcion != "5" || opcion != "6");
        }

        static void AñadirAulas()
        {
            string opcion;

            do
            {
                int id_aula;

                string nombre_aula; string fecha_cm = DateTime.Now.ToString();

                Console.Clear();

                Console.WriteLine("\t\t === AÑADIR AULAS ===\n");

                Console.Write("\tIdentificador: ");
                id_aula = int.Parse(Console.ReadLine());

                Console.Write("\n\tNombre de Aula: ");
                nombre_aula = Console.ReadLine();

                if (contadoraulas == naulas)
                {
                    Console.WriteLine("\n\tLIMITE DE AULAS SUPERADO. NO SE HA PODIDO REGISTRAR.");
                }

                else
                {
                    p = new Aula();
                    p.LeerDatos(id_aula, nombre_aula, fecha_cm);
                    lista_aulas.Add(p);
                    Console.WriteLine("\n\t¡REGISTRO COMPLETADO CON EXITO!");
                }
 
                contadoraulas++;

                Console.Write("\n\t¿Más Aulas? (S/N): ");
                opcion = Console.ReadLine();
                //while (opcion != "S" || opcion != "s" || opcion != "N" || opcion != "n")
                //{
                //    Console.Write("\n\t\t**** ERROR – Introduzca Opción Valida\n");
                //    Console.Write("\n\t¿Más Aulas? (S/N): ");
                //    opcion = Console.ReadLine();
                //    opcion.ToUpper();
                //}
            } while (opcion == "S" || opcion == "s");
        }

        static void VerDatosAulas()
        {
            p.VerDatos();
        }

        static void BorrarDatosAula()
        {
            string opcion, eleccionborrar;

            do
            {
                int id_aula;

                Console.Clear();

                Console.WriteLine("\t\t === BORRAR AULAS ===\n");

                Console.Write("\tIdentificador: ");
                id_aula = int.Parse(Console.ReadLine());

                for (int i = 0; i < lista_aulas.Count; i++)
                {
                    string nombreaula = lista_aulas[i].getNombre;
                    string copianombreaula = nombreaula;
                    if (lista_aulas[i].getId == id_aula)
                    {
                        Console.WriteLine("\n\tSe procedera a borrar el: {0}", lista_aulas[i].getNombre);
                        Console.Write("\n\t¿Desea continuar borrando el aula? (S/N): ");
                        eleccionborrar = Console.ReadLine();

                        if (eleccionborrar == "S" || eleccionborrar == "s")
                        {
                            lista_aulas.RemoveAt(i);
                            Console.WriteLine("\n\t.......... {0} borrada.", copianombreaula);
                        }
                        else
                        {
                            Console.WriteLine("\n\t......... No se ha borrado el aula.");
                        }
                    }
                }

                Console.Write("\n\t¿Borrar más? (S/N): ");
                opcion = Console.ReadLine();
            } while (opcion == "S" || opcion == "s");
        }

        static void ModificarDatosAula()
        {
            string opcion;

            do
            {
                int id_aula;

                string nuevonombre;

                Console.Clear();

                Console.WriteLine("\t\t === MODIFICAR AULAS ===\n");

                Console.Write("\tIdentificador: ");
                id_aula = int.Parse(Console.ReadLine());

                for (int i = 0; i < lista_aulas.Count; i++)
                {
                    if (lista_aulas[i].getId == id_aula)
                    {
                        Console.Write("\n\tNuevo Nombre Aula: ");
                        nuevonombre = Console.ReadLine();
                        lista_aulas[i].getNombre = nuevonombre;
                    }
                }

                Console.Write("\n\t¿Modificar más aulas? (S/N): ");
                opcion = Console.ReadLine();
            } while (opcion == "S" || opcion == "s");
        }


    }
}

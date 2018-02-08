﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*********************************  
 Autor: Cristian García Martín 
 Fecha creación:      01/02/2018  
 Última modificación: 04/02/2018   
 Versión: 1.03
***********************************/

namespace Problema1
{
    class Program
    {
        static public List<Aula> lista_aulas = new List<Aula>();
        static public List<Ordenador> lista_ordenadores = new List<Ordenador>();

        static Aula p;
        static Ordenador o;

        static public int contadoraulas = 0;
        static int naulaspermitidas = 5;

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
                        MenuOrdenadores();
                        break;

                    case "3":
                        MenuBusquedas();
                        break;

                    case "4":
                        MenuListados();
                        break;

                    case "5":
                        MenuConfiguracion();
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

                if (lista_aulas.Count == naulaspermitidas)
                {
                    Console.Clear();

                    Console.WriteLine("\n\tLIMITE DE AULAS SUPERADO. NO SE HA PODIDO REGISTRAR.");
                }

                else
                { 
                Console.WriteLine("\t\t === AÑADIR AULAS ===\n");

                Console.Write("\tIdentificador: ");
                id_aula = int.Parse(Console.ReadLine());
                    if (id_aula == 0)
                    {
                        VerDatosAulas();
                        return;
                    }
                   while (id_aula < 1 || lista_aulas.Contains(obteneraula(id_aula)))
                    {
                        Console.WriteLine("\n\t** ERROR DE IDENTIFICADOR **");
                        Console.WriteLine("\n\tSe puede producir por:\n\t1· ID igual o inferior a 0\n\t2· ID ya utilizado");
                        Console.Write("\n\tIdentificador: ");
                        id_aula = int.Parse(Console.ReadLine());
                        if (id_aula == 0)
                        {
                            VerDatosAulas();
                            return;
                        }
                    }

                Console.Write("\n\tNombre de Aula: ");
                nombre_aula = Console.ReadLine();

                p = new Aula();
                p.LeerDatos(id_aula, nombre_aula, fecha_cm);
                lista_aulas.Add(p);

                Console.WriteLine("\n\t¡REGISTRO COMPLETADO CON EXITO!");
                }

                Console.Write("\n\t¿Más Aulas? (S/N): ");
                opcion = Console.ReadLine();
                opcion.ToLower();
            } while (opcion == "s");
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

                Console.Write("\tIdentificador (0 ver lista de Aulas): ");
                id_aula = int.Parse(Console.ReadLine());

                if (id_aula == 0)
                {
                    VerDatosAulas();
                    return;
                }
                while (id_aula < 1 || !lista_aulas.Contains(obteneraula(id_aula)))
                {
                    Console.WriteLine("\n\t** ERROR DE IDENTIFICADOR **");
                    Console.WriteLine("\n\tSe puede producir por:\n\t1· ID igual o inferior a 0\n\t2· ID no contiene Aula");
                    Console.Write("\n\tIdentificador (0 ver lista de Aulas): ");
                    id_aula = int.Parse(Console.ReadLine());
                    if (id_aula == 0)
                    {
                        VerDatosAulas();
                        return;
                    }
                }

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

                if (id_aula == 0)
                {
                    VerDatosAulas();
                    return;
                }
                while (id_aula < 1 || !lista_aulas.Contains(obteneraula(id_aula)))
                {
                    Console.WriteLine("\n\t** ERROR DE IDENTIFICADOR **");
                    Console.WriteLine("\n\tSe puede producir por:\n\t1· ID igual o inferior a 0\n\t2· ID no contiene Aula");
                    Console.Write("\n\tIdentificador (0 ver lista de Aulas): ");
                    id_aula = int.Parse(Console.ReadLine());
                    if (id_aula == 0)
                    {
                        VerDatosAulas();
                        return;
                    }
                }

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


        static void MenuOrdenadores()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t === ORDENADORES ===\n");
                Console.WriteLine("\t1. Ver Lista Ordenadores.\n");
                Console.WriteLine("\t2. Añadir Ordenador.\n");
                Console.WriteLine("\t3. Borrar Ordenador.\n");
                Console.WriteLine("\t4. Cambiar Ordenador de Aula.\n");
                Console.WriteLine("\t5. Modificar Ordenador.\n");
                Console.WriteLine("\t0. Volver al menú principal.\n");
                Console.Write("\tElige Opción: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        VerDatosOrdenadores();
                        break;

                    case "2":
                        AñadirOrdenador();
                        break;

                    case "3":
                        BorrarDatosOrdenador();
                        break;

                    case "4":
                        CambiarUbicacionOrdenador();
                        break;

                    case "5":
                        ModificarOrdenadores();
                        break;

                    case "0":
                        MenuGestionOrdenadores();
                        break;
                }
            } while (opcion != "1" || opcion != "2" || opcion != "3" || opcion != "4" || opcion != "5" || opcion != "6");
        }

        static void AñadirOrdenador()
        {
            string opcion;

            do
            {
                int id_aula;

                string id, ram, discoduro, procesador, tvideo, aplicaciones;
                string fecha_cm = DateTime.Now.ToString();

                Console.Clear();

                Console.WriteLine("\t\t === AÑADIR ORDENADOR ===\n");

                Console.Write("\tIdentificador ordenador (0 ver lista ordenadores): ");
                id = Console.ReadLine();

                if (id == "0")
                {
                    VerDatosOrdenadores();
                    return;
                }
                while (lista_ordenadores.Contains(obtenerordenador(id)))
                {
                    Console.WriteLine("\n\t** ERROR DE IDENTIFICADOR DE ORDENADOR**");
                    Console.WriteLine("\n\tSe puede producir por:\n\t1· Nombre de PC ya utilizado");
                    Console.Write("\tIdentificador ordenador (0 ver lista ordenadores): ");
                    id = Console.ReadLine();
                    if (id == "0")
                    {
                        VerDatosOrdenadores();
                        return;
                    }
                }

                Console.Write("\tId. Aula en la que se encuentra (0 ver lista): ");
                id_aula = int.Parse(Console.ReadLine());

                if (id_aula == 0)
                {
                    VerDatosAulas();
                    return;
                }
                while (id_aula < 1 || !lista_aulas.Contains(obteneraula(id_aula)))
                {
                    Console.WriteLine("\n\t** ERROR DE IDENTIFICADOR **");
                    Console.WriteLine("\n\tSe puede producir por:\n\t1· ID igual o inferior a 0\n\t2· ID no contiene Aula");
                    Console.Write("\n\n\n\tIdentificador (0 ver lista de Aulas): ");
                    id_aula = int.Parse(Console.ReadLine());
                    if (id_aula == 0)
                    {
                        VerDatosAulas();
                        return;
                    }
                }

                Aula aula = obteneraula(id_aula);

                Console.WriteLine("\n\tIntroduzca las características del <{0}>", id);

                Console.Write("\n\tRAM: ");
                ram = Console.ReadLine();

                Console.Write("\n\tDisco Duro: ");
                discoduro = Console.ReadLine();

                Console.Write("\n\tProcesador: ");
                procesador = Console.ReadLine();

                Console.Write("\n\tTarjeta Gráfica: ");
                tvideo = Console.ReadLine();

                Console.WriteLine("\n\tIntroduzca las aplicaciones (separadas por comas) del <{0}>", id);
                Console.Write("\t");
                aplicaciones = Console.ReadLine();

                o = new Ordenador();
                o.LeerDatos(id, aula, ram, discoduro, procesador, tvideo, aplicaciones, fecha_cm);
                lista_ordenadores.Add(o);
                List<Ordenador> lista = aula.getLista; // devuelve la lista de ordenadores del aula que le asignamos
                lista.Add(o);
                Console.WriteLine("\n\t. . . . . Ordenador añadido correctamente.");

                Console.Write("\n\t¿Más Ordenadores? (S/N): ");
                opcion = Console.ReadLine();
            } while (opcion == "S" || opcion == "s");
        }

        static void VerDatosOrdenadores()
        {
            o.VerDatos();
        }

        static void BorrarDatosOrdenador()
        {
            string opcion, eleccionborrar;

            do
            {
                string id;

                Console.Clear();

                Console.WriteLine("\t\t === BORRAR ORDENADORES ===\n");

                Console.Write("\tIdentificador (0 ver lista de ordenadores):");
                Console.Write("\n\t");
                id = Console.ReadLine();
                if (id == "0")
                {
                    VerDatosOrdenadores();
                    return;
                }
                while (!lista_ordenadores.Contains(obtenerordenador(id)))
                {
                    Console.WriteLine("\n\t** ERROR DE IDENTIFICADOR DE ORDENADOR**");
                    Console.WriteLine("\n\tSe puede producir por:\n\t1· La lista de ordenadores no contiene ese ordenador.");
                    Console.Write("\n\tIdentificador ordenador (0 ver lista ordenadores): ");
                    id = Console.ReadLine();
                    if (id == "0")
                    {
                        VerDatosOrdenadores();
                        return;
                    }
                }

                for (int i = 0; i < lista_ordenadores.Count; i++)
                {
                    string nombreordenador = lista_ordenadores[i].getId;
                    string copianombreaula = nombreordenador;
                    Ordenador ordenadorborrar = obtenerordenador(id);
                    if (lista_ordenadores[i].getId == id)
                    {
                        Console.WriteLine("\n\tSe procedera a borrar el ordenador <{0}>\n\tSituado en el aula <{1}>", lista_ordenadores[i].getId, lista_aulas[i].getNombre);
                        Console.Write("\n\t¿Desea continuar borrando el ordenador? (S/N): ");
                        eleccionborrar = Console.ReadLine();

                        if (eleccionborrar == "S" || eleccionborrar == "s")
                        {
                            lista_ordenadores.RemoveAt(i);
                            ordenadorborrar.Aula.getLista.Remove(ordenadorborrar);
                           
                            Console.WriteLine("\n\t.......... Ordenador borrado correctamente");
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

        static void CambiarUbicacionOrdenador()
        {
            string opcion;

            do
            {
                string id; int nuevaubicacion;

                Console.Clear();

                Console.WriteLine("\t\t === CAMBIAR UBICACIÓN ORDENADORES ===\n");

                Console.Write("\tIdentificador (0 ver lista de ordenadores):");
                Console.Write("\n\t");
                id = Console.ReadLine();

                if (id == "0")
                {
                    VerDatosOrdenadores();
                    return;
                }
                while (!lista_ordenadores.Contains(obtenerordenador(id)))
                {
                    Console.WriteLine("\n\t** ERROR DE IDENTIFICADOR DE ORDENADOR**");
                    Console.WriteLine("\n\tSe puede producir por:\n\t1· La lista de ordenadores no contiene ese ordenador.");
                    Console.Write("\n\tIdentificador ordenador (0 ver lista ordenadores): ");
                    id = Console.ReadLine();
                    if (id == "0")
                    {
                        VerDatosOrdenadores();
                        return;
                    }
                }

                o = obtenerordenador(id);
                Console.Write("Nueva Ubicación: ");
                nuevaubicacion = int.Parse(Console.ReadLine());
                p = obteneraula(nuevaubicacion);

                o.Aula.getLista.Remove(o);
                o.Aula = p;
                p.getLista.Add(o);
      
        
                Console.Write("\n\t¿Mover más? (S/N): ");
                opcion = Console.ReadLine();
            } while (opcion == "S" || opcion == "s");
        }

        static void ModificarOrdenadores()
        {
            string opcion;

            do
            {
                string id, opcionid, nuevaram, nuevodiscoduro, nuevoprocesador, nuevotvideo, nuevaaplicaciones, nuevoid;
                string ramactual, discoduroactual, procesadoractual, graficaactual, aplicacionesactuales;

                Console.Clear();

                Console.WriteLine("\t\t === MODIFICAR ORDENADORES ===\n");

                Console.Write("\tIdentificador Ordenador(0 ver lista de ordenadores): ");
                id = Console.ReadLine();

                if (id == "0")
                {
                    VerDatosOrdenadores();
                    return;
                }
                while (!lista_ordenadores.Contains(obtenerordenador(id)))
                {
                    Console.WriteLine("\n\t** ERROR DE IDENTIFICADOR DE ORDENADOR**");
                    Console.WriteLine("\n\tSe puede producir por:\n\t1· La lista de ordenadores no contiene ese ordenadores.");
                    Console.Write("\n\tIdentificador ordenador (0 ver lista ordenadores): ");
                    id = Console.ReadLine();
                    if (id == "0")
                    {
                        VerDatosOrdenadores();
                        return;
                    }
                }

                for (int i = 0; i < lista_ordenadores.Count; i++)
                {
                    if (lista_ordenadores[i].getId == id)
                    {
                        ramactual = lista_ordenadores[i].getRam;
                        discoduroactual = lista_ordenadores[i].getDiscoDuro;
                        procesadoractual = lista_ordenadores[i].getProcesador;
                        graficaactual = lista_ordenadores[i].getTvideo;
                        aplicacionesactuales = lista_ordenadores[i].getAplicaciones;
                        Console.Write("\n\t¿Desea Modificar su Identificador? (S/N): ");
                        opcionid = Console.ReadLine();
                        if (opcionid == "S" || opcionid == "s")
                        {
                            Console.Write("\n\tNuevo Identificador: ");
                            nuevoid = Console.ReadLine();
                            lista_ordenadores[i].getId = nuevoid;
                            Console.WriteLine("\n\t¡ID MODIFICADO!");
                        }

                        Console.WriteLine("\n\tEl ordenador se encuentra en el aula con ID <{0}>", lista_ordenadores[i].getId);
                        
                        Console.WriteLine("\n\tModifique las caracteristicas del <{0}> (en blanco se mantienen)", lista_ordenadores[i].getId);

                        Console.Write("\n\tRAM <{0}>: ", lista_ordenadores[i].getRam);
                        nuevaram = Console.ReadLine();
                        if (nuevaram == "")
                        {
                            lista_ordenadores[i].getRam = ramactual;
                        }
                        else
                        {
                            lista_ordenadores[i].getRam = nuevaram;
                        }
                        

                        Console.Write("\n\tDisco Duro <{0}>: ", lista_ordenadores[i].getDiscoDuro);
                        nuevodiscoduro = Console.ReadLine();
                        if (nuevodiscoduro == "")
                        {
                            lista_ordenadores[i].getDiscoDuro = discoduroactual;
                        }
                        else
                        {
                            lista_ordenadores[i].getDiscoDuro = nuevodiscoduro;
                        }

                        Console.Write("\n\tProcesador <{0}>: ", lista_ordenadores[i].getProcesador);
                        nuevoprocesador = Console.ReadLine();
                        if (nuevoprocesador == "")
                        {
                            lista_ordenadores[i].getProcesador = procesadoractual;
                        }
                        else
                        {
                            lista_ordenadores[i].getProcesador = nuevoprocesador;
                        }

                        Console.Write("\n\tTarjeta Gráfica <{0}>: ", lista_ordenadores[i].getTvideo);
                        nuevotvideo = Console.ReadLine();
                        if (nuevotvideo == "")
                        {
                            lista_ordenadores[i].getTvideo = graficaactual;
                        }
                        else
                        {
                            lista_ordenadores[i].getTvideo = nuevotvideo;
                        }

                        Console.Write("\n\tModifique las aplicaciones (separadas por comas) del <{0}> (en blanco se mantienen) <{1}>: ", lista_ordenadores[i].getId, lista_ordenadores[i].getAplicaciones);
                        nuevaaplicaciones = Console.ReadLine();
                        if (nuevaaplicaciones == "")
                        {
                            lista_ordenadores[i].getAplicaciones = aplicacionesactuales;
                        }
                        else
                        {
                            lista_ordenadores[i].getAplicaciones = nuevaaplicaciones;
                        }
                    }
                }
                Console.Write("\n\t¿Más ordenadores (S/N)?: ");
                opcion = Console.ReadLine();
            } while (opcion == "S" || opcion == "s");
        }


        static void MenuBusquedas()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t === BUSQUEDAS ===\n");
                Console.WriteLine("\t1. Buscar Ordenador Por Procesador.\n");
                Console.WriteLine("\t2. Buscar Ordenador Por APP.\n");
                Console.WriteLine("\t3. Buscar Ordenador Por Tarjeta de Video.\n");
                Console.WriteLine("\t0. Volver al menú principal.\n");
                Console.Write("\tElige Opción: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        BuscarPorProcesador();
                        break;

                    case "2":
                        BuscarPorAPP();
                        break;

                    case "3":
                        BuscarPorTvideo();
                        break;

                    case "0":
                        MenuGestionOrdenadores();
                        break;
                }
            } while (opcion != "1" || opcion != "2" || opcion != "3");
        }
        static void BuscarPorProcesador()
        {
            o.BuscarPorProcesador();
        }
        static void BuscarPorAPP()
        {
            o.BuscarPorAPPS();
        }
        static void BuscarPorTvideo()
        {
            o.BuscarPorTVideo();
        }


        static void MenuListados()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t === LISTADOS ===\n");
                Console.WriteLine("\t1. Nº de ordenadores por aula.\n");
                Console.WriteLine("\t2. Lista de Ordenadores ordenados por aula e identificador.\n");
                Console.WriteLine("\t3. Aplicaciones instaladas por cada ordenador.\n");
                Console.WriteLine("\t4. Características de cada ordenador.\n");
                Console.WriteLine("\t0. Volver al Menú Principal.\n");
                Console.Write("\tElige Opción: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        ListadoAulasOrdenadas();
                        break;

                    case "2":
                        DatosyAPP();
                        break;

                    case "3":
                        AplicacionesInstaladas();
                        break;

                    case "4":
                        CaracteristicasPC();
                        break;
                        

                    case "0":
                        MenuGestionOrdenadores();
                        break;
                }
            } while (opcion != "1" || opcion != "2" || opcion != "3" || opcion != "4" || opcion != "5" || opcion != "6");
        }

        static void ListadoAulasOrdenadas()
        {
            p.VerDatosListas();
        }

        static void DatosyAPP()
        {
            o.VerDatosOrdenadosYAPP();
        }

        static void AplicacionesInstaladas()
        {
            o.AplicacionesInstaladasOtroOrden();
        }

        static void CaracteristicasPC()
        {
            o.CaracteristicasOrdenador();
        }

        static void MenuConfiguracion()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t === CONFIGURACIÓN ===\n");
                Console.WriteLine("\t1. Número máximo de aulas.\n");
                Console.WriteLine("\t2. Número máximo de ordenadores por aula\n");
                Console.WriteLine("\t9. Inicialización automatica de pruebas\n");
                Console.WriteLine("\t0. Salir\n");
                Console.Write("\tElige Opción: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        CambiarNAulas();
                        break;

                    case "2":
                        break;

                    case "9":
                        InicializacionPruebas();
                        break;

                    case "0":
                        MenuGestionOrdenadores();
                        break;
                }
            } while (opcion != "1" || opcion != "2" || opcion != "3" || opcion != "4");
        }

        static void CambiarNAulas()
        {
            int nuevonumeroaulas;

            Console.Clear();
            Console.WriteLine("\t\t === CAMBIAR NÚMERO MAXIMO DE AULAS ===\n");
            Console.WriteLine("\tN· Actual de Aulas permitidas: {0}", naulaspermitidas);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\t[ATENCION]: El nuevo número de aulas permitidas no puede ser menor al anterior.\n");
            Console.ResetColor();

            Console.Write("\n\tCambiar N· De Aulas a: ");
            nuevonumeroaulas = int.Parse(Console.ReadLine());

            while (nuevonumeroaulas < naulaspermitidas)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\t✾ Atención: El nuevo número de aulas no puede ser menor al anterior.");
                Console.ResetColor();

                Console.Write("\n\tCambiar N· De Aulas a: ");
                nuevonumeroaulas = int.Parse(Console.ReadLine());
            }

            naulaspermitidas = nuevonumeroaulas; 
        }

        static void InicializacionPruebas()
        {
            Console.Clear();

            string fecha_cm = DateTime.Now.ToString();

            for (int i = 1; i <= 5; i++)
            {
                p = new Aula();
                p.LeerDatos(i, "Aula " + i, fecha_cm);
                lista_aulas.Add(p);
            }

                Aula aula = obteneraula(1);
                o = new Ordenador();
                o.LeerDatos("PC01", aula, "8,00 GB", "560,00 GB", "Intel i5", "Nvidia Force", "Win 7, Office 2010, Chrome", fecha_cm);
                lista_ordenadores.Add(o);
                List<Ordenador> lista = aula.getLista; // devuelve la lista de ordenadores del aula que le asignamos
                lista.Add(o);

                Aula aula2 = obteneraula(2);
                o = new Ordenador();
                o.LeerDatos("PC02", aula2, "8,00 GB", "560,00 GB", "Intel i5", "Nvidia Force", "Win 7, Office 2010, Chrome", fecha_cm);
                lista_ordenadores.Add(o);
                lista = aula2.getLista;
                lista.Add(o);


                Aula aula3 = obteneraula(4);
                o = new Ordenador();
                o.LeerDatos("PC03", aula3, "8,00 GB", "560,00 GB", "Intel i5", "Nvidia Force", "Win 7, Office 2010, Chrome", fecha_cm);
                lista_ordenadores.Add(o);
            lista = aula3.getLista;
            lista.Add(o);

            Aula aula4 = obteneraula(5);
                o = new Ordenador();
                o.LeerDatos("PC04", aula4, "8,00 GB", "560,00 GB", "Intel i5", "Nvidia Force", "Win 7, Office 2010, Chrome", fecha_cm);
                lista_ordenadores.Add(o);
            lista = aula4.getLista;
            lista.Add(o);


            for (int b = 5; b <= 8; b++)
            {
                Aula aula5 = obteneraula(3);
                o = new Ordenador();
                o.LeerDatos("PC0" + b, aula5, "4,00 GB", "860,00 GB", "Intel Celeron", "Nvidia Force", "Ubuntu 14, Gedit, LibreOffice 5", fecha_cm);

                if (b == 6)
                {
                    o.LeerDatos("PC0" + b, aula5, "4,00 GB", "860,00 GB", "Intel Celeron", "Nvidia Force", "Ubuntu 14, Gedit, LibreOffice 5", fecha_cm);
                }

                if (b == 7)
                {
                    o.LeerDatos("PC0" + b, aula5, "4,00 GB", "860,00 GB", "Intel Celeron", "Nvidia Force", "Ubuntu 14, Gedit, LibreOffice 5", fecha_cm);
                }

                if (b == 8)
                {
                    o.LeerDatos("PC0" + b, aula5, "4,00 GB", "860,00 GB", "Intel Celeron", "Nvidia Force", "Ubuntu 14, Gedit, LibreOffice 5", fecha_cm);
                }

                lista_ordenadores.Add(o);
                lista = aula5.getLista;
                lista.Add(o);
            }

            Console.WriteLine("\n\n\t\t MODO INICIALIZACIÓN PARA PRUEBAS ACTIVADO \n");
            Console.WriteLine("\t\t PULSE INTRO PARA VOLVER ATRÁS \n");
            Console.ReadLine();
        }

        static Aula obteneraula (int id)
        {
            Aula aula = new Aula();
            for (int i = 0; i < lista_aulas.Count; i++)
            {
                if (lista_aulas[i].getId == id)
                {
                    aula = lista_aulas[i];
      
                }
            }

            return aula;
        }

        static Ordenador obtenerordenador(string nombre)
        {
            Ordenador ordenador = new Ordenador();
            for (int i = 0; i < lista_ordenadores.Count; i++)
            {
                if (lista_ordenadores[i].getId == nombre)
                {
                    ordenador = lista_ordenadores[i];

                }
            }

            return ordenador;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1
{
    class Ordenador
    {
        int ida;
        string id, ram, discoduro, procesador, tvideo, aplicaciones;
        string fecha = DateTime.Now.ToString();
        Aula aula;

        public void LeerDatos(string id, Aula aula, string ram, string discoduro, string procesador, string tvideo, string aplicaciones, string fecha)
        {
            this.id = id;
            this.aula = aula;
            this.ram = ram;
            this.discoduro = discoduro;
            this.procesador = procesador;
            this.tvideo = tvideo;
            this.aplicaciones = aplicaciones;
            this.fecha = fecha;
        }

        public void VerDatos()
        {
            Console.Clear();
            if (Program.lista_ordenadores.Count == 0)
            {
                Console.WriteLine("\n\n\t\t\t ¡NO HAY ORDENADORES REGISTRADOS! ");
                Console.WriteLine("\n\n\t\t\t PULSA INTRO PARA VOLVER ATRÁS ");
                Console.ReadLine();
            }
            else
            {
                Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.id).ToArray();
                Console.WriteLine("\t\t=== LISTADO DE ORDENADORES ===\n");
                Console.WriteLine("\tId.\tNombre\t\tFecha Modificacion\n");
                Console.WriteLine("\t== \t====== \t\t==================");
                foreach (var c in sorted)
                {
                        Console.Write("\n\t{0}\t{1}\t\t{2}\n", c.id, c.NombreAula , c.fecha);
                }
                Console.ReadLine();
            }
        }


        public string getId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                fecha = DateTime.Now.ToString();
            }
        }

        public string NombreAula
        {
            get
            {
                return aula.getNombre; 
            }
        }

        public int getIda
        {
            get
            {
                return ida;
            }
            set
            {
                ida = value;
                fecha = DateTime.Now.ToString();
            }
        }

        public string getRam
        {
            get
            {
                return ram;
            }
            set
            {
                ram = value;
                fecha = DateTime.Now.ToString();
            }
        }

        public string getDiscoDuro
        {
            get
            {
                return discoduro;
            }
            set
            {
                discoduro = value;
                fecha = DateTime.Now.ToString();
            }
        }

        public string getProcesador
        {
            get
            {
                return procesador;
            }
            set
            {
                procesador = value;
                fecha = DateTime.Now.ToString();
            }
        }

        public string getTvideo
        {
            get
            {
                return tvideo;
            }
            set
            {
                tvideo = value;
                fecha = DateTime.Now.ToString();
            }
        }

        public string getAplicaciones
        {
            get
            {
                return aplicaciones;
            }
            set
            {
                aplicaciones = value;
                fecha = DateTime.Now.ToString();
            }
        }

        public void VerDatosOrdenadosYAPP()
        {
            Console.Clear();
            string caracteres;
            Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.id).ToArray();
            int nordenadores = 0;
            nordenadores = Program.lista_ordenadores.Count;
            Console.WriteLine("\t\t=== LISTADO DE ORDENADORES ORDENADOS POR AULA E IDENT. ===\n");
            Console.WriteLine("\tId.\tAula\t\tAplicaciones\n");
            Console.WriteLine("\t== \t====== \t\t==================");
                foreach (var c in sorted)
                {
                        if (c.aplicaciones.Length > 30)
                        {
                            caracteres = c.aplicaciones.Substring(0, 30);
                            Console.Write("\n\t{0}\t{1}\t\t{2}\n", c.id, c.NombreAula, caracteres);
                        }
                        else if (c.aplicaciones.Length < 30)
                        {
                            Console.Write("\n\t{0}\t{1}\t\t{2}\n", c.id, c.NombreAula, c.aplicaciones);
                        }
                    
                }
            Console.WriteLine("\n\t==========================================");
            Console.WriteLine("\n\tNº Ordenadores: {0}", nordenadores);
            Console.ReadLine();
            }

        public void AplicacionesInstaladasOtroOrden()
        {
            Console.Clear();
            Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.ida).ToArray();
            int nordenadores = 0;
            nordenadores = Program.lista_ordenadores.Count;
            Console.WriteLine("\t\t=== LISTADO DE ORDENADORES ORDENADOS POR AULA E IDENT. ===\n");
            Console.WriteLine("\tId.\t\tAplicaciones\n");
            Console.WriteLine("\t== \t\t==================");
            foreach (var c in sorted)
            {
                if (c.aplicaciones.Length > 70)
                {
                    Console.Write("\n\t{0}\t\t", c.id);
                    for (int i = 0; i < 70; i++)
                    {
                        Console.Write(c.aplicaciones[i]);
                    }
                    Console.Write("\n\t\t       ", c.id);
                    for (int i = 70; i < c.aplicaciones.Length; i++)
                    {
                        Console.Write(c.aplicaciones[i]);
                    }
                }
                else
                {
                    Console.Write("\n\t{0}\t\t{1}\n", c.id, c.aplicaciones);
                }

            }
            Console.WriteLine("\n\n\tNº Ordenadores: {0}", nordenadores);
            Console.ReadLine();
    } 

        public void CaracteristicasOrdenador()
        {
            Console.Clear();
            Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.id).ToArray();
            int nordenadores = 0;
            nordenadores = Program.lista_ordenadores.Count;
            Console.WriteLine("\t\t=== Caracteristicas de Ordenador ===\n");
            Console.WriteLine("\tId.\t\tRAM \t\tDisco D. \tT.Grác. \tProces. \tAltaMod.\n");
            Console.WriteLine("\t== \t\t====== \t\t======== \t======== \t====== \t\t======");
                foreach (var c in sorted)
                {
                    string fechabuena = c.fecha.Substring(0, 10);
                    Console.Write("\n\t{0}\t\t{1}\t\t{2}\t{3}\t{4}\t{5}\n", c.id, c.getRam, c.getDiscoDuro, c.getTvideo, c.getProcesador, fechabuena);
                }
            Console.WriteLine("\n\t==========================================");
            Console.WriteLine("\n\tNº Ordenadores: {0}", Program.lista_ordenadores.Count);
            Console.ReadLine();
        }

        public void BuscarPorProcesador()
        {
            string opcion;
            do
            {
                Console.Clear();
                string procesadorbusqueda;
                Console.WriteLine("\n\t\t=== Busqueda de Ordenador por Procesador ===\n");
                Console.Write("\tIntroduce el nombre exacto del procesador buscado: ");
                procesadorbusqueda = Console.ReadLine();

                int npcs = 0;
                Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.id).ToArray();

                Console.WriteLine("\n\tId.\t\tAula \t\tProcesador");
                Console.WriteLine("\n\t== \t\t====== \t\t========");
                foreach (var c in sorted)
                {
                    if (c.procesador.ToLower().Contains(procesadorbusqueda.ToLower()))
                    {
                        npcs++;
                        Console.Write("\n\t{0}\t\t{1}\t\t{2}\n", c.id, c.NombreAula, c.procesador);
                    }
                    else if (npcs == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t\tNo existe resultados relacionados con el procesador {0}.", procesadorbusqueda);
                        break;
                    }
                }

                Console.WriteLine("\n\t==========================================");
                Console.WriteLine("\n\tNº Ordenadores: {0}", npcs);
                Console.Write("\n\t¿Desea realizar otra busqueda (S/N)?: ");
                opcion = Console.ReadLine();
            } while (opcion == "S" || opcion == "s");
        }

        public void BuscarPorAPPS()
        {
            string opcion;
            do
            {
                Console.Clear();
                string appbuscada;
                Console.WriteLine("\n\t\t=== Busqueda de Ordenador por APPS ===\n");
                Console.Write("\tIntroduce el nombre exacto de la APP buscada: ");
                appbuscada = Console.ReadLine();

                int npcs = 0;
                Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.id).ToArray();

                Console.WriteLine("\n\tId.\t\tAula \t\tAplicaciones");
                Console.WriteLine("\n\t== \t\t====== \t\t========");
                foreach (var c in sorted)
                {
                    if (c.aplicaciones.ToLower().Contains(appbuscada.ToLower()))
                    {
                        Console.Write("\n\t{0}\t\t{1}\t\t{2}\n", c.id, c.NombreAula, c.aplicaciones);
                        npcs++;
                        Console.WriteLine("\n\t==========================================");
                        Console.WriteLine("\n\tNº Ordenadores: {0}", npcs);
                    }
                    else if (npcs == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t\tNo existe resultados relacionados con la APP buscada {0}.", appbuscada);
                        break;
                    }
                }

                Console.Write("\n\t¿Desea realizar otra busqueda (S/N)?: ");
                opcion = Console.ReadLine();
            } while (opcion == "S" || opcion == "s");
        }

        public void BuscarPorTVideo()
        {
            string opcion;
            do
            {
                Console.Clear();
                string tvideobuscada;
                Console.WriteLine("\n\t\t=== Busqueda de Ordenador por Tarjeta de Video ===\n");
                Console.Write("\tIntroduce el nombre exacto de la Tarjeta de Video: ");
                tvideobuscada = Console.ReadLine();

                int npcs = 0;
                Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.id).ToArray();

                Console.WriteLine("\n\tId.\t\tAula \t\tT.Video");
                Console.WriteLine("\n\t== \t\t====== \t\t========");
                foreach (var c in sorted)
                {
                    if (c.tvideo.ToLower().Contains(tvideobuscada.ToLower()))
                    {
                        npcs++;
                        Console.Write("\n\t{0}\t\t{1}\t\t{2}\n", c.id, c.NombreAula, c.tvideo);
                    }
                    else if (npcs == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t\tNo existe resultados relacionados con la tarjeta de video {0}.", tvideobuscada);
                        break;
                    }
                }

                Console.WriteLine("\n\t==========================================");
                Console.WriteLine("\n\tNº Ordenadores: {0}", npcs);
                Console.Write("\n\t¿Desea realizar otra busqueda (S/N)?: ");
                opcion = Console.ReadLine();
            } while (opcion == "S" || opcion == "s");
        }

        public Aula Aula
        {
            get
            {
                return aula;
            }

            set
            {
                aula = value;
            }
        }
    }
}
    


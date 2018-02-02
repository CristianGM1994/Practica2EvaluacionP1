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

        public void LeerDatos(string id, int ida, string ram, string discoduro, string procesador, string tvideo, string aplicaciones, string fecha)
        {
            this.id = id;
            this.ida = ida;
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
            if (Program.lista_ordenadores.Capacity < 1)
            {
                Console.WriteLine("\n\n\t\t\t ¡NO HAY AULAS REGISTRADAS! ");
                Console.WriteLine("\n\n\t\t\t PULSA INTRO PARA VOLVER ATRÁS ");
                Console.ReadLine();
            }
            else
            {
                Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.id).ToArray();
                Console.WriteLine("\t\t=== LISTADO DE ORDENADORES ===\n");
                Console.WriteLine("\tId.\tNombre\t\tFecha Modificacion\n");
                Console.WriteLine("\t== \t====== \t\t==================");
                foreach (var a in Program.lista_aulas)
                {
                    foreach (var c in sorted)
                    {
                        if (a.getId == c.ida)
                        {
                            Console.Write("\n\t{0}\t{1}\t\t{2}\n", c.id, a.getNombre, c.fecha);
                        }
                    }
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

        public void VerDatosListas()
        {
            Console.Clear();
                int npcs = 0;
                Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Aula => Aula.ida).ToArray();
                Console.WriteLine("\t\t=== LISTADO DE ORDENADORES ===\n");
                Console.WriteLine("\tId.\tNombre\t\tNº Ordenadores\n");
                Console.WriteLine("\t== \t====== \t\t==================");
                foreach (var c in sorted)
                {
                    foreach (var a in Program.lista_aulas)
                    {
                        if (a.getId == c.ida)
                        {
                            npcs++;
                        }
                        Console.Write("\n\t{0}\t{1}\t\t\t{2}\n", c.ida, a.getNombre, npcs);
                    }
                }
                Console.ReadLine();
        }

    }

}
    


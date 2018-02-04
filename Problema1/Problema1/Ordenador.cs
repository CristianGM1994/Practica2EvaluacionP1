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
            for (int i = 0; i < Program.lista_ordenadores.Count; i++)
            {
                if (Program.lista_ordenadores[i].getIda == Program.lista_aulas[i].getId)
                {
                    npcs++;
                }
                Console.Write("\n\t{0}\t{1}\t\t{2}\n", Program.lista_aulas[i].getId, Program.lista_aulas[i].getNombre, npcs);
            }

            Console.ReadLine();
        } //NO FUNCIONA

        public void VerDatosOrdenadosYAPP()
        {
            Console.Clear();
            string caracteres;
            Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.ida).ToArray();
            int nordenadores = 0;
            nordenadores = Program.lista_ordenadores.Count;
            Console.WriteLine("\t\t=== LISTADO DE ORDENADORES ORDENADOS POR AULA E IDENT. ===\n");
            Console.WriteLine("\tId.\tAula\t\tAplicaciones\n");
            Console.WriteLine("\t== \t====== \t\t==================");
            foreach (var a in Program.lista_aulas)
            {
                foreach (var c in sorted)
                {
                    if (a.getId == c.ida)
                    {
                        if (c.aplicaciones.Length > 30)
                        {
                            caracteres = c.aplicaciones.Substring(0, 30);
                            Console.Write("\n\t{0}\t{1}\t\t{2}\n", c.id, a.getNombre, caracteres);
                        }
                        else if (c.aplicaciones.Length < 30)
                        {
                            Console.Write("\n\t{0}\t{1}\t\t{2}\n", c.id, a.getNombre, c.aplicaciones);
                        }
                    }
                }
            }
            Console.WriteLine("\n\t==========================================");
            Console.WriteLine("\n\tNº Ordenadores: {0}", nordenadores);
            Console.ReadLine();
            }

        public void AplicacionesInstaladasOtroOrden()
        {
            
            Console.Clear();
            Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.id).ToArray();
            int nordenadores = 0;
            nordenadores = Program.lista_ordenadores.Count;
            Console.WriteLine("\t\t=== APLICACIONES INSTALADAS POR ORDENADO ===\n");
            Console.WriteLine("\tId.\tAplicaciones\n");
            Console.WriteLine("\t== \t=========================================");
            foreach (var a in Program.lista_aulas)
            {
                foreach (var c in sorted)
                {
                    int tamañogetnombreyhuecos = 8+ c.id.Length;
                    int tamañototal = tamañogetnombreyhuecos + c.aplicaciones.Length;
                    int diferencia = tamañototal - Console.WindowWidth;
                    int diferenciastring = c.aplicaciones.Length - diferencia;
                    string aplicaciones1 = c.aplicaciones.Substring(0, Console.WindowWidth - diferencia);
                    //string aplicaciones2 = c.aplicaciones.Substring(Console.WindowWidth - diferencia, Console.WindowWidth - diferencia);
                    if (a.getId == c.ida)
                    {
                        if (tamañototal > Console.WindowWidth)
                        {
                            //Console.WriteLine("{0} aplicaciones total", aplicaciones.Length);
                            //Console.WriteLine("{0} tamañototal", tamañototal);
                            //Console.WriteLine("{0} diferencia", diferencia);
                            //Console.WriteLine("{0} diferenciastring", diferenciastring);
                            Console.WriteLine("{0} Tamaño Primera Cadena", aplicaciones1.Length);
                            Console.Write("\n\t{0}\t{1}\n\t\t", c.id, aplicaciones1);
                        }
                    }
                }
            }
            Console.WriteLine("\n\t==========================================");
            Console.WriteLine("\n\tNº Ordenadores: {0}", nordenadores);
            Console.ReadLine();
        } //BOCETO

        public void CaracteristicasOrdenador()
        {
            Console.Clear();
            Ordenador[] sorted = Program.lista_ordenadores.OrderBy(Ordenador => Ordenador.id).ToArray();
            int nordenadores = 0;
            nordenadores = Program.lista_ordenadores.Count;
            Console.WriteLine("\t\t=== Caracteristicas de Ordenador ===\n");
            Console.WriteLine("\tId.\t\tRAM \t\tDisco D. \tT.Grác. \tProces. \tAltaMod.\n");
            Console.WriteLine("\t== \t\t====== \t\t======== \t======== \t====== \t\t======");
            foreach (var a in Program.lista_aulas)
            {
                foreach (var c in sorted)
                {
                    if (a.getId == c.ida)
                    {
                        string fechabuena = c.fecha.Substring(0, 10);
                        Console.Write("\n\t{0}\t\t{1}\t\t{2}\t{3}\t{4}\t{5}\n", c.id, c.getRam, c.getDiscoDuro, c.getTvideo, c.getProcesador, fechabuena);
                    }
                }
            }
            Console.WriteLine("\n\t==========================================");
            Console.WriteLine("\n\tNº Ordenadores: {0}", nordenadores);
            Console.ReadLine();
        }

        public void BuscarPorProcesador()
        {
            Console.Clear();
            string procesadorbusqueda;
            int nordenadores = 0;
            Console.WriteLine("\n\t\t=== Busqueda de Ordenador por Procesador ===\n");
            Console.Write("\tIntroduce el nombre exacto del procesador buscado: ");
            procesadorbusqueda = Console.ReadLine();

            Console.WriteLine("\n\tId.\t\tAula \t\tProcesador");
            Console.WriteLine("\n\t== \t\t====== \t\t========");
            foreach (var c in Program.lista_ordenadores)
            {
                foreach (var a in Program.lista_aulas)
                 {
                    if (a.getId == c.ida && c.getProcesador.ToLower() == procesadorbusqueda.ToLower())
                    {
                        Console.Write("\n\t{0}\t\t{1}\t\t{2}\n", c.id, a.getNombre, c.getProcesador);
                        nordenadores++;
                    }
                }
            }
            Console.WriteLine("\n\t==========================================");
            Console.WriteLine("\n\tNº Ordenadores: {0}", nordenadores);
            Console.ReadLine();
        }
    }
}
    


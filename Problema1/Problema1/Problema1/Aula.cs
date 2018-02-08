using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1
{
    class Aula
    {
        int id;
        string nombre;
        string fecha = DateTime.Now.ToString();
        List<Ordenador> lista_ordenadores;

        /// <summary>
        /// Lee los campos ID y Nombre
        /// </summary>
        /// <param name="id">Identificador Aula</param>
        /// <param name="nombre">Nombre Aula</param>
        /// <param name="fecha">Determina Fecha Actual Tanto de Creación en un principio como de modificación del Aula</param>
        public void LeerDatos(int id, string nombre, string fecha)
        {
            this.id = id;
            this.nombre = nombre;
            this.fecha = fecha;
            lista_ordenadores = new List<Ordenador>();
        }

        public void VerDatos()
        {
            Console.Clear();
            if (Program.lista_aulas.Count() == 0)
            {
                Console.WriteLine("\n\n\t\t\t ¡NO HAY AULAS REGISTRADAS! ");
                Console.WriteLine("\n\n\t\t\t PULSA INTRO PARA VOLVER ATRÁS ");
                Console.ReadLine();
            }
            else
            {
                Aula[] sorted = Program.lista_aulas.OrderBy(Aula => Aula.id).ToArray();
                Console.WriteLine("\t\t=== LISTADO DE AULAS ===\n");
                Console.WriteLine("\tId.\tNombre\tN· Ordenadores\tFecha y hora modificación\n");
                Console.WriteLine("\t== \t====== \t============== \t==========================");
                foreach (var c in sorted)
                {
                    Console.Write("\n\t{0}\t{1}\t\t{2}\t{3}\n", c.id, c.nombre,c.lista_ordenadores.Count, c.fecha);
                }
                Console.ReadLine();
            }
        }

        public void VerDatosListas()
        {
            Console.Clear();
            int npcs = 0;
            if (Program.lista_aulas.Count == 0)
            {
                Console.WriteLine("\n\n\t\t\t ¡NO HAY AULAS REGISTRADAS! ");
                Console.WriteLine("\n\n\t\t\t PULSA INTRO PARA VOLVER ATRÁS ");
                Console.ReadLine();
            }
            else
            {
                Aula[] sorted = Program.lista_aulas.OrderBy(Aula => Aula.getNombre).ToArray();
                Console.WriteLine("\t\t=== LISTADO DE AULAS ===\n");
                Console.WriteLine("\tId.\tNombre\tN· Ordenadores\n");
                Console.WriteLine("\t== \t====== \t==============");
                foreach (var c in sorted)
                {
                    Console.Write("\n\t{0}\t{1}\t\t{2}\n", c.id, c.nombre, c.lista_ordenadores.Count);
                    npcs++;
                }
                Console.WriteLine("\n\tN· De Aulas: {0}", npcs);
                Console.ReadLine();
            }
        } 

        public int getId
        {
            get
            {
                return id;
            }
            set
            {
                value = id;
            }
        }

        public string getNombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                fecha = DateTime.Now.ToString();
            }
        }

        public List<Ordenador> getLista
        {
            get
            {
                return lista_ordenadores;
            }
        }
    }
}
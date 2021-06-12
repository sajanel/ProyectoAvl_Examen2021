using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAvl_Examen.TablaHash.ListaColisiones;

namespace ProyectoAvl_Examen.TablaHash
{
    class TablaDispercion
    {
        public static readonly int M = 99;
        public static readonly double R = 0.618034;
        int Posicion;
        public int cont { get; set; }

        ListaSimple[] tabla = new ListaSimple[M];


        public int DispersionMod(String Clave)
        {
            double x;
            x = Convert.ToDouble(Clave.Substring(0, 4));
            return Convert.ToInt16(x % M);
        }

        public void Insertar(Object Dato, String Clave)
        {
            Posicion = DispersionMod(Clave);
            if (tabla[Posicion] == null)
            {
                tabla[Posicion] = new ListaSimple();
            }
            tabla[Posicion].insertarCabezaLista(Dato);
            cont++;
        }

        public void Eliminar(String Clave)
        {
            Posicion = DispersionMod(Clave);
            tabla[Posicion] = null;
        }

        public object Buscar(String Clave)
        {
           
            Posicion = DispersionMod(Clave);
           
            if (tabla[Posicion] == null)
                return null;
            else


                return tabla[Posicion].BuscarNodo(Clave);
                
        }

        public string Mostrar(Nodo valor)
        {
            string message = "";
       
            foreach (var item in tabla)
            {
                if (item != null)
                {
                    message = item.MuestraLista(valor).ToString();
                    return message;
                }
                else
                    return message;
            }
            return message;
        }
    }
    }


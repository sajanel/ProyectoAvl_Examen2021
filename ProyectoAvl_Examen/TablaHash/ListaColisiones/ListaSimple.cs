using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAvl_Examen.TablaHash.ListaColisiones
{
    class ListaSimple
    {
        public Nodo primero;

        public ListaSimple()
        {
            primero = null;
        }
        public bool listaVacia() 
        {
            return primero.Enlace != null;
        }

        public ListaSimple insertarCabezaLista(Object vDato)
        {
            Nodo nuevo;
            nuevo = new Nodo(vDato);
            nuevo.Enlace = primero;
            primero = nuevo;
            return this;
        }

        public Object BuscarNodo(Object pValor)
        {
            Nodo temp = primero;
            int posicion = 1;
            int aux=0;

            while (temp != null && aux ==0)
            { 
                    if (datoConvert(temp.Dato.ToString()).Equals(pValor) == true)
                    {
                        aux = 1;
                    }
                    else
                    {
                        temp = temp.Enlace;
                        posicion++;
                    }                  
                
            }
            return (temp == null) ? null : temp.Dato.ToString();
        }

        public String datoConvert(string valor) 
        {
            string nuevoDato = valor;
            string[] wordSrings = nuevoDato.Split('-', ' ');

            return wordSrings[0] + wordSrings[1];
        }

        //Verificar este metodo para mostrar
        public String MuestraLista(Nodo temp)
        {
            temp = primero;
            String resultado = "";
            while (temp != null)
            {
                resultado = resultado + temp.Dato + ";";
                temp = temp.Enlace;
            }
            return resultado;
        }



        // //converId = temp.Dato = Juan = 108104;
        // while (temp != null && !temp.Dato.ToString().Equals(pValor))
        // {
        //     temp = temp.Enlace;
        //     posicion++;

        // } 
        ////return (temp == null) ? null : converId(temp.Dato.ToString());
        // return (temp == null) ? null : temp.Dato;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAvl_Examen.Estucturas_Arbol
{
    //Creamos esta clase Nodo
   public class Nodo
    {
        //Estructura basica de un arbol dato o raiz, izquierda, derecha
        public object datoNodo;
        public Nodo izq;
        public Nodo dch;

        //Con este le enviamos el dato a la estructura de la clase Nodo
        public Nodo(object dato) 
        {
            datoNodo = dato;
            izq = dch = null;
        }

        //Con este nodo ingresamos datos al arbol
        public Nodo(Nodo ramaIzq,object datoNodo,Nodo ramaDch) 
        {
            this.datoNodo = datoNodo;
            izq = ramaIzq;
            dch = ramaDch;
        }

        //Si queremos saber el dato del nodo utilizamos este metodo
        public object valorNodo() 
        {
            return datoNodo;
        }

       
        //En las inserciones,eliminaciones,busquedas etc necesitamos recorrer
        //Todo el arbol estos metodos nos ayudar obtener los enlaces para los nodos
        public Nodo subarbolIzq() { return izq; }
        public Nodo subarbolDch() { return dch; }

        //Con este metodo insertamos un dato en la rama izquierda
        public void ramaIzq( Nodo n) 
        {
            izq = n;
        }

        //Con este metodo insertamos un dato en la rama derecha
        public void ramaDch(Nodo n)
        {
            dch= n;
        }

        //Con este metodo retornamos la cadena 
        public string visitarNodo() 
        {
            return datoNodo.ToString();
        }

     

    }
}

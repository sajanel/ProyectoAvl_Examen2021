using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAvl_Examen.Estucturas_Arbol;

namespace ProyectoAvl_Examen.Estructuras_Arbol
{
   public class ArbolBinario
    {
        //Este dato sera la raiz de nuestra estructura del arbol
        protected Nodo arbolRaiz;

        public ArbolBinario() 
        {
            arbolRaiz = null;  
        }
        //Estos metodos nos serviran para comprobar si la raiz
        //esta vacia, o si quieremos devolver la raiz
        public ArbolBinario(Nodo raiz) { arbolRaiz = raiz; }
        public Nodo raizArbol() { return arbolRaiz; }
        public bool rabolVacio() { return arbolRaiz == null; }

        //Aca creamos nuestro arbol con los  parametros de un arbol raiz , izquierda, derecha
        public static Nodo nuevoArbol(Nodo ramaIzq,object datoRaiz,Nodo ramaDho) 
        {
            return new Nodo(ramaIzq, datoRaiz, ramaDho);      
        }

        //En la parte de los recorridos el inorden es esencial para mostrar o recorrer el arbol
        public static string rcInorden(Nodo r)
        {
            if (r!=null) 
            {
                return rcInorden(r.subarbolIzq()) + r.visitarNodo() + rcInorden(r.subarbolDch());

            }
            return "";
        }
        public static string rcpostOrden(Nodo r)
        {
            if (r != null)
            {
                return rcpostOrden(r.subarbolIzq()) + rcpostOrden(r.subarbolDch())+r.visitarNodo();

            }
            return "";
        }

        public static string rcPreorden(Nodo r)
        {
            if (r != null)
            {
                return r.visitarNodo()+rcPreorden(r.subarbolIzq()) + rcPreorden(r.subarbolDch());


            }
            return "";
        }

    }
}

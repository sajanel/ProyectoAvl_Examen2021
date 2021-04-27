using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAvl_Examen.Estructua_Alumno
{
    class InformacionAlumno:Comparador
    {
        /// <summary>
        /// Se crean atributos de la persona para ser leidos posteriormente
        /// </summary>
        public string nombreAlumno { get; set;}
        public string apellidoAlumno { get; set; }
        public string emailAlumno { get; set; }
        public int firstIdAlumno { get; set; }
        public int secondIdAlumno { get; set; }
        public int nodosVisitados { get; set; }

        public int labAlumno1,
            labAlumno2, labAlumno3, labAlumno4;

        //Creamos un constructor que contendra a todos los atributos antes mensionados 
        public InformacionAlumno(string apellidoAlumno, string nombreAlumno, string emailAlumno, 
            int firstIdAlumno, int secondIdAlumno, int labAlumno1, int labAlumno2, int labAlumno3, int labAlumno4)
        {
            this.nombreAlumno = nombreAlumno;
            this.apellidoAlumno = apellidoAlumno;
            this.emailAlumno = emailAlumno;
            this.firstIdAlumno = firstIdAlumno;
            this.secondIdAlumno = secondIdAlumno;
            this.labAlumno1 = labAlumno1;
            this.labAlumno2 = labAlumno2;
            this.labAlumno3 = labAlumno3;
            this.labAlumno4 = labAlumno4;
        }

        //Este construtor nos ayudara en el buscador para encontrar el id de los alumnos
        public InformacionAlumno(string emailAlumno, int firstIdAlumno, int secondIdAlumno)
        {
            this.emailAlumno = emailAlumno;
            this.firstIdAlumno = firstIdAlumno;
            this.secondIdAlumno = secondIdAlumno;

        }
        //Este comparador verifica que el correo del alumno
        public InformacionAlumno(string emailAlumno)
        {
            this.emailAlumno = emailAlumno;
           
        }
      
        //Estas funciones son implementadas gracias a el comparador
        public bool CorreoIgual(object q)
        {
            InformacionAlumno infoAlumno = (InformacionAlumno)q;
            return (infoAlumno.emailAlumno.CompareTo(emailAlumno) == 0);
        }

        public bool CorreoDiferente(object q)
        {
            InformacionAlumno infoAlumno = (InformacionAlumno)q;
           
            return (infoAlumno.emailAlumno.CompareTo(emailAlumno) != 0);
        }

        //Se le envian dos parametros en el conteo de nodos y el dato a comprar
        public bool firstIdMayor(object q,int num)
        {
           
            InformacionAlumno infoAlumno = (InformacionAlumno)q;
            if (infoAlumno.firstIdAlumno + infoAlumno.secondIdAlumno < firstIdAlumno + secondIdAlumno)
            {
                //Aca de esta misma clase almacena los datos en el atributo nodosVisitados
                infoAlumno.nodosVisitados = num;
                return true;
            }
            else return false;
         

        }

        //Verifica que el id sea menor al introducido
        public bool firstIdMenor(object q,int num)
        {
           
            InformacionAlumno infoAlumno = (InformacionAlumno)q;
            if (infoAlumno.firstIdAlumno + infoAlumno.secondIdAlumno > firstIdAlumno + secondIdAlumno)
            {
                infoAlumno.nodosVisitados = num;
                return true;
            }
            else return false;
            
        }

        //Esta es una compraracion para verificar si es el mismo dato
        public bool firstSame(object q,int num)
        {
            
            InformacionAlumno infoAlumno = (InformacionAlumno)q;
            if (infoAlumno.firstIdAlumno + infoAlumno.secondIdAlumno == firstIdAlumno + secondIdAlumno) 
            {
                infoAlumno.nodosVisitados = num;
                return true;
            }
            else return false;

        }

        //Metodo esencial para la obtencion de la informacion de mi arbol AVL
        public override string ToString()
        {
            return firstIdAlumno+"-"+secondIdAlumno+" " + nombreAlumno + ",";
        }
  
        //Lo que hace esto simplemente me retorna toda la informacion que yo necesito.
        public string busquedaInfo() 
        {
            return firstIdAlumno+","+secondIdAlumno+"," + nombreAlumno+" "+apellidoAlumno+","+
                labAlumno1 + "," + labAlumno2 + "," + labAlumno3 + "," + labAlumno4; 
        }  
    }
}

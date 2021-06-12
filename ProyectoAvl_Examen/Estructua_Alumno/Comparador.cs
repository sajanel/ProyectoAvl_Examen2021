using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAvl_Examen.Estructua_Alumno
{
  public interface Comparador
    {
        //Estos metodos son utilizados eh implementados en la clase InformacionAlumno
        public bool firstIdMayor(object q,int cont);
        public bool firstIdMenor(object q,int cont);
        public bool firstSame(object q,int cont);
    }
}

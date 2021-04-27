using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoAvl_Examen.Estructua_Alumno;
using ProyectoAvl_Examen.Estructuras_Arbol;
namespace ProyectoAvl_Examen
{
    public partial class Form1 : Form
    {
        ArbolAvl miArbolEstudiante = new ArbolAvl();
     
        
        public Form1()
        {
            InitializeComponent();
            lblAprobacion.Visible = false;
        }
       
        private void btnCargar_Click(object sender, EventArgs e)
        {
            //Utilizamos esta funcion para abrir directorios en el escritorio
            OpenFileDialog abreArchivo = new OpenFileDialog();

            //si escogimos el dato y le dimos okey 
            if (abreArchivo.ShowDialog() == DialogResult.OK)//inicial la condicion
            {
                txtArchivoCargar.Text = abreArchivo.FileName;//El nombre del archivo lo almacena en un txtBox

                int cont = 0;//Un contador por defecto en 0 para contar los datos insertados del archivo txt
                string line;//Variable que se utilizar para leer lineas de texto

                //leer el arhivo y la otra funcion es para leer la ñ
                StreamReader archivoAlumno = new StreamReader(txtArchivoCargar.Text, Encoding.Default);

                //leemos la primera linea de codigo que es el nombre, al apellido
                line = archivoAlumno.ReadLine();
           
                //Recorrido de todo el txt
                while ((line = archivoAlumno.ReadLine()) != null)
                {
                    string[] wordSrings = line.Split(';', '-');
                    InformacionAlumno inforAlumno = new InformacionAlumno(wordSrings[0], wordSrings[1], wordSrings[2]
                     ,
                        Convert.ToInt32(wordSrings[3]), Convert.ToInt32(wordSrings[4]),
                         Convert.ToInt32(wordSrings[5]), Convert.ToInt32(wordSrings[6]), Convert.ToInt32(wordSrings[7]),
                          Convert.ToInt32(wordSrings[8]));

                    //Insertamos en el arbol raiz.
                    miArbolEstudiante.insertar(inforAlumno);
                    cont++;
                }
                //Cerramos el archivo
                archivoAlumno.Close();
            }
        }

        //Tipos de recorridos para mostrar la informacion
        private void btnPreorden_Click(object sender, EventArgs e)
        {
            //lo obtenemos como cadena para separalo y ordenarlo solo por 
            //id y nombre
            string nuevoDato = ArbolAvl.rcPreorden(miArbolEstudiante.raizArbol());
            string[] wordSrings = nuevoDato.Split(',');

            listBox1.Items.Clear();

            foreach (string words in wordSrings)
            {
                listBox1.Items.Add(words);
            }
        }

        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            string nuevoDato = ArbolAvl.rcpostOrden(miArbolEstudiante.raizArbol());
            string[] wordSrings = nuevoDato.Split(',');

            listBox1.Items.Clear();

            foreach (string words in wordSrings)
            {
                listBox1.Items.Add(words);
            }
        }

        private void bntOrden_Click(object sender, EventArgs e)
        {
            string nuevoDato = ArbolAvl.rcInorden(miArbolEstudiante.raizArbol());
            string[] wordSrings = nuevoDato.Split(',');
           
           
            listBox1.Items.Clear();

            foreach (string words in wordSrings)
            {
                listBox1.Items.Add(words);
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //El constuctor solo me recibe un parametro de ingreso el correo
            InformacionAlumno inforAlumno = new InformacionAlumno(txtEmail.Text);

            //creo dos variables que seria 19  2518 
            int claveIncial, claveFinal;

            //obtiene la cadena de datos Carnet y el nombre por medio del tipo de busqueda preorden
            string nuevo = miArbolEstudiante.buscarlo(inforAlumno);

            //validacion que el texto este vacio
            if (txtEmail.Text=="") { MessageBox.Show("Campo vacio de busqueda", "Caja vacia de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            //Si al buscar el dato me encontro algo
            else if (nuevo != "")//Ejecutar if
            {
                string[] wordS = nuevo.Split('-', ' ');
                //Se ingresan las variables obtenidas en la busqueda del carnet
                claveIncial = Convert.ToInt32(wordS[0]);
                claveFinal = Convert.ToInt32(wordS[1]);


                //Se inserta la informacion encontrada a otro metodo de busqueda para poder acceder a todos los datos
                InformacionAlumno busquedaAlumno = new InformacionAlumno(txtEmail.Text, Convert.ToInt32(claveIncial),
                    Convert.ToInt32(claveFinal));

                //Convierte la informacion a tipo cadena
                InformacionAlumno encontradoAlum = (InformacionAlumno)miArbolEstudiante.buscar(busquedaAlumno).valorNodo();
              
                //Con esta funcion contamos todos los nodos encontrados
                MessageBox.Show("El estudiante fue encontrado visitando "+encontradoAlum.nodosVisitados+" Nodos","Informacion de busqueda",MessageBoxButtons.OK,MessageBoxIcon.Information);
               
                
                //los datos son convertidos a tipo string para que se muestre en pantalla
                string nuevoDato = encontradoAlum.busquedaInfo();

                //la informacion me la obtubo pero en una sola cadena necesitamos separarla por seccioens
                string[] wordSrings = nuevoDato.Split(',');
                int a, b, c, d;

                //Llenamos la informacion con los datos obtenios
                txtFirstId.Text = wordSrings[0];
                txtSecondId.Text = wordSrings[1];
                txtName.Text = wordSrings[2];
                txtlab1.Text = wordSrings[3];
                txtLab2.Text = wordSrings[4];
                txtLab3.Text = wordSrings[5];
                txtLab4.Text = wordSrings[6];

                //Estas variables son utilizas para obtener las calificaciones de los laboratorios
                a = Convert.ToInt32(txtlab1.Text); b= Convert.ToInt32(txtLab2.Text);
                c= Convert.ToInt32(txtLab3.Text); d= Convert.ToInt32(txtLab4.Text);
                
                //se calcula el promedio
                txtPromedio.Text = Convert.ToString((a + b + c + d) / 4);

                lblAprobacion.Visible = true;

                //De ser mayor o igual a 6 
                if ((a + b + c + d) / 4 >= 6)
                    lblAprobacion.Text = "APROBADO";//Alumno aprobo
                else lblAprobacion.Text = "REPROBADO";

            }

            else//Si al buscar no encontro nada 
                MessageBox.Show("No se encontro el dato","Error al digitar los datos",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //limpiar cajas de texto
            txtEmail.Text = "";
            txtFirstId.Text = "";
            txtSecondId.Text = "";
            txtName.Text = "";
            txtlab1.Text = "";
            txtLab2.Text = "";
            txtLab3.Text = "";
            txtLab4.Text = "";
        }
    }
}

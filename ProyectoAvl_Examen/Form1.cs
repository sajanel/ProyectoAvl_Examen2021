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
using ProyectoAvl_Examen.TablaHash;
using ProyectoAvl_Examen.TablaHash.ListaColisiones;
namespace ProyectoAvl_Examen

{
    public partial class Form1 : Form
    {
        //Este objeto se utilizara para llenar el arbol
        ArbolAvl miArbolEstudiante = new ArbolAvl();

        //Este objeto se utilizara para insertar y hacer busquedas en una tabla dinamica hash
        TablaDispercion miTablaHashin = new TablaDispercion();

        string idEstudiante;

        public Form1()
        {
            InitializeComponent();
           
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

                //leer el arhivo y la otra funcion es para leer la
                StreamReader archivoAlumno = new StreamReader(txtArchivoCargar.Text, Encoding.Default);

                //leemos la primera linea de codigo que es el nombre, al apellido
                line = archivoAlumno.ReadLine();
           
                //Recorrido de todo el txt
                while ((line = archivoAlumno.ReadLine()) != null)
                {
                    string[] wordSrings = line.Split(';', '-');
                    InformacionAlumno inforAlumno = new InformacionAlumno(wordSrings[0], wordSrings[1], wordSrings[2]
                     , wordSrings[3], wordSrings[4],
                         Convert.ToInt32(wordSrings[5]), Convert.ToInt32(wordSrings[6]), Convert.ToInt32(wordSrings[7]),
                          Convert.ToInt32(wordSrings[8]));
                  
                    idEstudiante = wordSrings[3]+wordSrings[4];
 
                    //Insertamos en el arbol raiz.
                     miArbolEstudiante.insertar(inforAlumno);

                    //Insertamos a una tabla hash
                    miTablaHashin.Insertar(inforAlumno,idEstudiante);

                    cont++;

                }
                //Cerramos el archivo
                btnCargar.Enabled = false;
                archivoAlumno.Close();
            }
        }

        //Tipos de recorridos para mostrar la informacion
        private void btnPreorden_Click(object sender, EventArgs e)
        {
            Imprimir(ArbolAvl.rcPreorden(miArbolEstudiante.raizArbol()),0);  
        }
        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            Imprimir(ArbolAvl.rcpostOrden(miArbolEstudiante.raizArbol()),0);       
        }
        private void bntOrden_Click(object sender, EventArgs e)
        {
            Imprimir(ArbolAvl.rcInorden(miArbolEstudiante.raizArbol()),0);
        }
        public void Imprimir(string valor,int opcion) 
        {
            int cont = 0, Aux = 0;
            string[] wordSrings = valor.Split(',');

            string[] wordSrings2 = valor.Split(',', ' ', '*');

            if (opcion == 0)
            {
                listBox1.Items.Clear();

                foreach (string words in wordSrings)
                {
                    cont++;
                    if (words != "" && cont % 2 != 0)
                    {
                        listBox1.Items.Add(words);
                    }
                }
            }
            else if (opcion ==1) 
            {
                texto(wordSrings2[1]+" "+wordSrings2[2]+" "+ wordSrings2[3] + " " + wordSrings2[4], 1);
                texto(wordSrings2[5], 2); 
                texto(wordSrings2[6], 3);
                texto(wordSrings2[7], 4);
                texto(wordSrings2[8], 5);
                texto(wordSrings2[9], 6);
          
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (miArbolEstudiante.raizArbol() == null)
            {
                MessageBox.Show("Por favor carge los datos y vuelva a intentarlo", "Buscar estudiante", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                //Creamos una variable para unir el id del estudiante 
                string idEstudiante = txtFirstId.Text + txtSecondId.Text;

                string datoEncontrado = (string)miTablaHashin.Buscar(idEstudiante);

                if (datoEncontrado == null)
                {
                    MessageBox.Show("No se encontro al estudiante", "Buscar estudiante", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    Imprimir(datoEncontrado, 1);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            texto("",0);
        }
        public void texto(string valor,int cont) 
        {
            if (cont > 0)
            {
                switch (cont)
                {
                    case 1: txtCorreo.Text = valor; break;
                    case 2: txtName.Text = valor; break;
                    case 3: txtlab1.Text = valor; break;
                    case 4: txtLab2.Text = valor; break;
                    case 5: txtLab3.Text = valor; break;
                    case 6: txtLab4.Text = valor; break;

                }
            }
            else
            {
                txtCorreo.Text = valor;
                txtFirstId.Text = valor;
                txtSecondId.Text = valor;
                txtName.Text = valor;
                txtlab1.Text = valor;
                txtLab2.Text = valor;
                txtLab3.Text = valor;
                txtLab4.Text = valor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

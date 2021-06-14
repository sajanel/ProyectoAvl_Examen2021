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
        TablaDispercion miTablaHashin;

        string idEstudiante;
        int cont = 0;
        public Form1()
        {
            InitializeComponent();
           
        }
       
        private void btnCargar_Click(object sender, EventArgs e)
        {
            ArbolAvl miArbol = new ArbolAvl();
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
           
                //Recorrido de todo el txt""
                while ((line = archivoAlumno.ReadLine()) != null)
                {
                    string[] wordSrings = line.Split(';', '-');
                    InformacionAlumno inforAlumno = new InformacionAlumno(wordSrings[0], wordSrings[1], wordSrings[2]
                     , wordSrings[3], wordSrings[4],
                        wordSrings[5], wordSrings[6], wordSrings[7],
                          wordSrings[8]);
                  
                    idEstudiante = wordSrings[3]+wordSrings[4];
 
                    //Insertamos en el arbol raiz.
                     miArbolEstudiante.insertar(inforAlumno);

                    //Insertamos a una tabla hash
                   

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
            Imprimir(ArbolAvl.rcPreorden(miArbolEstudiante.raizArbol()), 3);
        }
        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            Imprimir(ArbolAvl.rcpostOrden(miArbolEstudiante.raizArbol()),0);
            Imprimir(ArbolAvl.rcpostOrden(miArbolEstudiante.raizArbol()), 3);

        }
        private void bntOrden_Click(object sender, EventArgs e)
        {
            Imprimir(ArbolAvl.rcInorden(miArbolEstudiante.raizArbol()),0);
            Imprimir(ArbolAvl.rcInorden(miArbolEstudiante.raizArbol()), 3);

        }
        public void Imprimir(string valor, int opcion)
        {
            int cont = 0;

            //Divide la cadena
            string[] wordSrings = valor.Split('`', ';');

            string[] wordSrings2 = valor.Split(';', '_', '*');

            //Aca muesta la informacion del recorrido del arbl
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
            //Aca se imprime la informacion encontrada en la busqueda del usuario
            else if (opcion == 1)
            {
                texto(wordSrings2[1], 2);
                texto(wordSrings2[2], 1);
                texto(wordSrings2[3], 3);
                texto(wordSrings2[4], 4);
                texto(wordSrings2[5], 5);
                texto(wordSrings2[6], 6);

            }

            else if (opcion == 3)
            {
                //Limpieza de la tabla hash
                miTablaHashin = new TablaDispercion();

                while (valor != "")
                {
                    string[] wordSrin = valor.Split(';', '-', '*','_', '`');

                    //Los que esta haciendo aca es dividir la cadena eh insertarla en la clase informacion Alumno
                    //Para posterior insertarlo a la tabla hash

                    if (wordSrin[cont] != "")
                    {
                        string id = wordSrin[cont]; cont++;
                        string id1 = wordSrin[cont]; cont++;
                        string nombre = wordSrin[cont]; cont++;
                        string apellido = wordSrin[cont]; cont++;
                        string email = wordSrin[cont]; cont++;
                        string lab = wordSrin[cont]; cont++;
                        string lab1 = wordSrin[cont]; cont++;
                        string lab2 = wordSrin[cont]; cont++;
                        string lab3 = wordSrin[cont]; cont++;

                        InformacionAlumno auxAlumno = new InformacionAlumno(apellido, nombre, email, id, id1, lab, lab1, lab2, lab3);

                        string idPersona = id + id1;
                        miTablaHashin.Insertar(auxAlumno, idPersona);
                    }
                    else
                        valor = "";
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (miArbolEstudiante.raizArbol() == null)
            {
                MessageBox.Show("Por favor carge los datos y vuelva a intentarlo", "Buscar estudiante", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txtFirstId.Text == "" || txtSecondId.Text == "") 
            {
                MessageBox.Show("Por favor digite el id del estudiante", "Buscar estudiante", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                //Creamos una variable para unir el id del estudiante 
                string idEstudiante = txtFirstId.Text + txtSecondId.Text;

                //Se implemento una busqueda utilizando la tabla hash
                string datoEncontrado = (string)miTablaHashin.Buscar(idEstudiante);

                //Si la cadena o string esta vacio o no trae nada de datos
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

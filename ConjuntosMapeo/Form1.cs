using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Importamos esta libreria que es un dll, esto para utilizar cuadros de input.
using InputKey;

namespace ConjuntosMapeo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Declaramos nuestras listas o vectores dinamicos.
        List<String> universo = new List<String>();
        List<String> mundoA = new List<String>();
        List<String> mundoB = new List<String>();
        List<String> mundoC = new List<String>();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Guardamos en la variable el valor introducido por el usuario.
            string auxiliar = InputDialog.mostrar("Introduzca algun dato");
            //Lo guardamos en nuestra lista correspondiente.
            universo.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label4.Text += auxiliar + "\n";
        }
    }
}

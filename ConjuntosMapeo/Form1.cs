using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
//Importamos esta libreria que es un dll, esto para utilizar cuadros de input.
using InputKey;

namespace ConjuntosMapeo
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        //Declaramos nuestras listas o vectores dinamicos.
        List<String> universo = new List<String>();
        List<String> mundoA = new List<String>();
        List<String> mundoB = new List<String>();
        List<String> mundoC = new List<String>();
        //Declarancion de un auxiliar.
        String auxiliar, primero, segundo, tercero, operadorPrimero, operadorSegundo;
        //Declaracion de variables auxiliares.
        Boolean operacionA, operacionB, operacionC, operacionUnion, operacionComple, operacionInter, operacionDiferen,
                operacionConca, operacionProducto, operacionPotencia, operacionPertenencia, operacionPertenencia2;
        //Metodo para hacer operaciones en listas.
        IEnumerable<String> resultadoTotal;
        List<String> resultados;

        private void imprimir()
        {
            string aux = label15.Text;
            if (aux.Length == 0)
            {
                foreach (String valor in resultadoTotal)
                {
                    label15.Text += valor + ", ";
                }
            }
            else
            {
                foreach (String valor in resultadoTotal)
                {
                    label16.Text += valor + ", ";
                }
            }
        }

        private void imprimir2()
        {
            foreach (String valor in resultados)
            {
                label15.Text += valor + ", ";
            }
        }

        private void convertidor()
        {
            for (int h = 0; h < resultadoTotal.Count(); h++)
            {
                //resultados.Add(resultadoTotal.Concat);
            }
        }

        private void union(List<String> uno, List<String> dos)
        {
            //Metodo para unir dos listas.
            resultadoTotal = uno.Union(dos);
        }

        private void union2(IEnumerable<String> uno, List<String> dos)
        {
            //Metodo para unir dos listas.
            resultadoTotal = uno.Union(dos);
        }

        private void complemento(List<String> uno)
        {
            /*List<String> resultadoC = new List<String>();
            string palabra = "";
            String a;
            for (int s = 0; s < universo.Count; s++)
            {
                for (int e = 0; e < uno.Count; e++)
                {
                    if (universo[s].Equals(uno[e]))
                    {
                        //  s++;
                        // String a = universo[s];
                    }
                    else
                    {
                        // resultadoC.Add(universo[s]);
                        a = universo[s];
                        e++;
                    }
                }
                resultadoC.Add(a);
            }
            */


            resultadoTotal = universo.Except(uno);
            //Ciclo para imprimir el resultado.

        }

        private void complemento2(IEnumerable<String> uno)
        {
            /*List<String> resultadoC = new List<String>();
            string palabra = "";
            String a;
            for (int s = 0; s < universo.Count; s++)
            {
                for (int e = 0; e < uno.Count; e++)
                {
                    if (universo[s].Equals(uno[e]))
                    {
                        //  s++;
                        // String a = universo[s];
                    }
                    else
                    {
                        // resultadoC.Add(universo[s]);
                        a = universo[s];
                        e++;
                    }
                }
                resultadoC.Add(a);
            }
            */


            resultadoTotal = universo.Except(uno);
            //Ciclo para imprimir el resultado.
        }

        private void pertenencia(List<String> uno, List<String> dos)
        {
            //Si los elementos que tiene A estan en B.
            int auxil = 0;
            for (int i = 0; i < dos.Count; i++)
            {
                for (int x = 0; x < uno.Count; x++)
                {
                    if (uno[x] == dos[i])
                    {
                        auxil++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            if (uno.Count == auxil)
            {
                label16.Text = "Todos los elementos se encontraron.";
            }
            else
            {
                label16.Text = "Todos los elementos NO encontraron.";
            }
        }

        private void interseccion(List<String> uno, List<String> dos)
        {
            //Metodo para unir dos listas.
            resultadoTotal = uno.Intersect(dos);
            //Ciclo para imprimir el resultado.
            if (resultadoTotal.Count().Equals(0))
            {
                label16.Text = "No hay valores.";
            }

        }

        private void interseccion2(IEnumerable<String> uno, List<String> dos)
        {
            //Metodo para unir dos listas.
            resultadoTotal = uno.Intersect(dos);
            //Ciclo para imprimir el resultado.
            if (resultadoTotal.Count().Equals(0))
            {
                label16.Text = "No hay valores.";
            }
            imprimir();
        }

        private void diferencia(List<String> uno, List<String> dos)
        {
            resultadoTotal = uno.Except(dos);
            //Ciclo para imprimir el resultado.

        }

        private void diferencia2(IEnumerable<String> uno, List<String> dos)
        {
            resultadoTotal = uno.Except(dos);
            //Ciclo para imprimir el resultado.

        }

        private void potencia(List<String> uno)
        {
            for (int i = 0; i < uno.Count; i++)
            {
                resultados.Add(uno[i]);
            }
            int contador = 1;
            for (int i = 0; i < uno.Count; i++)
            {
                for (int w = contador; w < uno.Count; w++)
                {
                    resultados.Add(uno[i] + uno[w]);

                }
                contador++;
            }
            imprimir2();
        }

        private void producto(List<String> uno, List<String> dos)
        {
            for (int f = 0; f < uno.Count; f++)
            {
                for (int o = 0; o < dos.Count; o++)
                {
                    resultados.Add(dos[o] + uno[f]);
                }
            }
            imprimir2();
        }

        private void concatenacion(List<String> uno, List<String> dos)
        {
            //Metodo para unir dos listas.
            resultadoTotal = dos.Concat(uno);
            //Ciclo para imprimir el resultado.
        }

        private void concatenacion2(IEnumerable<String> uno, List<String> dos)
        {
            //Metodo para unir dos listas.
            resultadoTotal = dos.Concat(uno);
            imprimir();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUniverso_Click(object sender, EventArgs e)
        {
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato");
            //Lo guardamos en nuestra lista correspondiente.
            universo.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label4.Text += auxiliar + "\n";
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato");
            //Lo guardamos en nuestra lista correspondiente.
            mundoA.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label5.Text += auxiliar + "\n";
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato");
            //Lo guardamos en nuestra lista correspondiente.
            mundoB.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label7.Text += auxiliar + "\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operacionA = true;
            txtOpera.Text += "A";

            if (primero == "")
            {
                primero = "A";
            }
            else if (segundo == "")
            {
                segundo = "A";
            }
            else if (tercero == "")
            {
                tercero = "A";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            operacionB = true;
            txtOpera.Text += "B";
            if (primero == "")
            {
                primero = "B";
            }
            else if (segundo == "")
            {
                segundo = "B";
            }
            else if (tercero == "")
            {
                tercero = "B";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label15.Text = "";
            label16.Text = "";
            txtOpera.Text = "";
            primero = ""; segundo = ""; tercero = "";
            operacionA = false; operacionB = false; operacionC = false;
            operadorPrimero = ""; operadorSegundo = "";
            operacionUnion = false;
            operacionComple = false;
            operacionInter = false;
            operacionDiferen = false;
            operacionConca = false;
            operacionProducto = false;
            operacionPotencia = false;
            operacionPertenencia = false;
            operacionPertenencia2 = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operacionC = true;
            txtOpera.Text += "C";
            if (primero == "")
            {
                primero = "C";
            }
            else if (segundo == "")
            {
                segundo = "C";
            }
            else if (tercero == "")
            {
                tercero = "C";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                UnaOperacion();
            }
            else if (radioButton2.Checked)
            {
                DosOperaciones();
            }
        }

        private void UnaOperacion()
        {
            if (operacionUnion)
            {
                auxiliarUnion();
                imprimir();
            }
            else if (operacionComple)
            {
                auxiliarComplemento();
            }
            else if (operacionInter)
            {
                auxiliarInterseccion();
                imprimir();
            }
            else if (operacionDiferen)
            {
                auxiliarDiferencia();
            }
            else if (operacionConca)
            {
                auxiliarConcatenacion();
                imprimir();
            }
            else if (operacionProducto)
            {
                auxiliarProducto();
            }
            else if (operacionPotencia)
            {
                auxiliarPotencia();
            }
            else if (operacionPertenencia)
            {
                auxiliarPertenencia();
            }
            else if (operacionPertenencia2)
            {
                auxiliarPertenencia2();
            }
        }

        private void DosOperaciones()
        {
            UnaOperacion();
            if (operadorSegundo == "Union")
            {
                if (tercero == "A")
                {
                    union2(resultadoTotal, mundoA);
                    imprimir();
                }
                else if (tercero == "B")
                {
                    union2(resultadoTotal, mundoB);
                    imprimir();
                }
                else if (tercero == "C")
                {
                    union2(resultadoTotal, mundoC);
                    imprimir();
                }
            }
            else if (operadorSegundo == "Interseccion")
            {
                if (tercero == "A")
                {
                    interseccion2(resultadoTotal, mundoA);
                }
                else if (tercero == "B")
                {
                    interseccion2(resultadoTotal, mundoB);
                }
                else if (tercero == "C")
                {
                    interseccion2(resultadoTotal, mundoC);
                }
            }
            else if (operadorSegundo == "Diferencia")
            {
                if (tercero == "A")
                {
                    diferencia2(resultadoTotal, mundoA);
                }
                else if (tercero == "B")
                {
                    diferencia2(resultadoTotal, mundoB);
                }
                else if (tercero == "C")
                {
                    diferencia2(resultadoTotal, mundoC);
                }
            }
            else if (operadorSegundo == "Complemento")
            {
                if (segundo == "A")
                {
                    complemento2(resultadoTotal);
                    imprimir();
                }
                else if (segundo == "B")
                {
                    complemento2(resultadoTotal);
                    imprimir();
                }
                else if (segundo == "C")
                {
                    complemento2(resultadoTotal);
                    imprimir();
                }
            }
            else if (operadorSegundo == "Concatenacion")
            {
                if (tercero == "A")
                {
                    concatenacion2(resultadoTotal, mundoA);
                }
                else if (tercero == "B")
                {
                    concatenacion2(resultadoTotal, mundoB);
                }
                else if (tercero == "C")
                {
                    concatenacion2(resultadoTotal, mundoC);
                }
            }
        }


        private void auxiliarUnion()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    union(mundoA, mundoB);
                }
                else
                {
                    union(mundoB, mundoA);

                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    union(mundoA, mundoC);

                }
                else
                {
                    union(mundoC, mundoA);

                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    union(mundoB, mundoC);

                }
                else
                {
                    union(mundoC, mundoB);

                }
            }
        }

        private void auxiliarPertenencia()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    pertenencia(mundoA, mundoB);
                }
                else if (primero == "B" && segundo == "A")
                {
                    pertenencia(mundoB, mundoA);
                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    pertenencia(mundoA, mundoC);
                }
                else if (primero == "C" && segundo == "A")
                {
                    pertenencia(mundoC, mundoA);
                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    pertenencia(mundoB, mundoC);
                }
                else if (primero == "C" && segundo == "B")
                {
                    pertenencia(mundoC, mundoB);
                }
            }
        }

        private void auxiliarPertenencia2()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    pertenencia(mundoB, mundoA);
                }
                else if (primero == "B" && segundo == "A")
                {
                    pertenencia(mundoA, mundoB);
                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    pertenencia(mundoC, mundoA);
                }
                else if (primero == "C" && segundo == "A")
                {
                    pertenencia(mundoA, mundoC);
                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    pertenencia(mundoC, mundoB);
                }
                else if (primero == "C" && segundo == "B")
                {
                    pertenencia(mundoB, mundoC);
                }
            }
        }

        private void auxiliarConcatenacion()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    concatenacion(mundoA, mundoB);
                    imprimir();
                }
                else
                {
                    concatenacion(mundoB, mundoA);
                    imprimir();
                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    concatenacion(mundoA, mundoC);
                    imprimir();
                }
                else
                {
                    concatenacion(mundoC, mundoA);
                    imprimir();
                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    concatenacion(mundoB, mundoC);
                    imprimir();
                }
                else
                {
                    concatenacion(mundoC, mundoB);
                    imprimir();
                }
            }
        }

        private void auxiliarProducto()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    producto(mundoA, mundoB);
                    imprimir();
                }
                else
                {
                    producto(mundoB, mundoA);
                    imprimir();
                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    producto(mundoA, mundoC);
                    imprimir();
                }
                else
                {
                    producto(mundoC, mundoA);
                    imprimir();
                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    producto(mundoB, mundoC);
                    imprimir();
                }
                else
                {
                    producto(mundoC, mundoB);
                    imprimir();
                }
            }
        }

        private void auxiliarDiferencia()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    diferencia(mundoA, mundoB);
                    imprimir();
                }
                else if (primero == "B" && segundo == "A")
                {
                    diferencia(mundoB, mundoA);
                    imprimir();
                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    diferencia(mundoA, mundoC);
                    imprimir();
                }
                else if (primero == "C" && segundo == "A")
                {
                    diferencia(mundoC, mundoA);
                    imprimir();
                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    diferencia(mundoB, mundoC);
                    imprimir();
                }
                else if (primero == "C" && segundo == "B")
                {
                    diferencia(mundoC, mundoB);
                    imprimir();
                }
            }

        }

        private void auxiliarInterseccion()
        {
            if (operacionA && operacionB)
            {
                interseccion(mundoA, mundoB);

            }
            else if (operacionA && operacionC)
            {
                interseccion(mundoA, mundoC);

            }
            else
            {
                interseccion(mundoB, mundoC);

            }
        }

        private void auxiliarComplemento()
        {
            if (operacionA)
            {
                complemento(mundoA);
                imprimir();
            }
            else if (operacionB)
            {
                complemento(mundoB);
                imprimir();
            }
            else
            {
                complemento(mundoC);
                imprimir();
            }
        }

        private void auxiliarPotencia()
        {
            if (operacionA)
            {
                potencia(mundoA);
                imprimir();
            }
            else if (operacionB)
            {
                potencia(mundoB);
                imprimir();
            }
            else
            {
                potencia(mundoC);
                imprimir();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "'";
            operacionComple = true;
            if (operadorPrimero == "")
            {
                operadorPrimero = "Complemento";
            }
            else if (operadorSegundo == "")
            {
                operadorSegundo = "Complemento";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "∪ ";
            operacionUnion = true;
            if (operadorPrimero == "")
            {
                operadorPrimero = "Union";
            }
            else if (operadorSegundo == "")
            {
                operadorSegundo = "Union";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "∩";
            operacionInter = true;
            if (operadorPrimero == "")
            {
                operadorPrimero = "Interseccion";
            }
            else if (operadorSegundo == "")
            {
                operadorSegundo = "Interseccion";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "--";
            operacionDiferen = true;
            if (operadorPrimero == "")
            {
                operadorPrimero = "Diferencia";
            }
            else if (operadorSegundo == "")
            {
                operadorSegundo = "Diferencia";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "x";
            operacionProducto = true;
            if (operadorPrimero == "")
            {
                operadorPrimero = "Multiplicacion";
            }
            else if (operadorSegundo == "")
            {
                operadorSegundo = "Multiplicacion";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "P()";
            operacionPotencia = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Si los elementos que tiene A estan en B.
            txtOpera.Text += "⊆ ";
            operacionPertenencia = true;
            if (operadorPrimero == "")
            {
                operadorPrimero = "Pertenencia1";
            }
            else if (operadorSegundo == "")
            {
                operadorSegundo = "Pertenencia1";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "Con";
            operacionConca = true;
            if (operadorPrimero == "")
            {
                operadorPrimero = "Concatenacion";
            }
            else if (operadorSegundo == "")
            {
                operadorSegundo = "Concatenacion";
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato");
            //Lo guardamos en nuestra lista correspondiente.
            mundoC.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label9.Text += auxiliar + "\n";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Si los elementos que tiene B estan en A.
            txtOpera.Text += "⊃";
            operacionPertenencia2 = true;
            if (operadorPrimero == "")
            {
                operadorPrimero = "Pertenencia2";
            }
            else if (operadorSegundo == "")
            {
                operadorSegundo = "Pertenencia2";
            }
        }

    }
}

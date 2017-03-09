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
        List<String> resultados = new List<String>();
        //Declarancion de un auxiliar.
        String auxiliar, primero, segundo, tercero, operadorPrimero, operadorSegundo;
        //Declaracion de variables auxiliares.
        Boolean operacionA, operacionB, operacionC, operacionUnion, operacionComple, operacionInter, operacionDiferen,
                operacionConca, operacionProducto, operacionPotencia, operacionPertenencia, operacionPertenencia2;
        //Metodo para hacer operaciones en listas.
        IEnumerable<String> resultadoTotal;

        private void imprimir()
        {
            //Con el fin de que los resultados no se muestren en un solo Label.
            string aux = label15.Text;
            //En caso de que este vacion, utiliza este.
            if (aux.Length == 0)
            {
                //Imprime los valores de la lista.
                foreach (String valor in resultadoTotal)
                {
                    label15.Text += valor + ", ";
                }
            }
            //En caso de que este lleno, utiliza este.
            else
            {
                //Imprime los valores de la lista.
                foreach (String valor in resultadoTotal)
                {
                    label16.Text += valor + ", ";
                }
            }
        }

        private void imprimir2()
        {
            //Imprime los valores de la lista, esta es una lista diferente a la anterior.
            foreach (String valor in resultados)
            {
                label15.Text += valor + ", ";
            }
        }

        private void union(List<String> uno, List<String> dos)
        {
            //Recibe de parametros dos listas.
            //Metodo para unir dos listas.
            resultadoTotal = uno.Union(dos);
        }

        private void union2(IEnumerable<String> uno, List<String> dos)
        {
            //Recibe de parametros dos listas, estas son diferentes entre si.
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

            //Recibe de parametro una lista.
            resultadoTotal = universo.Except(uno);
        }

        private void complemento2(IEnumerable<String> uno)
        {
            //Recibe de parametro una lista, este metodo recibe una lista diferrente a la anteriror.
            resultadoTotal = universo.Except(uno);
        }

        private void pertenencia(List<String> uno, List<String> dos)
        {
            //Recibe de parametros dos listas.
            //Si los elementos que tiene A estan en B.
            //Declaramos un auxiliar.
            int auxil = 0;
            //Ciclo para recorrer el segundo conjunto.
            for (int i = 0; i < dos.Count; i++)
            {
                //Ciclo para recorrer el primer conjunto.
                for (int x = 0; x < uno.Count; x++)
                {
                    //Para conocer si los valores son iguales.
                    if (uno[x] == dos[i])
                    {
                        //Si lo son aumentamos una unidad a nuestra variable.
                        auxil++;
                    }
                    //En caso de ser diferentes, sigue con el ciclo.
                    else
                    {
                        continue;
                    }
                }
            }
            //Si el tamaño de nuestro conjunto es igual a nuestro auxiliar.
            if (uno.Count == auxil)
            {
                //Entonces los elementos de A estan contenidos en B.
                label16.Text = "Todos los elementos se encontraron.";
            }
            else
            {
                //Entonces los elementos de A no estan contenidos en B.
                label16.Text = "Todos los elementos NO encontraron.";
            }
        }

        private void interseccion(List<String> uno, List<String> dos)
        {
            //Recibe como parametros dos listas.
            //Metodo para encontrar la interseccion de dos listas.
            resultadoTotal = uno.Intersect(dos);
            //Ciclo para saber si en caso de que no se encuentre intersecciones.
            if (resultadoTotal.Count().Equals(0))
            {
                label16.Text = "No hay valores.";
            }
        }

        private void interseccion2(IEnumerable<String> uno, List<String> dos)
        {
            //Recibe como parametros dos listas, que son diferentes entre si.
            //Metodo para encontrar la interseccion de dos listas.
            resultadoTotal = uno.Intersect(dos);
            //Ciclo para saber si en caso de que no se encuentre intersecciones.
            if (resultadoTotal.Count().Equals(0))
            {
                label16.Text = "No hay valores.";
            }
            //Metodo para imprimir los resultados finales.
            imprimir();
        }

        private void diferencia(List<String> uno, List<String> dos)
        {
            //Recibe como parametros dos listas.
            //Metodo para encontrar las diferencias de dos listas.
            resultadoTotal = uno.Except(dos);
        }

        private void diferencia2(IEnumerable<String> uno, List<String> dos)
        {
            //Recibe como parametros dos listas, que son diferentes entre si.
            //Metodo para encontrar la diferencia entre dos listas.
            resultadoTotal = uno.Except(dos);
        }

        private void potencia(List<String> uno)
        {
            //Recibe como parametro una lista.
            //Ciclo para guardos los valores de esta lista.
            for (int i = 0; i < uno.Count; i++)
            {
                resultados.Add(uno[i]);
            }
            //Auxiliar para ir recorriendo el vector en la posicion deseada.
            int contador = 1;
            //Ciclo que recorre el conjunto.
            for (int i = 0; i < uno.Count; i++)
            {
                //Ciclo que recorre el mismo conjunto.
                for (int w = contador; w < uno.Count; w++)
                {
                    //Guardamos los valores.
                    resultados.Add(uno[i] + uno[w]);
                }
                //Aumentamos nuestra variable, con el fin de que la proxima vez que trabaje el ciclo 2,
                //no empiece en 0.
                contador++;
            }
            //Ciclo para imprimir los resultados.
            imprimir2();
        }

        private void producto(List<String> uno, List<String> dos)
        {
            //Recibe como parametros dos listas.
            //Ciclo para recorrer el primer ciclo.
            for (int f = 0; f < uno.Count; f++)
            {
                //Ciclo para recorrer el segundo ciclo.
                for (int o = 0; o < dos.Count; o++)
                {
                    //Guardamos los valores.
                    resultados.Add(dos[o] + uno[f]);
                }
            }
            //Imprimimos los valores.
            imprimir2();
        }

        private void concatenacion(List<String> uno, List<String> dos)
        {
            //Recibe como parametros dos listas.
            //Metodo para concatenar dos listas.
            resultadoTotal = dos.Concat(uno);
        }

        private void concatenacion2(IEnumerable<String> uno, List<String> dos)
        {
            //Recibe como parametros dos listas, diferentes entre si.
            //Metodo para concatenar dos listas.
            resultadoTotal = dos.Concat(uno);
            //Metodo para imprimir el resultado.
            imprimir();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUniverso_Click(object sender, EventArgs e)
        {
            //Vaciamos nuestra variable.
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato para el universo");
            //Lo guardamos en nuestra lista correspondiente.
            universo.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label4.Text += auxiliar + "\n";
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            //Vaciamos nuestra variable.
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato para el conjunto A");
            //Lo guardamos en nuestra lista correspondiente.
            mundoA.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label5.Text += auxiliar + "\n";
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            //Vaciamos nuestra variable.
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato para el conjunto B");
            //Lo guardamos en nuestra lista correspondiente.
            mundoB.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label7.Text += auxiliar + "\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Volvemos true nuesta variable
            operacionA = true;
            //Imprimimos en pantalla.
            txtOpera.Text += "A";
            //Para conocer que conjunto presiono primero.
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
            //Volvemos true nuesta variable
            operacionB = true;
            //Imprimimos en pantalla.
            txtOpera.Text += "B";
            //Para conocer que conjunto presiono primero.
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
            //Limpiamos todas nuestras variables.
            label15.Text = "";
            label16.Text = "";
            txtOpera.Text = "";
            primero = "";
            segundo = "";
            tercero = "";
            operacionA = false;
            operacionB = false;
            operacionC = false;
            operadorPrimero = "";
            operadorSegundo = "";
            operacionUnion = false;
            operacionComple = false;
            operacionInter = false;
            operacionDiferen = false;
            operacionConca = false;
            operacionProducto = false;
            operacionPotencia = false;
            operacionPertenencia = false;
            operacionPertenencia2 = false;
            resultados.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Volvemos true nuesta variable.
            operacionC = true;
            //Imprimimos en pantalla.
            txtOpera.Text += "C";
            //Para conocer que conjunto presiono primero.
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
            //Para saber cuantas operaciones desea realizar.
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
            //Preguntamos que varaible es true, con el fin de conocer que operacion realizar.
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
            //Cuando hacemos dos operaciones, primero llamamos a nuestro metodo para que realice la primera operacion.
            UnaOperacion();
            //Preguntamos que operacion es la segunda.
            if (operadorSegundo == "Union")
            {
                //Preguntamos cual el tercer conjunto que introdujo el usuario.
                if (tercero == "A")
                {
                    ///Mandamos al metodo "especial", los resultados de los dos primeros conjuntos y a continuación
                    // el tercer conjunto.
                    union2(resultadoTotal, mundoA);
                    //Imprimimos los resultados finales.
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
                    imprimir();
                }
                else if (tercero == "B")
                {
                    interseccion2(resultadoTotal, mundoB);
                    imprimir();
                }
                else if (tercero == "C")
                {
                    interseccion2(resultadoTotal, mundoC);
                    imprimir();
                }
            }
            else if (operadorSegundo == "Diferencia")
            {
                if (tercero == "A")
                {
                    diferencia2(resultadoTotal, mundoA);
                    imprimir();
                }
                else if (tercero == "B")
                {
                    diferencia2(resultadoTotal, mundoB);
                    imprimir();
                }
                else if (tercero == "C")
                {
                    diferencia2(resultadoTotal, mundoC);
                    imprimir();
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
            //Preguntamos que variables son true.
            if (operacionA && operacionB)
            {
                //Preguntamos el orden en que introdujo los conjuntos.
                if (primero == "A" && segundo == "B")
                {
                    //Enviamos los conjuntos de manera ordenada.
                    union(mundoA, mundoB);
                }
                //En caso de que sea al revez los mandamos en orden.
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
            //Preguntamos que variables son true.
            if (operacionA && operacionB)
            {
                //Preguntamos el orden en que introdujo los conjuntos.
                if (primero == "A" && segundo == "B")
                {
                    //Enviamos los conjuntos de manera ordenada.
                    pertenencia(mundoA, mundoB);
                }
                //En caso de que sea al revez los mandamos en orden.
                else 
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
                else 
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
                else 
                {
                    pertenencia(mundoC, mundoB);
                }
            }
        }

        private void auxiliarPertenencia2()
        {
            //Preguntamos que variables son true.
            if (operacionA && operacionB)
            {
                //Preguntamos el orden en que introdujo los conjuntos.
                if (primero == "A" && segundo == "B")
                {
                    //Enviamos los conjuntos de manera ordenada.
                    pertenencia(mundoB, mundoA);
                }
                //En caso de que sea al revez los mandamos en orden.
                else 
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
                else 
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
                else 
                {
                    pertenencia(mundoB, mundoC);
                }
            }
        }

        private void auxiliarConcatenacion()
        {
            //Preguntamos que variables son true.
            if (operacionA && operacionB)
            {
                //Preguntamos el orden en que introdujo los conjuntos.
                if (primero == "A" && segundo == "B")
                {
                    //Enviamos los conjuntos de manera ordenada.
                    concatenacion(mundoA, mundoB);
                    //Imprimimos los valores.
                    imprimir();
                }
                //En caso de que sea al revez los mandamos en orden.
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
            //Preguntamos que variables son true.
            if (operacionA && operacionB)
            {
                //Preguntamos el orden en que introdujo los conjuntos.
                if (primero == "A" && segundo == "B")
                {
                    //Enviamos los conjuntos de manera ordenada.
                    producto(mundoA, mundoB);
                    //Imprimimos los resultados.
                    imprimir();
                }
                //En caso de que sea al revez los mandamos en orden.
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
            //Preguntamos que variables son true.
            if (operacionA && operacionB)
            {
                //Preguntamos el orden en que introdujo los conjuntos.
                if (primero == "A" && segundo == "B")
                {
                    //Enviamos los conjuntos de manera ordenada.
                    diferencia(mundoA, mundoB);
                    //Imprimios los valroes.
                    imprimir();
                }
                //En caso de que sea al revez los mandamos en orden.
                else
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
                else 
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
                else 
                {
                    diferencia(mundoC, mundoB);
                    imprimir();
                }
            }

        }

        private void auxiliarInterseccion()
        {
            //Preguntamos que variables son true.
            if (operacionA && operacionB)
            {
                //Enviamos los conjuntos de manera ordenada.
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
            //Preguntamos que variables son true.
            if (operacionA)
            {
                //Enviamos los conjuntos de manera ordenada.
                complemento(mundoA);
                //Imprimimos los resultados.
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
            //Preguntamos que variables son true.
            if (operacionA)
            {
                //Enviamos los conjuntos de manera ordenada.
                potencia(mundoA);
            }
            else if (operacionB)
            {
                potencia(mundoB);
            }
            else
            {
                potencia(mundoC);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Imprimimos en pantalla.
            txtOpera.Text += "'";
            //Volvemos true nuesta variable.
            operacionComple = true;
            //Para conocer que conjunto presiono primero.
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
            //Imprimimos en pantalla.
            txtOpera.Text += "∪ ";
            //Volvemos true nuesta variable.
            operacionUnion = true;
            //Para conocer que conjunto presiono primero.
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
            //Imprimimos en pantalla.
            txtOpera.Text += "∩";
            //Volvemos true nuesta variable.
            operacionInter = true;
            //Para conocer que conjunto presiono primero.
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
            //Imprimimos en pantalla.
            txtOpera.Text += "--";
            //Volvemos true nuesta variable.
            operacionDiferen = true;
            //Para conocer que conjunto presiono primero.
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
            //Imprimimos en pantalla.
            txtOpera.Text += "x";
            //Volvemos true nuesta variable.
            operacionProducto = true;
            //Para conocer que conjunto presiono primero.
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
            //Imprimimos en pantalla.
            txtOpera.Text += "P()";
            //Volvemos true nuesta variable.
            operacionPotencia = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Si los elementos que tiene A estan en B.
            //Imprimimos en pantalla.
            txtOpera.Text += "⊆ ";
            //Volvemos true nuesta variable.
            operacionPertenencia = true;
            // Para conocer que conjunto presiono primero.
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
            //Imprimimos en pantalla.
            txtOpera.Text += "Con";
            //Volvemos true nuesta variable.
            operacionConca = true;
            //Para conocer que conjunto presiono primero.
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
            auxiliar = InputDialog.mostrar("Introduzca algun dato del conjunto C");
            //Lo guardamos en nuestra lista correspondiente.
            mundoC.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label9.Text += auxiliar + "\n";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Si los elementos que tiene B estan en A.
            //Imprimimos en pantalla.
            txtOpera.Text += "⊃";
            //Volvemos true nuesta variable.
            operacionPertenencia2 = true;
            // Para conocer que conjunto presiono primero.
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

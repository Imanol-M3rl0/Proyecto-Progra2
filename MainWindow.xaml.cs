using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalculadoraP2C
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string valor = "";

            if (sender == btnUno)
            {
                valor = "1";
            }
            else if (sender == btnDos)
            {
                valor = "2";
            }
            else if (sender == btnTres)
            {
                valor = "3";
            }
            else if (sender == btnCuatro)
            {
                valor = "4";
            }
            else if (sender == btnCinco)
            {
                valor = "5";
            }
            else if (sender == btnSeis)
            {
                valor = "6";
            }
            else if (sender == btnSiete)
            {
                valor = "7";
            }
            else if (sender == btnOcho)
            {
                valor = "8";
            }
            else if (sender == btnNueve)
            {
                valor = "9";
            }
            else if (sender == btnCero)
            {
                valor = "0";
            }
            else if (sender == btnPuntito)
            {
                valor = ".";
            }

            if (lblResult.Content.Equals("0"))
            {
                lblResult.Content = valor;
            }
            else
            {
                lblResult.Content += valor;
            }
        }




        /*private void btnocho_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content.Equals("0"))
            {
                lblResult.Content = "8";
            }
            else
            {
                lblResult.Content += "8";
            }
        }*/

        private void btnNueve_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content.Equals("0"))
            {
                lblResult.Content = "9";
            }
            else
            {
                lblResult.Content += "9";
            }
        }

        private void btnUnoSobreX_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(lblResult.Content.ToString());
            double res = 1 / (num + 0.0);
            lblResult.Content = res.ToString();

        }

        private void btnX2_Click(object sender, RoutedEventArgs e)
        {
            double num = double.Parse(lblResult.Content.ToString());
            num = num * num;
            lblResult.Content = num.ToString();
        }

        private void btnMasMenos_Click(object sender, RoutedEventArgs e)
        {
            double num = double.Parse(lblResult.Content.ToString());
            num *= (-1);
            lblResult.Content = num.ToString();
        }

        private void btnFlechita_Click(object sender, RoutedEventArgs e)
        {

            string resultado = lblResult.Content.ToString();
            if (resultado.Length > 0)
            {
                if (resultado.Length == 1)
                {
                    lblResult.Content = "0";
                }
                else
                {
                    string otroResultado = resultado.Substring(0, resultado.Length - 1);
                    lblResult.Content = otroResultado;
                }

            }

        }




        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
        }

        private void btnCe_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
        }

        private void btnRaiz_Click(object sender, RoutedEventArgs e)
        {
            double num = double.Parse(lblResult.Content.ToString());
            if (num >= 0)
            {
                lblResult.Content = Math.Sqrt(num).ToString();
            }
            else
            {
                lblResult.Content = "Error :(";
            }
        }

        private void btnModulo_Click(object sender, RoutedEventArgs e)
        {
            double num = double.Parse(lblResult.Content.ToString());
            lblResult.Content = (num / 100).ToString();
        }

        double valor1 = 0;
        string operacion = "";

        private void btnSuma_Click(object sender, RoutedEventArgs e)
        {
            valor1 = double.Parse(lblResult.Content.ToString());
            operacion = "+";
            lblResult.Content = "0";
        }

        private void btnResta_Click(object sender, RoutedEventArgs e)
        {
            valor1 = double.Parse(lblResult.Content.ToString());
            operacion = "-";
            lblResult.Content = "0";
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            valor1 = double.Parse(lblResult.Content.ToString());
            operacion = "*";
            lblResult.Content = "0";
        }

        private void btnDivision_Click(object sender, RoutedEventArgs e)
        {
            valor1 = double.Parse(lblResult.Content.ToString());
            operacion = "/";
            lblResult.Content = "0";
        }

        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            double valor2 = double.Parse(lblResult.Content.ToString());

            switch (operacion)
            {
                case "+":
                    lblResult.Content = (valor1 + valor2).ToString();
                    break;
                case "-":
                    lblResult.Content = (valor1 - valor2).ToString();
                    break;
                case "*":
                    lblResult.Content = (valor1 * valor2).ToString();
                    break;
                case "/":
                    if (valor2 != 0)
                    {
                        lblResult.Content = (valor1 / valor2).ToString();
                    }
                    else
                    {
                        lblResult.Content = "Error :(";
                    }
                    break;
            }
        }
    }
}

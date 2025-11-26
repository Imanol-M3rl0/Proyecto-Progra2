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
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace WpfProyectoBancoP2C
{
    /// <summary>
    /// Lógica de interacción para WpfDataBinding.xaml
    /// </summary>
    public partial class WpfDataBinding : Window
    {
        public ObservableCollection<Cuenta> ListaCuentas { get; set; }
        public Cuenta cuentaSel { get; set; }

        public WpfDataBinding()
        {
            InitializeComponent();

            ListaCuentas = new ObservableCollection<Cuenta>
            {

                new Cuenta("Cuenta N°1", 5300),
                new Cuenta("Cuenta N°2", 10000),
                new Cuenta("Cuenta N°3", 8900),
                new Cuenta("Cuenta N°4",4900),
                new Cuenta("Cuenta N°5",2500)

            };


            DataContext = this; //explica en que contexto estamos

            lstBCuentas.ItemsSource = ListaCuentas;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNumCta.Text;
            double precio = double.Parse(txtSaldo.Text);

            if (precio > 0 && nombre != "")
            {
                ListaCuentas.Add(new Cuenta(nombre, precio));
                txtSaldo.Clear();
                txtNumCta.Clear();
            }
            else
            {
                MessageBox.Show("Error en el ingreso de datos!!");
            }



        }
        private void lstBCuentas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cuentaSel != null)
            {
                txtNumCta.Text = cuentaSel.Nombre;
                txtSaldo.Text = cuentaSel.Saldo.ToString();
            }

        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            ListaCuentas.Remove(cuentaSel);
            txtSaldo.Clear();
            txtNumCta.Clear();

        }
    }
}

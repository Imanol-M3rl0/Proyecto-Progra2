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
using System.IO;
using System.Text.RegularExpressions;

namespace WpfProyectoBancoP2C
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string rutaArchLogin = "C:\\signupPrueba\\proyectoBancoBisaProgra2.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

            TxtEmail.Text = "";
            pwdContra.Password = "";
            lblMensaje.Content = "";
            MessageBox.Show("Limpio Joven");
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtEmail.Text == "" || pwdContra.Password == "")
            {
                lblMensaje.Content = "Debe llenar todos los campos obligatorios >:(";
                lblMensaje.Foreground = Brushes.Red;
                return;
            }
            else
            {
                string datos = lblemail.Content + " " + TxtEmail.Text + "\n" + "Contraseña: " + pwdContra.Password;
            }

            try
            {
                string datos = lblemail.Content + " " + TxtEmail.Text + "\n" + "Contraseña: " + pwdContra.Password;
                File.AppendAllText(rutaArchLogin, datos, Encoding.UTF8);
                lblMensaje.Foreground = Brushes.Aqua;
                lblMensaje.Content = "Bienvenido/a !!!";

                WpfPrincipal principal = new WpfPrincipal();
                principal.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            WpfSignUp winSingUp = new WpfSignUp();
            winSingUp.Show();
            this.Close();
        }
    }
}

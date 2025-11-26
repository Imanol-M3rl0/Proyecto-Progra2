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
using System.IO;
using System.Text.RegularExpressions;

namespace WpfProyectoBancoP2C
{
    /// <summary>
    /// Lógica de interacción para WpfSignUp.xaml
    /// </summary>
    public partial class WpfSignUp : Window
    {
        private readonly string rutaArchLogin = "C:\\signupPrueba\\proyectoBancoBisaProgra2.txt";

        public WpfSignUp()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TxtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtCelular.Text = "";
            TxtEmail.Text = "";
            txtañoNac.Text = "";
            pwdContra.Password = "";
            txtResultado.Text = "";
            lblMensaje.Content = "";
            MessageBox.Show("Limpio Joven");
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            bool swEntrada = true;

            // Revisar campos vacíos 
            if (TxtNombre.Text == "" || TxtEmail.Text == "" || pwdContra.Password == "" || txtApPaterno.Text == "" || txtCelular.Text == "" || txtañoNac.Text == "")
            {
                lblMensaje.Content = "Debe llenar todos los campos obligatorios >:(";
                lblMensaje.Foreground = Brushes.Red;
                return;
            }

            // Apellido materno en el caso que no lo puso
            string apMaterno = "sin Ap. Materno";
            if (txtApMaterno.Text != "")
            {
                apMaterno = txtApMaterno.Text;
            }

            // generar un  correo 
            string correo = TxtNombre.Text.ToLower()[0] + txtApPaterno.Text.ToLower() + apMaterno.ToLower()[0] + "@univalle.edu";

            // Patrones para validación
            string letterPattern = "^[A-Za-z]+$";
            string numericPattern = "^[0-9]{8}$";
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string yearPattern = @"^(19|20)\d{2}$";
            string email = TxtEmail.Text;
            string contra = pwdContra.Password;

            // Validaciones
            if (!Regex.IsMatch(TxtNombre.Text, letterPattern))
            {
                MessageBox.Show("Nombre NO valido");
                TxtNombre.Clear();
                TxtNombre.Focus();
                swEntrada = false;
            }

            if (!Regex.IsMatch(txtApPaterno.Text, letterPattern))
            {
                MessageBox.Show("Apellido Paterno NO valido");
                txtApPaterno.Clear();
                txtApPaterno.Focus();
                swEntrada = false;
            }

            if (txtApMaterno.Text != "" && !Regex.IsMatch(txtApMaterno.Text, letterPattern))
            {
                MessageBox.Show("Apellido Materno NO valido");
                txtApMaterno.Clear();
                txtApMaterno.Focus();
                swEntrada = false;
            }

            if (!Regex.IsMatch(txtCelular.Text, numericPattern))
            {
                MessageBox.Show("Nro de celular NO valido (este debe tener 8 dígitos)");
                txtCelular.Clear();
                txtCelular.Focus();
                swEntrada = false;
            }

            if (!Regex.IsMatch(TxtEmail.Text, emailPattern))
            {
                MessageBox.Show("Email NO válido(falto  @ o un punto)");
                TxtEmail.Clear();
                TxtEmail.Focus();
                swEntrada = false;
            }

            if (!Regex.IsMatch(txtañoNac.Text, yearPattern))
            {
                MessageBox.Show("Año de nacimiento NO valido");
                txtañoNac.Clear();
                txtañoNac.Focus();
                swEntrada = false;
            }

            if (pwdContra.Password.Length < 8)
            {
                MessageBox.Show("Contraseña demasiado corta (mínimo 8 caracteres bro)");
                pwdContra.Clear();
                pwdContra.Focus();
                swEntrada = false;
            }


            if (swEntrada)
            {
                // Mostrar rresults
                txtResultado.Text = "\n" + lblNombre.Content + " " + TxtNombre.Text.ToLower() + "\n" +
                                    lblApPaterno.Content + " " + txtApPaterno.Text + "\n" +
                                    lblApMaterno.Content + " " + apMaterno + "\n" +
                                    lblCelular.Content + " " + txtCelular.Text + "\n" +
                                    lblemail.Content + " " + TxtEmail.Text + "\n" +
                                    lblañoNac.Content + " " + txtañoNac.Text + "\n" +
                                    "Contraseña: " + pwdContra.Password;

                // Abrir ventana principal
                WpfPrincipal principal = new WpfPrincipal();
                principal.Show();
                this.Close();

                try
                {
                    string datos = txtResultado.Text + "\n";
                    File.AppendAllText(rutaArchLogin, datos, Encoding.UTF8);
                    lblMensaje.Foreground = Brushes.Aqua;
                    lblMensaje.Content = "Bienvenido/a " + TxtNombre.Text + "!!!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

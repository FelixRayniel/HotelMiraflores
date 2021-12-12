using HotelMiraflores.BLL;
using HotelMiraflores.Entidades;
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

namespace HotelMiraflores.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rHuespedes.xaml
    /// </summary>
    public partial class rHuespedes : Window
    {
        private Huespedes huespedes = new Huespedes();
        public rHuespedes()
        {
            InitializeComponent();
            this.DataContext = null;
            Limpiar();

            huespedes.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;
        }
        private void Limpiar()
        {
            this.huespedes = new Huespedes();
            this.DataContext = huespedes;

            huespedes.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = huespedes;

            huespedes.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese un nombre", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CedulaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el numero de cedula", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CedulaTextBox.Text.Length > 0 && CedulaTextBox.Text.Length != 11)
            {
                esValido = false;
                MessageBox.Show("Numero de Telefono incompleto (Debe de tener 10 digitos)", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese un numero de telefono", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (TelefonoTextBox.Text.Length > 0 && TelefonoTextBox.Text.Length != 10)
            {
                esValido = false;
                MessageBox.Show("Numero de Telefono incompleto (Debe de tener 10 digitos)", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese un email al usuario", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (EmailTextBox.Text.Length > 0 && !Utilidades.ComprobarFormatoEmail(EmailTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Email incorrecto, ingrese un email valido (Example@dominio.com)", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (DireccionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese una direccion al usuario", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var HuespedEncontrado = HuespedesBLL.Buscar(Utilidades.ToInt(HuespedIDTextBox.Text));

            if (HuespedEncontrado != null)
            {
                huespedes = HuespedEncontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("NO SE PUDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            var paso = HuespedesBLL.Guardar(huespedes); ;

            if (paso)
            {
                Limpiar();
                MessageBox.Show("SE HA GUARDADO EL HUESPED EXISTOSAMENTE", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR EL HUESPED ", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var HuespedEncontrado = HuespedesBLL.Buscar(Utilidades.ToInt(HuespedIDTextBox.Text));

            if (HuespedEncontrado == null)
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                HuespedesBLL.Eliminar(huespedes.HuespedId);
                MessageBox.Show("HUESPED ELIMINADO", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

        }

        private void AllTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}

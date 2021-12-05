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
    /// Lógica de interacción para rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios Usuario = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = Usuario;
            Limpiar();

            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;

            RolComboBox.ItemsSource = RolesBLL.GetRoles();
            RolComboBox.SelectedValuePath = "RolId";
            RolComboBox.DisplayMemberPath = "Descripcion";

           
        }

        private void Limpiar()
        {
            this.Usuario = new Usuarios();
            ClavePasswordBox.Password = string.Empty;
            ConfirmarClavePasswordBox.Password = string.Empty;
            this.DataContext = Usuario;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Usuario;
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

            if (NombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese un nombre de usuario", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (ClavePasswordBox.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese una contraseña", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (ClavePasswordBox.Password.Length > 0 && ConfirmarClavePasswordBox.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Confirme la contraseña", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (ClavePasswordBox.Password != ConfirmarClavePasswordBox.Password)
            {
                esValido = false;
                MessageBox.Show("La contraseña ingresada no conincide, intente nuevamente", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

            }

            if (RolComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un rol para el usuario", "Fallo",
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

            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese numero de telefono", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (TelefonoTextBox.Text.Length > 0 && TelefonoTextBox.Text.Length != 10)
            {
                esValido = false;
                MessageBox.Show("Numero de Telefono incompleto (Debe de tener 10 digitos)", "Fallo",
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
            var UsuarioEncontrado = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIDTextBox.Text));

            if (UsuarioEncontrado != null)
            {
                Usuario = UsuarioEncontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No se puedo encontrar el registro en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var paso = UsuariosBLL.Guardar(Usuario); ;

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Se ha guardado el usuario exitosamente", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var UsuarioEncontrado = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIDTextBox.Text));

            if (UsuarioEncontrado == null)
            {
                MessageBox.Show("No se puedo encontrar el usuario, intente nuevamente!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                UsuariosBLL.Eliminar(Usuario.UsuarioId);
                MessageBox.Show("Usuario eliminado", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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

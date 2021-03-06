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
    /// Lógica de interacción para rMarcas.xaml
    /// </summary>
    public partial class rMarcas : Window
    {
        private Marcas marcas = new Marcas();
        public rMarcas()
        {
            InitializeComponent();
            this.DataContext = null;
            Limpiar();

            marcas.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;

        }
        private void Limpiar()
        {
            this.marcas = new Marcas();
            this.DataContext = marcas;

            marcas.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = marcas;

            marcas.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese la descripcion", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var MarcaEncontrada = MarcasBLL.Buscar(Utilidades.ToInt(MarcasIdTextBox.Text));

            if (MarcaEncontrada != null)
            {
                marcas = MarcaEncontrada;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("NO SE PUDO ENCONTRAR LA MARCA EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var paso = MarcasBLL.Guardar(marcas); ;

            if (paso)
            {
                Limpiar();
                MessageBox.Show("SE HA GUARDADO LA MARCA EXISTOSAMENTE", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR LA MARCA DE HABITACIONES", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var MarcaEncontrada = MarcasBLL.Buscar(Utilidades.ToInt(MarcasIdTextBox.Text));

            if (MarcaEncontrada == null)
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                HabitacionesBLL.Eliminar(Utilidades.ToInt(MarcasIdTextBox.Text));
                MessageBox.Show("MARCA ELIMINADA", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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

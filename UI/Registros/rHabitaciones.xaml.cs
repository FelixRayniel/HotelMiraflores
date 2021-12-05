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
    /// Lógica de interacción para rHabitaciones.xaml
    /// </summary>
    public partial class rHabitaciones : Window
    {
        private Habitaciones habitacion = new Habitaciones();
        public rHabitaciones()
        {
            InitializeComponent();
            this.DataContext = null;
            Limpiar();

            habitacion.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;


            TipoHabitacionComboBox.ItemsSource = TipoHabitacionesBLL.GettipoHabitaciones();
            TipoHabitacionComboBox.SelectedValuePath = "TipoHabitacionId";
            TipoHabitacionComboBox.DisplayMemberPath = "Descripcion";

        }

        private void Limpiar()
        {
            this.habitacion = new Habitaciones();
            this.DataContext = habitacion;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = habitacion;  
        }
        private bool Validar()
        {
            bool esValido = true;

            

            if (HabitacionIDTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese un Numero de Id", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (TipoHabitacionComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese un tipo de habitacion", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TipoHabitacionComboBox.Focus();
            }

            if (NumeroTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese un Numero de habitacion", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NumeroTextBox.Focus();
            }

            if (PrecioTextBox.Text == "0")
            {
                esValido = false;
                MessageBox.Show("Ingrese un precio para la habitacion", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                PrecioTextBox.Focus();
            }

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese la descripcion", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Focus();
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var HabitacionEncontrada = HabitacionesBLL.Buscar(Utilidades.ToInt(HabitacionIDTextBox.Text));

            if (HabitacionEncontrada != null)
            {
                habitacion = HabitacionEncontrada;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var paso = HabitacionesBLL.Guardar(habitacion); ;

            if (paso)
            {
                Limpiar();
                MessageBox.Show("SE HA GUARDADO LA HABITACION EXISTOSAMENTE", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR LA HABITACION", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var HabitacionEncontrada = HabitacionesBLL.Buscar(Utilidades.ToInt(HabitacionIDTextBox.Text));

            if (HabitacionEncontrada == null)
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                HabitacionesBLL.Eliminar(habitacion.HabitacionId);
                MessageBox.Show("HABITACION ELIMINADA", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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

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
    /// Lógica de interacción para rTipoHabitaciones.xaml
    /// </summary>
    public partial class rTipoHabitaciones : Window
    {
        private TipoHabitaciones tipoHabitaciones = new TipoHabitaciones();
        public rTipoHabitaciones()
        {
            InitializeComponent();
            this.DataContext = null;
            Limpiar();
        }
        private void Limpiar()
        {
            this.tipoHabitaciones = new TipoHabitaciones();
            this.DataContext = tipoHabitaciones;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = tipoHabitaciones;
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
            TipoHabitaciones TipoHabitacionEncontrada = TipoHabitacionesBLL.Buscar(tipoHabitaciones.TipoHabitacionId);

            if (TipoHabitacionEncontrada != null)
            {
                tipoHabitaciones = TipoHabitacionEncontrada;
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
            var paso = TipoHabitacionesBLL.Guardar(tipoHabitaciones); ;

            if (paso)
            {
                Limpiar();
                MessageBox.Show("SE HA GUARDADO EL TIPO DE HABITACIONES EXISTOSAMENTE", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR EL TIPO DE HABITACIONES", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            TipoHabitaciones TipoHabitacionEncontrada = TipoHabitacionesBLL.Buscar(tipoHabitaciones.TipoHabitacionId);

            if (TipoHabitacionEncontrada == null)
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                TipoHabitacionesBLL.Eliminar(tipoHabitaciones.TipoHabitacionId);
                MessageBox.Show("TIPO HABITACION ELIMINADO", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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

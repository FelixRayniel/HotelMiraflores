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
    /// Lógica de interacción para rReservaciones.xaml
    /// </summary>
    public partial class rReservaciones : Window
    {
        private Reservaciones Reservacion = new Reservaciones();
        public rReservaciones()
        {
            InitializeComponent();
            Limpiar();

            HuespedComboBox.ItemsSource = HuespedesBLL.GetHuespedes();
            HuespedComboBox.SelectedValuePath = "HuespedId";
            HuespedComboBox.DisplayMemberPath = "Nombres";

            HabitacionComboBox.ItemsSource = HabitacionesBLL.GetHabitaciones();
            HabitacionComboBox.SelectedValuePath = "HabitacionId";
            HabitacionComboBox.DisplayMemberPath = "Numero";

            ProductosComboBox.ItemsSource = ProductosBLL.GetProductos();
            ProductosComboBox.SelectedValuePath = "ProductoId";
            ProductosComboBox.DisplayMemberPath = "Descripcion";



        }

        public void Limpiar()
        {
            this.Reservacion = new Reservaciones();
            this.DataContext = Reservacion;
            BuscarCedulaTextBox.Text = null;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Reservacion;

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Reservaciones ReservaEncontrada = ReservacionesBLL.Buscar(Reservacion.ReservacionId);

            if (ReservaEncontrada != null)
            {
                Reservacion = ReservaEncontrada;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private bool ValidarAgregarButtton()
        {
            bool esValido = true;


            if (ProductosComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CantidadTextBox.Text.Length == 0 || CantidadTextBox.Text == "0")
            {
                esValido = false;
                MessageBox.Show("Ingrese la cantidad del producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


            return esValido ;
        }

        private bool ValidarEliminarButton()
        {
            bool esValido = true ;

            if (DetalleDataGrid.SelectedItem == null )
            {
                esValido = false;
                MessageBox.Show("Seleccione un produto para poder eliminarlo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido ;   
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregarButtton())
            {
                return;
            }

            Reservacion.ReservacionDetalle.Add(new ReservacionesDetalle(
                Utilidades.ToInt(ReservacionIDTextBox.Text), int.Parse(CantidadTextBox.Text),
                GetPrecioProducto((int)ProductosComboBox.SelectedValue),
                (Productos)ProductosComboBox.SelectedItem

                ));
            Reservacion.TotalProductos += Convert.ToInt32(float.Parse(CantidadTextBox.Text) * GetPrecioProducto((int)ProductosComboBox.SelectedValue));
            Cargar();

        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidarEliminarButton())
            {
                return;
            }

            if (DetalleDataGrid.Items.Count >= 1 &&
                DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                ReservacionesDetalle T = (ReservacionesDetalle)DetalleDataGrid.SelectedValue;
                Reservacion.TotalProductos -= T.TotalProducto;
                Reservacion.ReservacionDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
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
            var paso = ReservacionesBLL.Guardar(Reservacion);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("SE HA GUARDADO LA RESERVACION EXISTOSAMENTE", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR LA RESERVACION", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Reservaciones ReservaEncontrada = ReservacionesBLL.Buscar(Reservacion.ReservacionId);

            if (ReservaEncontrada == null)
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                ReservacionesBLL.Eliminar(Reservacion.ReservacionId);
                MessageBox.Show("RESERVACION ELIMINADA", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

        }

        private bool Validar()
        {
            bool esValido = true;

            if (ReservacionIDTextBox.Text == "0")
            {
                esValido = false;
                MessageBox.Show("Ingrese un numero de Id", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (HuespedComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Busque o seleccione un huesped", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CantidadPersonasTextBox.Text == "0")
            {
                esValido = false;
                MessageBox.Show("Ingrese la cantidad de personas", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CantidadDiasTextBox.Text == "0")
            {
                esValido = false;
                MessageBox.Show("Pulse el botton Calcular dias para continuar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (HabitacionComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione una Habitacion", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            
            

            return esValido;
        }

        public bool ValidarFecha()
        {
            bool esValido = true;

            if (FechaEntradaDatePicker.SelectedDate > FechaSalidaDatePicker.SelectedDate)
            {
                esValido = false;
                MessageBox.Show("La fecha de entrada no puede ser menor que la fecha de salida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        } 

        public float GetPrecioProducto(int id)
        {
            Productos producto = ProductosBLL.Buscar(id);

            if (producto != null)
            {
                return producto.PrecioVenta;
            }

            return 0;
        }

        public float GetPrecioHabitacion(int id)
        {
            Habitaciones habitacion = HabitacionesBLL.Buscar(id);

            if (habitacion != null)
            {
                return habitacion.Precio;
            }

            return 0;
        }

        private void BuscarCedulaButton_Click(object sender, RoutedEventArgs e)
        {
            var HuespedEncontrado = HuespedesBLL.BuscarCedula(BuscarCedulaTextBox.Text);

            if (HuespedEncontrado != null)
            {
                HuespedComboBox.SelectedValue = HuespedEncontrado.HuespedId;
            }
            else
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DescuentoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CalcularDiasButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarFecha())
            {
                return;
            }
            TimeSpan ts = (FechaSalidaDatePicker.SelectedDate.Value - FechaEntradaDatePicker.SelectedDate.Value);
            int cantidadDias = (int)ts.TotalDays;
            Reservacion.CantidadDias = (cantidadDias);
            CalcularTotal();
            Cargar();
        }

        public void CalcularTotal()
        {
            Reservacion.Total = (Reservacion.CantidadDias * GetPrecioHabitacion((int)HabitacionComboBox.SelectedValue));
        }

        public void CalcularTotalGeneral()
        {
            Reservacion.TotalGeneral = Reservacion.Total + Reservacion.TotalProductos;
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularTotalGeneral();
        }

        private void TotalProductosTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!ValidarFecha())
            {
                return;
            }
            else
            {
                CalcularTotalGeneral();
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

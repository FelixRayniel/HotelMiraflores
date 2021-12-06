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
    /// Lógica de interacción para rProductos.xaml
    /// </summary>
    public partial class rProductos : Window
    {
        private Productos producto = new Productos();
        public rProductos()
        {
            InitializeComponent();
            this.DataContext = null;
            Limpiar();

            producto.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;

            MarcasComboBox.ItemsSource = MarcasBLL.GetMarcas();
            MarcasComboBox.SelectedValuePath = "MarcaId";
            MarcasComboBox.DisplayMemberPath = "Descripcion";

            DepartamentoComboBox.ItemsSource = DepartamentosBLL.GetDepartamentos();
            DepartamentoComboBox.SelectedValuePath = "DepartamentoId";
            DepartamentoComboBox.DisplayMemberPath = "Descripcion";

            SuplidorComboBox.ItemsSource = SuplidoresBLL.GetSuplidores();
            SuplidorComboBox.SelectedValuePath = "SuplidorId";
            SuplidorComboBox.DisplayMemberPath = "Nombre";
        }
        private void Limpiar()
        {
            this.producto = new Productos();
            this.DataContext = producto;

            producto.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = producto;

            producto.UsuarioId = Utilidades.Usuario.UsuarioId;
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

            if (SuplidorComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un suplidor", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (MarcasComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione una marca", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (DepartamentoComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un departamento", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (UnidadTextBox.Text == "0")
            {
                esValido = false;
                MessageBox.Show("Ingrese la cantidad de unidades del producto", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (PrecioCostoTextBox.Text == "0") 
            {
                esValido = false;
                MessageBox.Show("Ingrese el precio costo", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (PrecioVentaTextBox.Text == "0")
            {
                esValido = false;
                MessageBox.Show("Ingrese el precio de venta", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (PrecioCostoTextBox.Text != "0" && PrecioVentaTextBox.Text != "0" && float.Parse(PrecioCostoTextBox.Text) > float.Parse(PrecioVentaTextBox.Text)) 
            {
                esValido = false;
                MessageBox.Show("El precio de costo no puede ser mayor al precio de venta", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos ProductosEncontrados = ProductosBLL.Buscar(producto.ProductoId);

            if (ProductosEncontrados != null)
            {
                producto = ProductosEncontrados;
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
            var paso = ProductosBLL.Guardar(producto); ;

            if (paso)
            {
                Limpiar();
                MessageBox.Show("SE HA GUARDADO EL PRODUCTO EXISTOSAMENTE", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR EL PRODUCTO", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos ProductosEncontrados = ProductosBLL.Buscar(producto.ProductoId);

            if (ProductosEncontrados == null)
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                ProductosBLL.Eliminar(producto.ProductoId);
                MessageBox.Show("PRODUCTO ELIMINADO", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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

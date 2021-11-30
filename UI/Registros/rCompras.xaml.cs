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
    /// Lógica de interacción para rCompras.xaml
    /// </summary>
    public partial class rCompras : Window
    {
        private Compras compras = new Compras();
        public rCompras()
        {
            InitializeComponent();
            Limpiar();

            SuplidorComboBox.ItemsSource = SuplidoresBLL.GetSuplidores();
            SuplidorComboBox.SelectedValuePath = "SuplidorId";
            SuplidorComboBox.DisplayMemberPath = "Nombre";

            ProductoComboBox.ItemsSource = ProductosBLL.GetProductos();
            ProductoComboBox.SelectedValuePath = "ProductoId";
            ProductoComboBox.DisplayMemberPath = "Descripcion";
        }
        public void Limpiar()
        {
            this.compras = new Compras();
            this.DataContext = compras;
            BuscarProductoTextBox.Text = null;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = compras;

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Compras CompraEncontrada = ComprasBLL.Buscar(compras.CompraId);

            if (CompraEncontrada != null)
            {
                compras = CompraEncontrada;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BuscarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            var ProductoEncontrado = ProductosBLL.Buscar(Utilidades.ToInt(BuscarProductoTextBox.Text));

            if (ProductoEncontrado != null)
            {
                ProductoComboBox.SelectedValue = ProductoEncontrado.ProductoId;
            }
            else
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CalcularCantidadButton_Click(object sender, RoutedEventArgs e)
        {
            
            Cargar();
        }
        public void CalcularTotal()
        {
            compras.TotalCompra = (GetPrecioCosto((int)ProductoComboBox.SelectedValue) * Utilidades.ToInt(CantidadTextBox.Text));
        }
        public float GetPrecioCosto(int Id)
        {
            Productos producto = ProductosBLL.Buscar(Id);
            if (producto != null)
            {
                return producto.PrecioCosto;
            }

            return 0;
        }
        public int GetCantidadDisponible(int Id)
        {
            Productos producto = ProductosBLL.Buscar(Id);
            if (producto != null)
            {
                return producto.CantidadDisponible;
            }

            return 0;
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
            var paso = ComprasBLL.Guardar(compras);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("SE HA GUARDADO LA COMPRA EXISTOSAMENTE", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR LA COMPRA", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private bool Validar()
        {
            bool esValido = true;

            if (CompraIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("INGRESE UN NUMERO DE ID", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Compras CompraEncontrada = ComprasBLL.Buscar(compras.CompraId);

            if (CompraEncontrada == null)
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                ComprasBLL.Eliminar(compras.CompraId);
                MessageBox.Show("COMPRA ELIMINADA", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }

        private void EliminarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 &&
                DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                ComprasDetalle C = (ComprasDetalle)DetalleDataGrid.SelectedValue;
                compras.TotalCompra-= C.SubtotalCompra;
                compras.ComprasDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
                compras.ComprasDetalle.Add(new ComprasDetalle
               (
                (int)ProductoComboBox.SelectedValue, Utilidades.ToInt(CompraIdTextBox.Text),
                GetPrecioCosto((int)ProductoComboBox.SelectedValue),
                Utilidades.ToInt(CantidadTextBox.Text), GetCantidadDisponible((int)ProductoComboBox.SelectedValue),
                (Productos)ProductoComboBox.SelectedItem
                ));
            compras.TotalCompra += Convert.ToInt32(float.Parse(CantidadTextBox.Text) * GetPrecioCosto((int)ProductoComboBox.SelectedValue));
            Cargar();
        }

       
    }
}

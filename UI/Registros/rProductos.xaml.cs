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

            MarcasComboBox.ItemsSource = MarcasBLL.GetMarcas();
            MarcasComboBox.SelectedValuePath = "MarcaId";
            MarcasComboBox.DisplayMemberPath = "Descripcion";

            DepartamentoComboBox.ItemsSource = DepartamentosBLL.GetDepartamentos();
            DepartamentoComboBox.SelectedValuePath = "DepartamentoID";
            DepartamentoComboBox.DisplayMemberPath = "Descripcion";

            SuplidorComboBox.ItemsSource = SuplidoresBLL.GetSuplidores();
            SuplidorComboBox.SelectedValuePath = "SuplidorID";
            SuplidorComboBox.DisplayMemberPath = "Nombre";
        }
        private void Limpiar()
        {
            this.producto = new Productos();
            this.DataContext = producto;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = producto;
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
    }
}

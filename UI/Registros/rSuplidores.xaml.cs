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
    /// Lógica de interacción para rSuplidores.xaml
    /// </summary>
    public partial class rSuplidores : Window
    {
        private Suplidores suplidor = new Suplidores();
        public rSuplidores()
        {
            InitializeComponent();
            this.DataContext = null;

        }

        private void Limpiar()
        {
            this.suplidor = new Suplidores();
            this.DataContext = suplidor;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = suplidor;
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
            Suplidores SuplidorEncontrado = SuplidoresBLL.Buscar(suplidor.SuplidorID);

            if (SuplidorEncontrado != null)
            {
                suplidor = SuplidorEncontrado;
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
            var paso = SuplidoresBLL.Guardar(suplidor); ;

            if (paso)
            {
                Limpiar();
                MessageBox.Show("SE HA GUARDADO EL SUPLIDOR EXISTOSAMENTE", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("NO SE PUDO GUARDAR EL SUPLIDOR", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Suplidores SuplidorEncontrado = SuplidoresBLL.Buscar(suplidor.SuplidorID);

            if (SuplidorEncontrado == null)
            {
                MessageBox.Show("NO SE PUEDO ENCONTRAR EL REGISTRO EN LA BASE DE DATOS", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                SuplidoresBLL.Eliminar(suplidor.SuplidorID);
                MessageBox.Show("SUPLIDOR ELIMINADO", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

        }


    }
}

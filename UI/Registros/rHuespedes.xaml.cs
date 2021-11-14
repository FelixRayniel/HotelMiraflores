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
        }
        private void Limpiar()
        {
            this.huespedes = new Huespedes();
            this.DataContext = huespedes;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = huespedes;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (CedulaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el numero de cedula", "Fallo",
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
                HuespedesBLL.Eliminar(huespedes.HuespedID);
                MessageBox.Show("HUESPED ELIMINADO", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

        }
    }
}

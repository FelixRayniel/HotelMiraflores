using HotelMiraflores.UI.Consultas;
using HotelMiraflores.UI.Registros;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelMiraflores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroSuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rSuplidores rs = new rSuplidores();
            rs.Show();
        }


        private void RegistroTipoHabitacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rTipoHabitaciones th = new rTipoHabitaciones();
            th.Show();
        }

        private void RegistroHabitacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rHabitaciones rh = new rHabitaciones();

            rh.Show();
        }

        private void RegistroMarcasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rMarcas rm = new rMarcas();
            rm.Show();
        }

        private void RegistroProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProductos rp = new rProductos();
            rp.Show();
        }

        private void RegistroReservacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rReservaciones rs = new rReservaciones();
            rs.Show();
        }

        private void RegistroHuespedesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rHuespedes rh = new rHuespedes();
            rh.Show();
        }

        private void ConsultaHuespedesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaSuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cSuplidores cs = new cSuplidores();
            cs.Show();
        }

        private void ConsultaMarcasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaTipoHabitacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaHabitacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cHabitaciones ch = new cHabitaciones();

            ch.Show();
        }

        private void ConsultaReservacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
            cHuespedes rh = new cHuespedes();
            rh.Show();
        }

        private void ConsultaSuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cSuplidores cs = new cSuplidores();
            cs.Show();
        }

        private void ConsultaMarcasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cMarcas rm = new cMarcas();
            rm.Show();
        }

        private void ConsultaProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cProductos rp = new cProductos();
            rp.Show();
        }

        private void ConsultaTipoHabitacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cTipoHabitaciones th = new cTipoHabitaciones();
            th.Show();
        }

        private void ConsultaHabitacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cHabitaciones ch = new cHabitaciones();

            ch.Show();
        }

        private void ConsultaReservacionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cReservaciones cr = new cReservaciones();
            cr.Show();
        }

        private void RegistroUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios ru = new rUsuarios();
            ru.Show();
        }

        private void RegistroComrasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCompras r = new rCompras();
            r.Show();
        }

        private void ConsultaComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cCompras rp = new cCompras();
            rp.Show();
        }

        private void ConsultaUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cu = new cUsuarios();
            cu.Show();
        }

       
    }
}

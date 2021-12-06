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

namespace HotelMiraflores.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cReservaciones.xaml
    /// </summary>
    public partial class cReservaciones : Window
    {
        private Reservaciones Reservacion = new Reservaciones();
        public cReservaciones()
        {
            InitializeComponent();

            Reservacion.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Reservaciones>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ReservacionesBLL.GetList(r => r.ReservacionId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = ReservacionesBLL.GetList(r => r.HuespedId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = ReservacionesBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = ReservacionesBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = ReservacionesBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
    
}

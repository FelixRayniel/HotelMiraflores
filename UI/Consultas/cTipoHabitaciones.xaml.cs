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
    /// Lógica de interacción para cTipoHabitaciones.xaml
    /// </summary>
    public partial class cTipoHabitaciones : Window
    {
        private TipoHabitaciones tipoHabitaciones = new TipoHabitaciones();
        public cTipoHabitaciones()
        {
            InitializeComponent();

            tipoHabitaciones.UsuarioId = Utilidades.Usuario.UsuarioId;
            UsuarioTextBlock.Text = Utilidades.Usuario.NombreUsuario;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<TipoHabitaciones>();
            string criterio = CriterioTextBox.Text.Trim();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = TipoHabitacionesBLL.GetList(p => true);
                        break;
                    case 1:
                        listado = TipoHabitacionesBLL.GetList(p => p.Descripcion.ToLower().Contains(criterio.ToLower()));
                        break;
                    case 2:
                        listado = TipoHabitacionesBLL.GetList(p => p.TipoHabitacionId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = TipoHabitacionesBLL.GetList(p => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

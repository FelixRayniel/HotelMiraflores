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
    /// Lógica de interacción para cHuespedes.xaml
    /// </summary>
    public partial class cHuespedes : Window
    {
        public cHuespedes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Huespedes>();
            string criterio = CriterioTextBox.Text.Trim();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = HuespedesBLL.GetList(p => true);
                        break;
                    case 1:
                        listado = HuespedesBLL.GetList(p => p.Cedula.ToLower().Contains(criterio.ToLower()));
                        break;
                    case 2:
                        listado = HuespedesBLL.GetList(p => p.HuespedID == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = HuespedesBLL.GetList(p => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

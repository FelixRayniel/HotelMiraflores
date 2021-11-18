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
    /// Lógica de interacción para cMarcas.xaml
    /// </summary>
    public partial class cMarcas : Window
    {
        public cMarcas()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Marcas>();
            string criterio = CriterioTextBox.Text.Trim();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = MarcasBLL.GetList(p => true);
                        break;
                    case 1:
                        listado = MarcasBLL.GetList(p => p.Descripcion.ToLower().Contains(criterio.ToLower()));
                        break;
                    case 2:
                        listado = MarcasBLL.GetList(p => p.MarcaId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = MarcasBLL.GetList(p => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

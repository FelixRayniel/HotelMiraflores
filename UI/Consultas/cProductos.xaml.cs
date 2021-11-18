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
    /// Lógica de interacción para cProductos.xaml
    /// </summary>
    public partial class cProductos : Window
    {
        public cProductos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();
            string criterio = CriterioTextBox.Text.Trim();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProductosBLL.GetList(p => true);
                        break;
                    case 1:
                        listado = ProductosBLL.GetList(p => p.DepartamentoID == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                    case 2:
                        listado = ProductosBLL.GetList(p => p.ProductoId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                    case 3:
                        listado = ProductosBLL.GetList(p => p.SuplidorID == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = ProductosBLL.GetList(p => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

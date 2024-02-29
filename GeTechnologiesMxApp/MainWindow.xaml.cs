using Entity.Model;
using GeTechnologiesMxApp.Service;
using System.Windows;
using System.Windows.Controls;

namespace GeTechnologiesMxApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DirectorioService d;
        public MainWindow()
        {
            InitializeComponent();
            d = new DirectorioService();
            cargaGrid();
        }

        private void cargaGrid()
        {
            var res = d.buscaPersona();
            ListaPersonas.ItemsSource = res;
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = ListaPersonas;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            PersonaModel persona = (PersonaModel)Row.DataContext;
            d.eliminaPersona(persona.Identificacion);
            cargaGrid();
        }
        private void clearControls()
        {
            txtNombre.Text = string.Empty;
            txtAPaterno.Text = string.Empty;
            txtAMaterno.Text = string.Empty;
            txtIdentificacion.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonaModel persona = new PersonaModel()
            {
                Nombre = txtNombre.Text,
                ApellidoPaterno = txtAPaterno.Text,
                ApellidoMaterno = txtAMaterno.Text,
                Identificacion = txtIdentificacion.Text
            };

            d.guardaPersona(persona);
            clearControls();
            cargaGrid();
        }

        private void btnFacturas_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = ListaPersonas;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            PersonaModel persona = (PersonaModel)Row.DataContext;
            Facturas f = new Facturas(persona);
            f.Show();
        }
    }
}

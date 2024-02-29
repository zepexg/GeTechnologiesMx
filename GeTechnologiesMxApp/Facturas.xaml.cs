using Entity.Model;
using GeTechnologiesMxApp.Service;
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

namespace GeTechnologiesMxApp
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Facturas : Window
    {
        private PersonaModel _persona;
        private FacturaService _service;
        public Facturas(PersonaModel persona)
        {
            InitializeComponent();
            _service = new FacturaService();
            _persona = persona;
            lblPersona.Content = _persona.Nombre + ' ' + _persona.ApellidoPaterno + ' ' + _persona.ApellidoMaterno;
            cargaGrid();
        }

        private void cargaGrid()
        {
            var res = _service.buscaFacturasByPersona(_persona.Id);
            ListaFacturas.ItemsSource = res;
        }
        private void clearControls()
        {
            txtMonto.Text = string.Empty;
            txtFecha.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FacturaModel factura = new FacturaModel()
            {
                Monto = decimal.Parse(txtMonto.Text),
                PersonaId = _persona.Id,
                Fecha = txtFecha.DisplayDate
            };
            _service.guardaFactura(factura);
            clearControls();
            cargaGrid();
        }
    }
}

using BL.Donantes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Donantes
{
    public partial class FormReporteDonantes : Form
    {
        public FormReporteDonantes()
        {
            InitializeComponent();

            var _donantesBL = new DonantesBL();
            var bidingSource = new BindingSource();
            bidingSource.DataSource = _donantesBL.ObtenerDonantes();

            var reporte = new ReporteDonantes();
            reporte.SetDataSource(bidingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();

        }

        private void FormReporteDonantes_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace DB_Maket.Report
{
    public partial class CntrF : Form
    {
        public CntrF()
        {
            InitializeComponent();
        }

        private void CntrF_Load(object sender, EventArgs e)
        {
            ASSDataSet ass = new ASSDataSet();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT*From dbo.Contraindications", con);
            SDA.Fill(ass, ass.Tables[0].TableName);

            ReportDataSource rds = new ReportDataSource("DataSet1", ass.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

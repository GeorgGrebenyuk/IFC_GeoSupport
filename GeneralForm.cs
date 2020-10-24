using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFC_AddGeolocation_Ver1
{
	public partial class GeneralForm : Form
	{
		public GeneralForm()
		{
			InitializeComponent();
		}


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm main_form = new MainForm();
            main_form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main_form = new MainForm();
            main_form.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/GeorgGrebenyuk/IFC_GeoSupport");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.tbs-soft.ru");
        
        }

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}

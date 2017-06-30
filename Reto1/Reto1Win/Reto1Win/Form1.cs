using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reto1Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reto1DBDataSet.Modelado' table. You can move, or remove it, as needed.
            this.modeladoTableAdapter.Fill(this.reto1DBDataSet.Modelado);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           var f = new DetailForm();
            f.ShowDialog();
        }
    }
}

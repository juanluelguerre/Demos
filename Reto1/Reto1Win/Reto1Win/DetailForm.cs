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
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reto1DBDataSet.Modelado' table. You can move, or remove it, as needed.
            this.modeladoTableAdapter.Fill(this.reto1DBDataSet.Modelado);

        }
    }
}

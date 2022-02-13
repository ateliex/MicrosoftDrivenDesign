using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ateliex
{
    public partial class ModeloForm : Form
    {
        public ModeloForm()
        {
            InitializeComponent();
        }

        private void modeloBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.modeloBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ateliexDataSet);

        }

        private void ModeloForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ateliexDataSet.ModeloRecurso' table. You can move, or remove it, as needed.
            this.modeloRecursoTableAdapter.Fill(this.ateliexDataSet.ModeloRecurso);
            // TODO: This line of code loads data into the 'ateliexDataSet.Modelo' table. You can move, or remove it, as needed.
            this.modeloTableAdapter.Fill(this.ateliexDataSet.Modelo);

        }
    }
}

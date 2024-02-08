using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOLAB1
{
    public partial class IntDialog : Form
    {
        public int Result { get; set; }

        public IntDialog(string title)
        {
            InitializeComponent();
            label1.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = int.Parse(textBox1.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

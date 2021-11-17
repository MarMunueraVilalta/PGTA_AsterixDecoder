using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsterixDecoder
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void buttonLoadDecoder_Click(object sender, EventArgs e)
        {
            Table_form f_tf = new Table_form();
            this.Hide();
            f_tf.ShowDialog();
            this.Close();
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {
            Map f_tf = new Map();
            this.Hide();
            f_tf.ShowDialog();
            this.Close();
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            LoadFile f_lf = new LoadFile();
            this.Hide();
            f_lf.ShowDialog();
            this.Close();
        }

        private void button_Help_Click(object sender, EventArgs e)
        {
            Help f_h = new Help();
            //this.Hide();
            f_h.ShowDialog();
            //this.Close();
        }
    }
}

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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            Help_Load f_hl = new Help_Load();
            this.Hide();
            f_hl.ShowDialog();
            this.Close();
        }
    }
}

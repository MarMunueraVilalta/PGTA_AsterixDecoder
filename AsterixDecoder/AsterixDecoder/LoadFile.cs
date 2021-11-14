using ClassLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsterixDecoder
{
    public partial class LoadFile : Form
    {
        string path = "";
        Thread thread1;
        bool threat_active = true;
        bool cell = false;

        public LoadFile()
        {
            InitializeComponent();
        }

        private void buttonLoadDecoder_Click(object sender, EventArgs e)
        {
            Table_form f_tf = new Table_form();
            this.Hide();
            f_tf.setLoadFile(this);
            f_tf.ShowDialog();
            //this.Close(); Si fem això tanquem el form i per tant el thread.
        }

        public LoadFile getLoadFile()
        {
            return this;
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {
            Map f_m = new Map();
            this.Hide();
            f_m.ShowDialog();
            this.Close();
        }

        public void LoadTable()
        {

            //Em connecto a la base de dades
            DBHelper db = new DBHelper();
            MySqlConnection myConnection = db.ConnectToMyDatabase();
            List<string[]> llista_missatges = new List<string[]>();

            try
            {
                AsterixFile f = new AsterixFile(path);
                this.Invoke((MethodInvoker)delegate
                {
                    set_loadTime_lbl(1, 1, 1, "Wait for it...");
                });
                llista_missatges = f.fromHexToBinary();


                //fem el load
                int vuelta = 0;
                int numKey = 1;
                int n = llista_missatges.Count();

                db.emptyTable("t_cat10", myConnection);
                db.emptyTable("t_cat21", myConnection);

                for (int i = 0; i < n; i++)
                {
                    CAT21 cat21 = new CAT21();
                    CAT10 cat10 = new CAT10();

                    try
                    {
                        if (threat_active == false)
                            break;

                        string CAT = Convert.ToInt32(llista_missatges[i][0], 2).ToString();

                        if (CAT == "21")
                        {
                            cat21.Record_field(llista_missatges[i]);
                            db.fillTableCat21(numKey, cat21, myConnection);
                        }
                        else if (CAT == "10")
                        {
                            cat10.Record_field(llista_missatges[i]);
                            db.fillTableCat10(numKey, cat10, myConnection);
                        }
                        else
                        { }
                        this.Invoke((MethodInvoker)delegate
                        {
                            set_loadTime_lbl(i, n, 0, "");
                        });
                    }
                    catch (Exception)
                    {
                    }
                    vuelta++;
                    numKey++;
                }
            }
            catch (Exception e)
            { }
            db.closeDatabase(myConnection);
        }

        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            //Agafo el path del fitxer
            OpenFileDialog fileChoosed = new OpenFileDialog();
            fileChoosed.Filter = "ASTERIX Files|*.ast";
            if (fileChoosed.ShowDialog() == DialogResult.OK)
            {
                this.path = fileChoosed.FileName;
            }
            threat_active = true;
            thread1 = new Thread(new ThreadStart(LoadTable));
            thread1.Start();
        }

        private void stop_load_btn_Click(object sender, EventArgs e)
        {
            set_loadTime_lbl(1, 1, 1, "Nothing loading");
            this.threat_active = false;
        }

        public void set_loadTime_lbl(int i, int n, int mode, string text)
        {
            if (mode == 0)
                this.LoadTime_lbl1.Text = "Loading status: " + Convert.ToString(i) + " / " + n.ToString();
            else
                this.LoadTime_lbl1.Text = "Loading status: " + text;

            this.LoadTime_lbl1.Refresh();
        }
    }
}

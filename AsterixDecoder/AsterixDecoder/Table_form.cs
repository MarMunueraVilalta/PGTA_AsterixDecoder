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
using Microsoft.Win32;

namespace AsterixDecoder
{
    public partial class Table_form : Form
    {
        string path = "";
        Thread thread1;
        bool threat_active = true;
        bool cell = false;
        MySqlConnection myConnection;
        LoadFile f_lf;

        public Table_form()
        {
            InitializeComponent();
            tracknumber_tb_cat10.Visible = false;
            label6_cat10.Visible = false;
            label4_cat10.Visible = false;
            dateTimePicker1_cat10.Visible = false;
            dateTimePicker2_cat10.Visible = false;
            checkBox_datefilter_cat10.Visible = false;
            checkBox_trackfilter_cat10.Visible = false;
            label7_cat10.Visible = false;
            checkBox_targetid_cat10.Visible = false;
            targetid_tb_cat10.Visible = false;
            label4_cat21.Visible = false;
            checkBox_datefilter_cat21.Visible = false;
            dateTimePicker1_cat21.Visible = false;
            dateTimePicker2_cat21.Visible = false;
            checkBox_trackfilter_cat21.Visible = false;
            checkBox_targetid_cat21.Visible = false;
            label5_cat21.Visible = false;
            label6_cat21.Visible = false;
            targetid_tb_cat21.Visible = false;
            tracknumber_tb_cat21.Visible = false;
            label8_cat21.Visible = false;
            label8_cat10.Visible = false;
            mode3A_tb_cat21.Visible = false;
            mode3A_tb_cat10.Visible = false;
            checkBox_mode3A_cat21.Visible = false;
            checkBox_mode3A_cat10.Visible = false;
        }

        public MySqlConnection getConnection()
        {
            return myConnection;
        }

        /*private void buttonLoadData_Click(object sender, EventArgs e, DataGridView dataGrid_bbdd)
        {
            DBHelper db = new DBHelper();
            MySqlConnection myConnection = db.ConnectToMyDatabase();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_cat21;", myConnection);

            try
            {
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                myAdapter.SelectCommand = cmd;
                DataTable data = new DataTable();
                myAdapter.Fill(data);
                BindingSource formulario = new BindingSource();
                formulario.DataSource = data;
                dataGrid_bbdd.DataSource = formulario;
                myAdapter.Update(data);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }
        }*/


        private void ShowData_btn_Click_1(object sender, EventArgs e)
        {
            int low = Convert.ToInt32(numericUpDown.Value);
            ShowData(low);
        }

        public void ShowData(int low)
        {
            if (SelectDataToShow.SelectedItem == null)
            {
                // Alert Message Box
                string message = "Data cannot be loaded if the category isn't specified";
                string title = "Alert Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                String cat = SelectDataToShow.SelectedItem.ToString();
                String cat1 = "";
                if (cat == "Cat 21")
                {
                    cat1 = "t_cat21";
                }
                else
                {
                    cat1 = "t_cat10";
                }
                //////////////////////////////////////////////
                DBHelper db = new DBHelper();
                myConnection = db.ConnectToMyDatabase();
                int high = low + 50;

                string command = command_generator(cat1, low, high);

                MySqlCommand cmd = new MySqlCommand(command, myConnection);

                try
                {
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                    myAdapter.SelectCommand = cmd;
                    DataTable data = new DataTable();
                    myAdapter.Fill(data);
                    BindingSource formulario = new BindingSource();
                    formulario.DataSource = data;
                    dataGrid_bbdd.DataSource = formulario;
                    myAdapter.Update(data);

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error" + ex.ToString());
                }
            }
        }

        public string command_generator(string cat1, int low, int high)
        {
            string command = "SELECT * FROM " + cat1;
            int count = 0;

            if (cat1 == "t_cat10")
            {
                if (checkBox_datefilter_cat10.Checked == true || checkBox_trackfilter_cat10.Checked == true || checkBox_targetid_cat10.Checked == true || checkBox_mode3A_cat10.Checked == true)
                    command = command + " WHERE";
                if (checkBox_datefilter_cat10.Checked == true)
                {
                    command = command + " Time_of_day BETWEEN STR_TO_DATE('" + dateTimePicker1_cat10.Text + "','%h:%i:%s') AND STR_TO_DATE('" + dateTimePicker2_cat10.Text + "','%h:%i:%s')";
                    count++;
                }

                if (checkBox_trackfilter_cat10.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Track_Number LIKE '%" + tracknumber_tb_cat10.Text + "%'";
                    count++;
                }

                if (checkBox_mode3A_cat10.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Mode_3A LIKE '%" + mode3A_tb_cat10.Text + "%'";
                    count++;
                }

                if (checkBox_targetid_cat10.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Target_ID LIKE '%" + targetid_tb_cat10.Text + "%'";
                    count++;
                }
            }
            else
            {
                if (checkBox_datefilter_cat21.Checked == true || checkBox_trackfilter_cat21.Checked == true || checkBox_targetid_cat21.Checked == true || checkBox_mode3A_cat21.Checked == true)
                    command = command + " WHERE";
                if (checkBox_datefilter_cat21.Checked == true)
                {
                    command = command + " Time_of_Report_Transmission BETWEEN STR_TO_DATE('" + dateTimePicker1_cat21.Text + "','%h:%i:%s') AND STR_TO_DATE('" + dateTimePicker2_cat21.Text + "','%h:%i:%s')";
                    count++;
                }

                if (checkBox_trackfilter_cat21.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Track_Number LIKE '%" + tracknumber_tb_cat21.Text + "%'";
                    count++;
                }

                if (checkBox_mode3A_cat21.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Mode_3A_Code LIKE '%" + mode3A_tb_cat21.Text + "%'";
                    count++;
                }

                if (checkBox_targetid_cat21.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Target_Identification LIKE '%" + targetid_tb_cat21.Text + "%'";
                    count++;
                }
            }

            /*if (checkBox_datefilter.Checked == true || checkBox_trackfilter.Checked == true)
                command = command + ";";
            else
                command = command + " LIMIT " + low + ", " + high + ";";*/

            command = command + " LIMIT " + low + ", " + high + ";";

            return command;
        }

        private void previous_btn_Click(object sender, EventArgs e)
        {
            int low = Convert.ToInt32(numericUpDown.Value);
            int new_low = low - 50;
            if (new_low >= 0)
            {
                numericUpDown.Value = Convert.ToDecimal(new_low);
                ShowData(new_low);
            }
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            int low = Convert.ToInt32(numericUpDown.Value);
            int new_low = low + 50;
            numericUpDown.Value = Convert.ToDecimal(new_low);
            ShowData(new_low);
        }

        private void SelectDataToShow_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (SelectDataToShow.SelectedItem.ToString() == "Cat 10")
            {
                //cat10
                tracknumber_tb_cat10.Visible = true;
                label6_cat10.Visible = true;
                label4_cat10.Visible = true;
                label7_cat10.Visible = true;
                dateTimePicker1_cat10.Visible = true;
                dateTimePicker2_cat10.Visible = true;
                checkBox_datefilter_cat10.Visible = true;
                checkBox_trackfilter_cat10.Visible = true;
                checkBox_targetid_cat10.Visible = true;
                targetid_tb_cat10.Visible = true;
                label8_cat10.Visible = true;
                mode3A_tb_cat10.Visible = true;
                checkBox_mode3A_cat10.Visible = true;

                //cat21
                label4_cat21.Visible = false;
                checkBox_datefilter_cat21.Visible = false;
                dateTimePicker1_cat21.Visible = false;
                dateTimePicker2_cat21.Visible = false;
                checkBox_trackfilter_cat21.Visible = false;
                checkBox_targetid_cat21.Visible = false;
                label5_cat21.Visible = false;
                label6_cat21.Visible = false;
                targetid_tb_cat21.Visible = false;
                tracknumber_tb_cat21.Visible = false;
                label8_cat21.Visible = false;
                mode3A_tb_cat21.Visible = false;
                checkBox_mode3A_cat21.Visible = false;
            }
            else
            {
                //cat10
                tracknumber_tb_cat10.Visible = false;
                label6_cat10.Visible = false;
                label4_cat10.Visible = false;
                dateTimePicker1_cat10.Visible = false;
                dateTimePicker2_cat10.Visible = false;
                checkBox_datefilter_cat10.Visible = false;
                checkBox_trackfilter_cat10.Visible = false;
                label7_cat10.Visible = false;
                checkBox_targetid_cat10.Visible = false;
                targetid_tb_cat10.Visible = false;
                label8_cat10.Visible = false;
                mode3A_tb_cat10.Visible = false;
                checkBox_mode3A_cat10.Visible = false;

                //cat21
                label4_cat21.Visible = true;
                checkBox_datefilter_cat21.Visible = true;
                dateTimePicker1_cat21.Visible = true;
                dateTimePicker2_cat21.Visible = true;
                checkBox_trackfilter_cat21.Visible = true;
                checkBox_targetid_cat21.Visible = true;
                label5_cat21.Visible = true;
                label6_cat21.Visible = true;
                targetid_tb_cat21.Visible = true;
                tracknumber_tb_cat21.Visible = true;
                label8_cat21.Visible = true;
                mode3A_tb_cat21.Visible = true;
                checkBox_mode3A_cat21.Visible = true;
            }
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {
            Map f_m = new Map();
            this.Hide();
            f_m.ShowDialog();
            this.Close();
        }


        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            if (f_lf == null)
            {
                f_lf = new LoadFile();
                this.Hide();
                f_lf.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                f_lf.Show();
                this.Close();
            }
        }

        public void setLoadFile(LoadFile loadfile)
        {
            f_lf = loadfile;
        }

        /*private void dataGrid_bbdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridCellInfo selcell = dataGrid_bbdd.CurrentCell;
                int columnindex = selcell.Column.DisplayIndex;
                int rowIndex = dataGrid_bbdd.Items.IndexOf(selcell.Item);
                SelectedNumber.Text = Convert.ToString((dataGrid_bbdd.Items[rowIndex] as DataRowView).Row.ItemArray[0]);
                SelectedID.Text = Convert.ToString((dataGrid_bbdd.Items[rowIndex] as DataRowView).Row.ItemArray[4]);

                if (cell == true) //If there was an extended cell, changes it value to "Click to expand", and contracts it
                {
                    cell = false;
                    DataRowView rowView0 = (dataGrid_bbdd.Items[Datarow] as DataRowView);
                    rowView0.BeginEdit();
                    rowView0[Datacol] = "Click to expand";
                    rowView0.EndEdit();
                    dataGrid_bbdd.Columns[Datacol].Width = Columnwith;
                }
                if (Convert.ToString((dataGrid_bbdd.Items[rowIndex] as DataRowView).Row.ItemArray[columnindex]) == "Click to expand") //If selected cell value is "Click to expand" change it's value with all the data of that parameter, and expands the cell
                {
                    Datacol = columnindex;
                    Datarow = rowIndex;
                    Columnwith = dataGrid_bbdd.Columns[Datacol].Width.DisplayValue;
                    string value = this.GetValues(columnindex, rowIndex); //Get all parameters value
                    DataRowView rowView = (dataGrid_bbdd.Items[Datarow] as DataRowView);
                    rowView.BeginEdit();
                    rowView[Datacol] = value;
                    rowView.EndEdit();
                    cell = true;
                }

                dataGrid_bbdd.Columns[columnindex].Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto); //Resizes column to fit new content
                dataGrid_bbdd.UpdateLayout();
            }
            catch { }
        }*/

        private void SQLToCSV(string query, string Filename)
        {

            DBHelper db = new DBHelper();
            myConnection = db.ConnectToMyDatabase();
            MySqlCommand cmd = new MySqlCommand(query, myConnection);
            MySqlDataReader dr = cmd.ExecuteReader();

            using (System.IO.StreamWriter fs = new System.IO.StreamWriter(Filename))
            {
                // Loop through the fields and add headers
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    string name = dr.GetName(i);
                    if (name.Contains(","))
                        name = "\"" + name + "\"";

                    fs.Write(name + ",");
                }
                fs.WriteLine();

                // Loop through the rows and output the data
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(","))
                            value = "\"" + value + "\"";

                        fs.Write(value + ",");
                    }
                    fs.WriteLine();
                }

                fs.Close();
            }
        }

        public string command_generator_csv(string cat1)
        {
            string command = "SELECT * FROM " + cat1;
            int count = 0;

            if (cat1 == "t_cat10")
            {
                if (checkBox_datefilter_cat10.Checked == true || checkBox_trackfilter_cat10.Checked == true || checkBox_targetid_cat10.Checked == true || checkBox_mode3A_cat10.Checked == true)
                    command = command + " WHERE";
                if (checkBox_datefilter_cat10.Checked == true)
                {
                    command = command + " Time_of_day BETWEEN STR_TO_DATE('" + dateTimePicker1_cat10.Text + "','%h:%i:%s') AND STR_TO_DATE('" + dateTimePicker2_cat10.Text + "','%h:%i:%s')";
                    count++;
                }

                if (checkBox_trackfilter_cat10.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Track_Number LIKE '%" + tracknumber_tb_cat10.Text + "%'";
                    count++;
                }

                if (checkBox_mode3A_cat10.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Mode_3A LIKE '%" + mode3A_tb_cat10.Text + "%'";
                    count++;
                }

                if (checkBox_targetid_cat10.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Target_ID LIKE '%" + targetid_tb_cat10.Text + "%'";
                    count++;
                }
            }
            else
            {
                if (checkBox_datefilter_cat21.Checked == true || checkBox_trackfilter_cat21.Checked == true || checkBox_targetid_cat21.Checked == true || checkBox_mode3A_cat21.Checked == true)
                    command = command + " WHERE";
                if (checkBox_datefilter_cat21.Checked == true)
                {
                    command = command + " Time_of_Report_Transmission BETWEEN STR_TO_DATE('" + dateTimePicker1_cat21.Text + "','%h:%i:%s') AND STR_TO_DATE('" + dateTimePicker2_cat21.Text + "','%h:%i:%s')";
                    count++;
                }

                if (checkBox_trackfilter_cat21.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Track_Number LIKE '%" + tracknumber_tb_cat21.Text + "%'";
                    count++;
                }

                if (checkBox_mode3A_cat21.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Mode_3A_Code LIKE '%" + mode3A_tb_cat21.Text + "%'";
                    count++;
                }

                if (checkBox_targetid_cat21.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Target_Identification LIKE '%" + targetid_tb_cat21.Text + "%'";
                    count++;
                }
            }

            command = command + ";";

            return command;
        }

        private void Excel_button_Click_1(object sender, EventArgs e)
        {
            String cat = SelectDataToShow.SelectedItem.ToString();
            String cat1 = "";
            if (cat == "Cat 21")
            {
                cat1 = "t_cat21";
            }
            else
            {
                cat1 = "t_cat10";
            }

            //////////////////////////////////////////////

            string command = command_generator_csv(cat1);

            //Agafo el path del fitxer
            /*
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.Filter = "csv files (*.csv*)|*.csv*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.path = saveFileDialog1.FileName;
            }
            */

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();
            saveFileDialog1.Filter = "csv files (*.csv*)|*.csv*";
            string path0 = saveFileDialog1.FileName;
            string path = path0 + ".csv";

            SQLToCSV(command, path);
        }

        private void SQLToCSV2(string query, string Filename, string cat1)
        {

            string command = "SELECT * UNION * FROM " + cat1;
            int count = 0;

            if (cat1 == "t_cat10")
            {
                if (checkBox_datefilter_cat10.Checked == true || checkBox_trackfilter_cat10.Checked == true || checkBox_targetid_cat10.Checked == true || checkBox_mode3A_cat10.Checked == true)
                    command = command + " WHERE";
                if (checkBox_datefilter_cat10.Checked == true)
                {
                    command = command + " Time_of_day BETWEEN STR_TO_DATE('" + dateTimePicker1_cat10.Text + "','%h:%i:%s') AND STR_TO_DATE('" + dateTimePicker2_cat10.Text + "','%h:%i:%s')";
                    count++;
                }

                if (checkBox_trackfilter_cat10.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Track_Number LIKE '%" + tracknumber_tb_cat10.Text + "%'";
                    count++;
                }

                if (checkBox_mode3A_cat10.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Mode_3A LIKE '%" + mode3A_tb_cat10.Text + "%'";
                    count++;
                }

                if (checkBox_targetid_cat10.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Target_ID LIKE '%" + targetid_tb_cat10.Text + "%'";
                    count++;
                }
            }
            else
            {
                if (checkBox_datefilter_cat21.Checked == true || checkBox_trackfilter_cat21.Checked == true || checkBox_targetid_cat21.Checked == true || checkBox_mode3A_cat21.Checked == true)
                    command = command + " WHERE";
                if (checkBox_datefilter_cat21.Checked == true)
                {
                    command = command + " Time_of_Report_Transmission BETWEEN STR_TO_DATE('" + dateTimePicker1_cat21.Text + "','%h:%i:%s') AND STR_TO_DATE('" + dateTimePicker2_cat21.Text + "','%h:%i:%s')";
                    count++;
                }

                if (checkBox_trackfilter_cat21.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Track_Number LIKE '%" + tracknumber_tb_cat21.Text + "%'";
                    count++;
                }

                if (checkBox_mode3A_cat21.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Mode_3A_Code LIKE '%" + mode3A_tb_cat21.Text + "%'";
                    count++;
                }

                if (checkBox_targetid_cat21.Checked == true)
                {
                    if (count > 0)
                        command = command + " AND ";
                    command = command + " Target_Identification LIKE '%" + targetid_tb_cat21.Text + "%'";
                    count++;
                }
            }
            //command = "INRO OUTFILE '" + path + "' FIELDS ENCLOSED BY '"' TERMINATED BY '+" ESCAPED BY '"' LINES TERMINATED BY '\r\n');";
            command = command + ";";

            DBHelper db = new DBHelper();
            myConnection = db.ConnectToMyDatabase();
            MySqlCommand cmd = new MySqlCommand(query, myConnection);

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

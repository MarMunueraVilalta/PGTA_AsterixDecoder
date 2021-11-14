using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using ClassLibrary;

namespace ClassLibrary
{
    public class MapUtils
    {
        public DataTable SMR = new DataTable();
        public DataTable MLAT = new DataTable();
        public DataTable ADS_B = new DataTable();
        MySqlConnection myConnection;

        public void LoadDataSMR(String time_from, String time_to)
        {
            string command = "";
            command = "SELECT Time_of_day,Position_in_Polar_Coordinates,Position_in_Cartesian_Coordinates,Track_Velocity_in_Polar_Coordinates,Track_Velocity_in_Cartesian_Coordinates,Track_Number,Target_ID FROM t_cat10 WHERE SIC = '7'";
            command = command + " AND Message_Type = 'Target Report' AND Time_of_day BETWEEN STR_TO_DATE('" + time_from + "','%h:%i:%s') AND STR_TO_DATE('" + time_to + "','%h:%i:%s') AND Position_in_Cartesian_Coordinates != 'No data';";

            DBHelper db = new DBHelper();
            myConnection = db.ConnectToMyDatabase();

            MySqlCommand cmd = new MySqlCommand(command, myConnection);

            try
            {
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                myAdapter.SelectCommand = cmd;
                myAdapter.Fill(SMR);
                myAdapter.Update(SMR);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }
        }

        public void LoadDataMLAT(String time_from, String time_to)
        {
            string command = "";
            command = "SELECT Time_of_day,Position_in_Polar_Coordinates,Position_in_Cartesian_Coordinates,Track_Velocity_in_Polar_Coordinates,Track_Velocity_in_Cartesian_Coordinates,Track_Number,Target_ID FROM t_cat10 WHERE SIC = '107'";
            command = command + " AND Message_Type = 'Target Report' AND Time_of_day BETWEEN STR_TO_DATE('" + time_from + "','%h:%i:%s') AND STR_TO_DATE('" + time_to + "','%h:%i:%s');";

            DBHelper db = new DBHelper();
            myConnection = db.ConnectToMyDatabase();

            MySqlCommand cmd = new MySqlCommand(command, myConnection);

            try
            {
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                myAdapter.SelectCommand = cmd;
                myAdapter.Fill(MLAT);
                myAdapter.Update(MLAT);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }
        }

        public void LoadDataADS_B(String time_from, String time_to)
        {
            string command = "";
            command = "SELECT Time_of_Report_Transmission,Position_in_WGS84_Coordinates,Flight_Level,Mode_3A_Code,Track_Number,Target_Identification FROM t_cat21 WHERE";
            command = command + " Time_of_Report_Transmission BETWEEN STR_TO_DATE('" + time_from + "','%h:%i:%s') AND STR_TO_DATE('" + time_to + "','%h:%i:%s') AND Position_in_WGS84_Coordinates != 'No data';";

            DBHelper db = new DBHelper();
            myConnection = db.ConnectToMyDatabase();

            MySqlCommand cmd = new MySqlCommand(command, myConnection);

            try
            {
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                myAdapter.SelectCommand = cmd;
                myAdapter.Fill(ADS_B);
                myAdapter.Update(ADS_B);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }
        }

        public double[] getPositionADS_B(int i)
        {
            //La posició està a la columna 2
            string coordinates = ADS_B.Rows[i]["Position_in_WGS84_Coordinates"].ToString();
            string[] latlon = coordinates.Split(';');

            double degrees_lat = Convert.ToDouble(latlon[0].Split('d')[0]);
            double min_lat = Convert.ToDouble(latlon[0].Split('d')[1].Split('m')[0]) / 60;
            double sec_lat = Convert.ToDouble(latlon[0].Split('d')[1].Split('m')[1].Split('s')[0])/3600;

            double degrees_lng = Convert.ToDouble(latlon[1].Split('d')[0]);
            double min_lng = Convert.ToDouble(latlon[1].Split('d')[1].Split('m')[0]) / 60;
            double sec_lng = Convert.ToDouble(latlon[1].Split('d')[1].Split('m')[1].Split('s')[0])/3600;

            double[] mylatlng = {degrees_lat+min_lat+sec_lat,degrees_lng+min_lng+sec_lng};
            return mylatlng;
        }

        public int[] getPositionSMR_cartesian(int i)
        {
            //La posició està a la columna 2
            string coordinates = SMR.Rows[i]["Position_in_Cartesian_Coordinates"].ToString();
            string[] xy = coordinates.Split('m');

            int x = Convert.ToInt32(xy[0].Split(':')[1]);
            int y = Convert.ToInt32(xy[1].Split(':')[1]);

            int[] myxy = { x, y};
            return myxy;
        }
    }
}

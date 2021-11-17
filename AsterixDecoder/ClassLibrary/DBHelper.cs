using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public class DBHelper
    {
        public MySqlConnection ConnectToMyDatabase()
        {
            String servidor = "127.0.0.1";
            String puerto = "3306";
            String usuario = "root";
            String password = "mar88";
            //String password = "mysql";
            String database = "bbdd_asterix";

            string cadenadeconexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + database + "; Allow user Variables =true;";
            MySqlConnection myConnection = new MySqlConnection(cadenadeconexion);
            try
            {
                myConnection.Open();
                return myConnection;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
                return myConnection;
            }
        }

        public void showInfoInTable(string myTable, MySqlConnection myConnection)
        {
            string datos = "";
            try
            {
                MySqlDataReader dataReader = null;

                //MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", myConnection);
                //MySqlCommand cmd = new MySqlCommand("SHOW TABLES;", myConnection);

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + myTable + ";", myConnection);

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    datos += Convert.ToString(dataReader.GetString(0)) + "\n";
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }

            Console.WriteLine(datos);
        }


        public void fillTableCat21(int num, CAT21 myClass, MySqlConnection myConnection)
        {

            try
            {
                MySqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO t_cat21 (Message_ID, SAC , SIC , Target_Report_Descriptor, Track_Number,Service_Identification,Time_Applicability_Position, Position_in_WGS84_Coordinates, Position_in_WGS84_Coordinates_High_Resolution, Time_Applicability_Velocity, Air_Speed,True_Airspeed, Target_Address, Time_of_Message_Reception_of_Position, Time_of_Message_Reception_of_Possition_High_Precision, Time_of_Message_Reception_of_Velocity, Time_of_Message_Reception_of_Velocity_High_Precision, Geometric_Height, Quality_Indicators, MOPS_Version, Mode_3A_Code, Roll_Angle, Flight_Level, Magnetic_Heading, Barometric_Vertical_Rate, Geometric_Vertical_Rate, Airbone_Ground_Vector, Track_Angle_Rate, Time_of_Report_Transmission, Target_Identification, Emitter_Category, Met_Information, Selected_Altitude, Final_Selected_Altitude, Trajectory_Intent, Service_Management, Aircraft_Operational_Status, Surface_Capabilities_and_Characteristics, Message_Amplitude, Mode_SMB_Data, ACAS_Resolution_Advisory_Report, Receiver_ID, Data_Ages, Reserved_Expansion_Field, Special_Purpose_Field) VALUES (@Message_ID, @SAC , @SIC , @Target_Report_Descriptor, @Track_Number, @Service_Identification, @Time_Applicability_Position, @Position_in_WGS84_Coordinates, @Position_in_WGS84_Coordinates_High_Resolution, @Time_Applicability_Velocity, @Air_Speed, @True_Airspeed, @Target_Address, @Time_of_Message_Reception_of_Position, @Time_of_Message_Reception_of_Possition_High_Precision, @Time_of_Message_Reception_of_Velocity, @Time_of_Message_Reception_of_Velocity_High_Precision, @Geometric_Height, @Quality_Indicators, @MOPS_Version, @Mode_3A_Code, @Roll_Angle, @Flight_Level, @Magnetic_Heading, @Barometric_Vertical_Rate, @Geometric_Vertical_Rate, @Airbone_Ground_Vector, @Track_Angle_Rate, @Time_of_Report_Transmission, @Target_Identification, @Emitter_Category, @Met_Information, @Selected_Altitude, @Final_Selected_Altitude, @Trajectory_Intent, @Service_Management, @Aircraft_Operational_Status, @Surface_Capabilities_and_Characteristics, @Message_Amplitude, @Mode_SMB_Data, @ACAS_Resolution_Advisory_Report, @Receiver_ID, @Data_Ages, @Reserved_Expansion_Field, @Special_Purpose_Field);";
                cmd.Parameters.AddWithValue("@Message_ID", num);
                cmd.Parameters.AddWithValue("@SIC", myClass.SIC);
                cmd.Parameters.AddWithValue("@SAC", myClass.SAC);
                cmd.Parameters.AddWithValue("@Target_Report_Descriptor", myClass.target_report_descriptor);
                cmd.Parameters.AddWithValue("@Track_Number", myClass.track_number);
                cmd.Parameters.AddWithValue("@Service_Identification", myClass.service_identification);
                cmd.Parameters.AddWithValue("@Time_Applicability_Position", myClass.time_applicability_position);
                cmd.Parameters.AddWithValue("@Position_in_WGS84_Coordinates", myClass.position_WGS84);
                cmd.Parameters.AddWithValue("@Position_in_WGS84_Coordinates_High_Resolution", myClass.position_WGS84_high_res);
                cmd.Parameters.AddWithValue("@Time_Applicability_Velocity", myClass.time_applicability_velocity);
                cmd.Parameters.AddWithValue("@Air_Speed", myClass.air_speed);
                cmd.Parameters.AddWithValue("@True_Airspeed", myClass.true_air_speed);
                cmd.Parameters.AddWithValue("@Target_Address", myClass.target_address);
                cmd.Parameters.AddWithValue("@Time_of_Message_Reception_of_Position", myClass.time_message_reception_position);
                cmd.Parameters.AddWithValue("@Time_of_Message_Reception_of_Possition_High_Precision", myClass.time_message_reception_position_high);
                cmd.Parameters.AddWithValue("@Time_of_Message_Reception_of_Velocity", myClass.time_message_reception_velocity);
                cmd.Parameters.AddWithValue("@Time_of_Message_Reception_of_Velocity_High_Precision", myClass.time_message_reception_velocity_high_precision);
                cmd.Parameters.AddWithValue("@Geometric_Height", myClass.geometric_height);
                cmd.Parameters.AddWithValue("@Quality_Indicators", myClass.quality_indicators);
                cmd.Parameters.AddWithValue("@MOPS_Version", myClass.MOPS_version);
                cmd.Parameters.AddWithValue("@Mode_3A_Code", myClass.mode3A);
                cmd.Parameters.AddWithValue("@Roll_Angle", myClass.roll_angle);
                cmd.Parameters.AddWithValue("@Flight_Level", myClass.flight_level);
                cmd.Parameters.AddWithValue("@Magnetic_Heading", myClass.magnetic_heading);
                cmd.Parameters.AddWithValue("@Barometric_Vertical_Rate", myClass.barometric_vertical_rate);
                cmd.Parameters.AddWithValue("@Geometric_Vertical_Rate", myClass.geometric_vertical_rate);
                cmd.Parameters.AddWithValue("@Airbone_Ground_Vector", myClass.airbone_ground_vector);
                cmd.Parameters.AddWithValue("@Track_Angle_Rate", myClass.track_angle_rate);
                cmd.Parameters.AddWithValue("@Time_of_Report_Transmission", myClass.time_report_transmission);
                cmd.Parameters.AddWithValue("@Target_Identification", myClass.target_id);
                cmd.Parameters.AddWithValue("@Emitter_Category", myClass.emitter_category);
                cmd.Parameters.AddWithValue("@Met_Information", myClass.met_information);
                cmd.Parameters.AddWithValue("@Selected_Altitude", myClass.selected_altitude);
                cmd.Parameters.AddWithValue("@Final_Selected_Altitude", myClass.final_state_selected_altitude);
                cmd.Parameters.AddWithValue("@Trajectory_Intent", myClass.trajectory_intend);
                cmd.Parameters.AddWithValue("@Service_Management", myClass.service_management);
                cmd.Parameters.AddWithValue("@Aircraft_Operational_Status", myClass.aircraft_operational_status);
                cmd.Parameters.AddWithValue("@Surface_Capabilities_and_Characteristics", myClass.surface_capabilities_characteristics);
                cmd.Parameters.AddWithValue("@Message_Amplitude", myClass.message_amplitude);
                cmd.Parameters.AddWithValue("@Mode_SMB_Data", myClass.mode_s);
                cmd.Parameters.AddWithValue("@ACAS_Resolution_Advisory_Report", myClass.ACAS_resolution_advisory_report);
                cmd.Parameters.AddWithValue("@Receiver_ID", myClass.receiver_id);
                cmd.Parameters.AddWithValue("@Data_Ages", myClass.data_ages);
                cmd.Parameters.AddWithValue("@Reserved_Expansion_Field", myClass.reserved_expansion_field);
                cmd.Parameters.AddWithValue("@Special_Purpose_Field", myClass.special_purpose_field);

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }

        }


        // ABANS DE CRIDAR LES FUNCIONS DE FILL S'HAURA DE FER UN DELETE DE LA INFO DE LA TAULA!

        public void fillTableCat10(int num, CAT10 myClass, MySqlConnection myConnection)
        {
            try
            {
                MySqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO t_cat10 VALUES (@Message_ID, @SAC, @SIC, @Message_Type, @Target_Report_Descriptor, @Time_of_day, @Position_in_WGS84_Coordinates,@Position_in_Polar_Coordinates, @Position_in_Cartesian_Coordinates,@Track_Velocity_in_Polar_Coordinates, @Track_Velocity_in_Cartesian_Coordinates, @Track_Number, @Track_Status, @Mode_3A, @Target_Address, @Target_ID, @Mode_S, @Vehicle_Fleet_ID, @Flight_Level, @Height, @Size_and_Orientation, @System_Status, @Preprogrammed_Message, @Standard_Deviation_Position, @Presence, @Amplitude_of_Primary_Plot, @Acceleration, @Special_Purpose_Field, @Reserved_Expansion);";

                cmd.Parameters.AddWithValue("@Message_ID", num);
                cmd.Parameters.AddWithValue("@SIC", myClass.SIC);
                cmd.Parameters.AddWithValue("@SAC", myClass.SAC);
                cmd.Parameters.AddWithValue("@Message_Type", myClass.message_type);
                cmd.Parameters.AddWithValue("@Target_Report_Descriptor", myClass.target_report_descriptor);
                cmd.Parameters.AddWithValue("@Time_of_day", myClass.time_day);
                cmd.Parameters.AddWithValue("@Position_in_WGS84_Coordinates", myClass.position_WGS84);
                cmd.Parameters.AddWithValue("@Position_in_Polar_Coordinates", myClass.position_polar);
                cmd.Parameters.AddWithValue("@Position_in_Cartesian_Coordinates", myClass.position_cartesian);
                cmd.Parameters.AddWithValue("@Track_Velocity_in_Polar_Coordinates", myClass.track_velocity_polar);
                cmd.Parameters.AddWithValue("@Track_Velocity_in_Cartesian_Coordinates", myClass.track_velocity_cartesian);
                cmd.Parameters.AddWithValue("@Track_Number", myClass.track_number);
                cmd.Parameters.AddWithValue("@Track_Status", myClass.track_status);
                cmd.Parameters.AddWithValue("@Mode_3A", myClass.mode3A);
                cmd.Parameters.AddWithValue("@Target_Address", myClass.target_address);
                cmd.Parameters.AddWithValue("@Target_ID", myClass.target_id);
                cmd.Parameters.AddWithValue("@Mode_S", myClass.modeS);
                cmd.Parameters.AddWithValue("@Vehicle_Fleet_ID", myClass.vehicle_fleet_id);
                cmd.Parameters.AddWithValue("@Flight_Level", myClass.flight_level);
                cmd.Parameters.AddWithValue("@Height", myClass.height);
                cmd.Parameters.AddWithValue("@Size_and_Orientation", myClass.size_orientation);
                cmd.Parameters.AddWithValue("@System_Status", myClass.system_status);
                cmd.Parameters.AddWithValue("@Preprogrammed_Message", myClass.preprogrammed_msg);
                cmd.Parameters.AddWithValue("@Standard_Deviation_Position", myClass.std_deviation_position);
                cmd.Parameters.AddWithValue("@Presence", myClass.presence);
                cmd.Parameters.AddWithValue("@Amplitude_of_Primary_Plot", myClass.amplitude_of_primary_plot);
                cmd.Parameters.AddWithValue("@Acceleration", myClass.acceleration);
                cmd.Parameters.AddWithValue("@Special_Purpose_Field", myClass.special_purpose);
                cmd.Parameters.AddWithValue("@Reserved_Expansion", myClass.reserved_expansion);


                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }

        }

        public void emptyTable(string myTable, MySqlConnection myConnection)
        {
            string missatge = "TRUNCATE TABLE " + myTable + ";";
            try
            {
                MySqlCommand cmd = new MySqlCommand(missatge, myConnection);
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }

        }

        public void closeDatabase(MySqlConnection myConnection)
        {
            try
            {
                myConnection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }

        }


        public void ShowInfoDatabase(MySqlConnection myConnection)
        {
            string datos = "";
            try
            {
                MySqlDataReader dataReader = null;

                MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", myConnection);

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    datos += dataReader.GetString(0) + "\n";
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }
            Console.WriteLine(datos);
        }
        /*
        public void ShowInfoTable(MySqlConnection myConnection, string cat)
        {
            string datos = "";
            try
            {
                MySqlDataReader dataReader = null;

                if (cat == )
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_cat21;", myConnection);
                else
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_cat21;", myConnection);

                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    datos += dataReader.GetString(0) + "\n";
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }
            Console.WriteLine(datos);
        }
        */

    }
}

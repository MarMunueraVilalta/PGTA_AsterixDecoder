using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT10
    {
        public string SAC;
        public string SIC;
        public string message_type;
        public string target_report_descriptor;
        public string time_day;
        public string position_WGS84;
        public string position_polar;
        public string position_cartesian;
        public string track_velocity_polar;
        public string track_velocity_cartesian;
        public string track_number;
        public string track_status;
        public string mode3A;
        public string target_address;
        public string target_id;
        public string modeS;
        public string vehicle_fleet_id;
        public string flight_level;
        public string height;
        public string size_orientation;
        public string system_status;
        public string preprogrammed_msg;
        public string std_deviation_position;
        public string presence;
        public string amplitude_of_primary_plot;
        public string acceleration;
        public string special_purpose;
        public string reserved_expansion;

        int[] data_item_length_vector = { 2, 1, -1, };
        string[] record_field_vector;
        string[] data_item_names_vector = { "data_source_id", "message_type", "target_report_descriptor", "time_day", "position_WGS84", "position_polar", "position_cartesian", "", "track_velocity_polar", "track_velocity_cartesian", "track_number", "track_status", "mode3A", "target_address", "target_id", "", "modeS", "vehicle_fleet_id", "flight_level", "height", "size_orientation", "system_status", "preprogrammed_msg", "", "std_deviation_position", "presence", "amplitude_of_primary_plot", "acceleration", "", "special_purpose", "reserved_expansion", "" };
        public CAT10()
        {
            this.SAC = "No data";
            this.SIC = "No data";
            this.message_type = "No data";
            this.target_report_descriptor = "No data";
            this.time_day = "No data";
            this.position_WGS84 = "No data";
            this.position_polar = "No data";
            this.position_cartesian = "No data";
            this.track_velocity_polar = "No data";
            this.track_velocity_cartesian = "No data";
            this.track_number = "No data";
            this.track_status = "No data";
            this.mode3A = "No data";
            this.target_address = "No data";
            this.target_id = "No data";
            this.modeS = "No data";
            this.vehicle_fleet_id = "No data";
            this.flight_level = "No data";
            this.height = "No data";
            this.size_orientation = "No data";
            this.system_status = "No data";
            this.preprogrammed_msg = "No data";
            this.std_deviation_position = "No data";
            this.presence = "No data";
            this.amplitude_of_primary_plot = "No data";
            this.acceleration = "No data";
            this.special_purpose = "No data";
            this.reserved_expansion = "No data";
        }

        static void CreateCAT10(string SAC, string SIC, string message_type, string target_report_descriptor, string time_day, string position_WGS84, string position_polar, string position_cartesian, string track_velocity_polar, string track_velocity_cartesian, string track_number, string track_status, string mode3A, string target_address, string target_id, string modeS, string vehicle_fleet_id, string flight_level, string height, string size_orientation, string system_status, string preprogrammed_msg, string std_deviation_position, string presence, string amplitude_of_primary_plot, string acceleration, string special_purpose, string reserved_expansion)
        {
            CAT10 myCAT10 = new CAT10();
        }


        public void Record_field(string[] missatge)
        {

            string field_specification = "";
            int next_octet = 4;

            if (missatge[3].Substring(7, 1) == "1")
            {
                next_octet++;
                if (missatge[4].Substring(7, 1) == "1")
                {

                    next_octet++;
                    if (missatge[5].Substring(7, 1) == "1")
                    {
                        next_octet++;
                    }
                }
            }

            string rf = missatge[3].Substring(0, 1);
            if (rf == "1") { next_octet = Find_Data_Source_Identifier(missatge, next_octet); }

            rf = missatge[3].Substring(1, 1);
            if (rf == "1") { next_octet = Find_Message_Type(missatge, next_octet); }

            rf = missatge[3].Substring(2, 1);
            if (rf == "1") { next_octet = Find_Target_Report_Descriptor(missatge, next_octet); }

            rf = missatge[3].Substring(3, 1);
            if (rf == "1") { next_octet = Find_Time_Of_Day(missatge, next_octet); }

            rf = missatge[3].Substring(4, 1);
            if (rf == "1") { next_octet = Find_Position_WGS84(missatge, next_octet); }

            rf = missatge[3].Substring(5, 1);
            if (rf == "1") { next_octet = Find_Position_Polar(missatge, next_octet); }

            rf = missatge[3].Substring(6, 1);
            if (rf == "1") { next_octet = Find_Position_Cartesian(missatge, next_octet); }

            rf = missatge[3].Substring(7, 1);
            if (rf == "1")
            {

                rf = missatge[4].Substring(0, 1);
                if (rf == "1") { next_octet = Find_Track_Velocity_Polar(missatge, next_octet); }

                rf = missatge[4].Substring(1, 1);
                if (rf == "1") { next_octet = Find_Calculated_Track_Velocity_Cartesian(missatge, next_octet); }

                rf = missatge[4].Substring(2, 1);
                if (rf == "1") { next_octet = Find_Track_Number(missatge, next_octet); }

                rf = missatge[4].Substring(3, 1);
                if (rf == "1") { next_octet = Find_Track_Status(missatge, next_octet); }

                rf = missatge[4].Substring(4, 1);
                if (rf == "1") { next_octet = Find_Mode_3A(missatge, next_octet); }

                rf = missatge[4].Substring(5, 1);
                if (rf == "1") { next_octet = Find_Target_Address(missatge, next_octet); }

                rf = missatge[4].Substring(6, 1);
                if (rf == "1") { next_octet = Find_Target_Id(missatge, next_octet); }

                rf = missatge[4].Substring(7, 1);
                if (rf == "1")
                {
                    rf = missatge[5].Substring(0, 1);
                    if (rf == "1") { next_octet = Find_ModeS(missatge, next_octet); }

                    rf = missatge[5].Substring(1, 1);
                    if (rf == "1") { next_octet = Find_Vehicle_Fleet_Id(missatge, next_octet); }

                    rf = missatge[5].Substring(2, 1);
                    if (rf == "1") { next_octet = Find_Flight_Level_Binary(missatge, next_octet); }

                    rf = missatge[5].Substring(3, 1);
                    if (rf == "1") { next_octet = Find_Height(missatge, next_octet); }

                    rf = missatge[5].Substring(4, 1);
                    if (rf == "1") { next_octet = Find_Target_Size_Orientation(missatge, next_octet); }

                    rf = missatge[5].Substring(5, 1);
                    if (rf == "1") { next_octet = Find_System_Status(missatge, next_octet); }

                    rf = missatge[5].Substring(6, 1);
                    if (rf == "1") { next_octet = Find_Preprogrammed_Message(missatge, next_octet); }

                    rf = missatge[5].Substring(7, 1);
                    if (rf == "1")
                    {
                        rf = missatge[6].Substring(0, 1);
                        if (rf == "1") { next_octet = Find_Std_Deviation_Position(missatge, next_octet); }

                        rf = missatge[6].Substring(1, 1);
                        if (rf == "1") { next_octet = Find_Presence(missatge, next_octet); }

                        rf = missatge[6].Substring(2, 1);
                        if (rf == "1") { next_octet = Find_Amplitude_Of_Primary_Plot(missatge, next_octet); }

                        rf = missatge[6].Substring(3, 1);
                        if (rf == "1") { next_octet = Find_Calculated_Acceleration(missatge, next_octet); }
                    }
                }
            }
        }

        //FRN 1
        public int Find_Data_Source_Identifier(string[] missatge, int octet)
        {
            //Length in octets: FIXED 2

            //Console.WriteLine("octetos");
            //Console.WriteLine(missatge[octet]);
            //Console.WriteLine(missatge[octet+1]);
            //sic = missatge[octet + 1];

            SAC = missatge[octet];
            SIC = missatge[octet + 1];

            int sac_num = Convert.ToInt32(SAC, 2);
            int sic_num = Convert.ToInt32(SIC, 2);

            //Console.WriteLine(sac_num);
            //Console.WriteLine(sic_num);

            SIC = Convert.ToString(sic_num);
            SAC = Convert.ToString(sac_num);

            int next_octet = octet + 2;
            return next_octet;
        }
        //FRN 2
        public int Find_Message_Type(string[] missatge, int octet)
        {
            string buffer;
            buffer = missatge[octet];
            int m_type = Convert.ToInt32(buffer.Substring(5, 3), 2);

            switch (m_type)
            {
                case 1:
                    message_type = "Target Report";
                    break;
                case 2:
                    message_type = "Start of Update Cycle";
                    break;
                case 3:
                    message_type = "Periodic Status Message";
                    break;
                case 4:
                    message_type = "Event-triggered Status Message";
                    break;
                default:
                    message_type = "Target Report";
                    break;
            }
            return octet + 1;
        }

        //FRN 3
        string TYP; string DCR; string CHN; string GBS; string CRT; string SIM; string TST; string RAB; string LOP; string TOT; string SPI;
        public int Find_Target_Report_Descriptor(string[] missatge, int octet)
        {
            //Length in octets: VARIABLE
            string myMissatge = missatge[octet];

            string typ = myMissatge.Substring(0, 3);
            if (typ == "000") { TYP = "SSR multilateration"; }
            else if (typ == "001") { TYP = "Mode S multilateration"; }
            else if (typ == "010") { TYP = "ADS-B"; }
            else if (typ == "011") { TYP = "PSR"; }
            else if (typ == "100") { TYP = "Magnetic Loop System"; }
            else if (typ == "101") { TYP = "HF multilateration"; }
            else if (typ == "110") { TYP = "Not defined"; }
            else if (typ == "111") { TYP = "Other types"; }

            string dcr = myMissatge.Substring(3, 1);
            if (dcr == "0") { DCR = "No differential correction (ADS-B)"; }
            else if (DCR == "1") { DCR = "Differential correction (ADS-B)"; }

            string chn = myMissatge.Substring(4, 1);
            if (chn == "0") { CHN = "Chain 1"; }
            else if (chn == "1") { CHN = "Chain 2"; }

            string gbs = myMissatge.Substring(5, 1);
            if (gbs == "0") { GBS = "Transponder Ground bit not set"; }
            else if (gbs == "1") { GBS = "Transponder Ground bit set"; }

            string crt = myMissatge.Substring(6, 1);
            if (crt == "0") { CRT = "No Corrupted reply in multilateration"; }
            else if (crt == "1") { CRT = "Corrupted replies in multilateration"; }

            int next_octet = octet + 1;
            target_report_descriptor = "TYP: " + TYP + "; DCR:" + DCR + "; CHN:" + CHN + "; GBS: " + GBS + "; CRT:" + CRT;

            string fx = myMissatge.Substring(7, 1);
            if (fx == "1")
            {
                string myMissatge2 = missatge[octet + 1];

                string sim = myMissatge2.Substring(0, 1);
                if (sim == "0") { SIM = "Actual target report"; }
                else if (sim == "1") { SIM = "Simulated target report"; }

                string tst = myMissatge2.Substring(1, 1);
                if (tst == "0") { TST = "Default"; }
                else if (tst == "1") { TST = "Test target"; }

                string rab = myMissatge2.Substring(2, 1);
                if (rab == "0") { RAB = "Report from target transponder"; }
                else if (rab == "1") { RAB = "Report from filed monitor ( fixed transponder )"; }

                string lop = myMissatge2.Substring(3, 2);
                if (lop == "00") { LOP = "Undetermined"; }
                else if (lop == "01") { LOP = "Loop start"; }
                else if (lop == "10") { LOP = "Loop finish"; }

                string tot = myMissatge2.Substring(5, 2);
                if (tot == "00") { TOT = "Undetermined"; }
                else if (tot == "01") { TOT = "Aircraft"; }
                else if (tot == "10") { TOT = "Ground vehicle"; }
                else if (tot == "11") { TOT = "Helicopter"; }

                next_octet = next_octet + 1;
                target_report_descriptor = target_report_descriptor + "; SIM:" + SIM + "; TST: " + TST + "; RAB: " + RAB + "; LOP:" + LOP + "; TOT:" + TOT;

                fx = myMissatge2.Substring(7, 1);
                if (fx == "1")
                {
                    string myMissatge3 = missatge[octet + 2];

                    string spi = myMissatge3.Substring(0, 1);
                    if (spi == "0") { SPI = "Absence of SPI"; }
                    else if (spi == "1") { SPI = "Special Position Identification"; }
                    next_octet = next_octet + 1;
                    target_report_descriptor = target_report_descriptor + "; SPI:" + SPI;
                }
            }

            return next_octet;
        }

        //FRN 4 --> no entenc el format
        public int Find_Time_Of_Day(string[] missatge, int octet)
        {
            string bits = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8));
            double total_seconds = Convert.ToDouble(Convert.ToInt32(bits, 2)) / 128;

            TimeSpan ts = TimeSpan.FromSeconds(Math.Truncate(total_seconds));
            time_day = ts.ToString();

            return octet + 3;
        }

        //FRN 5
        string lon; string lat;
        public int Find_Position_WGS84(string[] missatge, int octet)
        {
            //Length in octets: FIXED 8

            //READ LATITUDE AND LONGITUDE
            string latitude1 = missatge[octet];
            string latitude2 = missatge[octet + 1];
            string latitude3 = missatge[octet + 2];
            string latitude4 = missatge[octet + 3];
            string longitude1 = missatge[octet + 4];
            string longitude2 = missatge[octet + 5];
            string longitude3 = missatge[octet + 6];
            string longitude4 = missatge[octet + 7];

            string latitude = string.Concat(latitude1, latitude2, latitude3, latitude4);
            string longitude = string.Concat(longitude1, longitude2, longitude3, longitude4);

            //A complement to get longitude and latitude

            lat = Convert.ToString(Useful.A2Complement(latitude));
            lon = Convert.ToString(Useful.A2Complement(longitude));

            double latitude_all = Convert.ToInt32(lat) * (180 / (Math.Pow(2, 31)));
            double longitude_all = Convert.ToInt32(lon) * (180 / (Math.Pow(2, 31)));

            int latitude_degrees = Convert.ToInt32(Math.Truncate(latitude_all));
            int latitude_minutes = Convert.ToInt32(Math.Truncate((latitude_all - latitude_degrees) * 60));
            double latitude_seconds = Math.Round(((latitude_all - (latitude_degrees + (Convert.ToDouble(latitude_minutes) / 60))) * 3600), 3);

            int longitude_degrees = Convert.ToInt32(Math.Truncate(longitude_all));
            int longitude_minutes = Convert.ToInt32(Math.Truncate((longitude_all - longitude_degrees) * 60));
            double longitude_seconds = Math.Round(((longitude_all - (longitude_degrees + (Convert.ToDouble(longitude_minutes) / 60))) * 3600), 3);

            string latitudeWGS84 = Convert.ToString(latitude_degrees) + "º " + Convert.ToString(latitude_minutes) + "' " + Convert.ToString(latitude_seconds) + "''";
            string longitudeWGS84 = Convert.ToString(longitude_degrees) + "º" + Convert.ToString(longitude_minutes) + "' " + Convert.ToString(longitude_seconds) + "''";

            position_WGS84 = latitudeWGS84 + ";" + longitudeWGS84;

            int next_octet = octet + 8;
            return next_octet;
        }

        //FRN 6
        public int Find_Position_Polar(string[] missatge, int octet)
        {
            string buffer;
            buffer = missatge[octet];
            string rho = "";
            string theta = "";
            for (int o = 0; o < 2; o++)
            {
                for (int i = 0; i < 8; i++)
                {
                    rho = rho + buffer[i].ToString();
                }
                octet++;
                buffer = missatge[octet];
            }
            for (int o = 0; o < 2; o++)
            {
                for (int i = 0; i < 8; i++)
                {
                    theta = theta + buffer[i].ToString();
                }
                octet++;
                buffer = missatge[octet];
            }

            position_polar = Convert.ToString(Convert.ToInt32(rho, 2)) + " m , " + Convert.ToString(Convert.ToInt32(theta, 2)) + "º";
            return octet++;
        }

        //FRN 7
        string x_total; string y_total;
        public int Find_Position_Cartesian(string[] missatge, int octet)
        {
            //Length in octets: FIXED 4
            //READ LATITUDE AND LONGITUDE
            string x1 = missatge[octet];
            string x2 = missatge[octet + 1];
            string y1 = missatge[octet + 2];
            string y2 = missatge[octet + 3];

            string x = string.Concat(x1, x2);
            string y = string.Concat(y1, y2);

            x_total = Convert.ToString(Useful.A2Complement(x));
            y_total = Convert.ToString(Useful.A2Complement(y));

            position_cartesian = "X: " + Convert.ToString(x_total) + "m ; Y: " + Convert.ToString(y_total) + "m";

            int next_octet = octet + 4;
            return next_octet;
        }

        //FRN 8
        public int Find_Track_Velocity_Polar(string[] missatge, int octet)
        {
            string buffer;
            buffer = missatge[octet];
            string ground_speed = "";
            string track_angle = "";
            for (int o = 0; o < 2; o++)
            {
                for (int i = 0; i < 8; i++)
                {
                    ground_speed = ground_speed + buffer[i].ToString();
                }
                octet++;
                buffer = missatge[octet];
            }
            for (int o = 0; o < 2; o++)
            {
                for (int i = 0; i < 8; i++)
                {
                    track_angle = track_angle + buffer[i].ToString();
                }
                octet++;
                buffer = missatge[octet];
            }

            track_velocity_polar = "Ground speed: " + Convert.ToString(Convert.ToInt32(ground_speed, 2)) + "knts ; Track angle: " + Convert.ToString(Convert.ToInt32(track_angle, 2)) + "º";
            return octet++;
        }


        //FRN 9
        string Vx_cartesian; string Vy_cartesian;
        public int Find_Calculated_Track_Velocity_Cartesian(string[] missatge, int octet)
        {
            //Length in octets: FIXED 4

            //READ LATITUDE and LONGITUDE
            double vx = Useful.A2Complement(string.Concat(missatge[octet], missatge[octet + 1]));
            vx = vx * 0.25;

            double vy = Useful.A2Complement(string.Concat(missatge[octet + 2], missatge[octet + 3]));
            vy = vy * 0.25;

            track_velocity_cartesian = "Vx: " + Convert.ToString(vx) + " m/s, Vy: " + Convert.ToString(vy) + " m/s";

            int next_octet = octet + 4;
            return next_octet;
        }

        //FRN 10
        public int Find_Track_Number(string[] missatge, int octet)
        {
            string buffer;
            int next_octet = octet;
            buffer = missatge[octet];
            string num = "";
            num = buffer[4].ToString() + buffer[5].ToString() + buffer[6].ToString() + buffer[7].ToString();
            octet++;
            buffer = missatge[octet];

            for (int i = 0; i < 8; i++)
            {
                num = num + buffer[i].ToString();
            }

            track_number = Convert.ToString(Convert.ToInt32(num, 2));
            return next_octet + 2;
        }

        //FRN 11
        string CNF; string TRE; string CST; string MAH; string TCC; string STH;
        string TOM; string DOU; string MRS; string GHO;
        public int Find_Track_Status(string[] missatge, int octet)
        {
            //Length in octets: VARIABLE
            string myMissatge = missatge[octet];

            string chn = myMissatge.Substring(0, 1);
            if (chn == "0") { CNF = "Confirmed track"; }
            else { CNF = "Track in initialisation phase"; }

            string tre = myMissatge.Substring(1, 1);
            if (tre == "0") { TRE = "Default"; }
            else { TRE = "Last report for a track"; }

            string cst = myMissatge.Substring(2, 2);
            if (cst == "00") { CST = "No extrapolation"; }
            else if (cst == "01") { CST = "Predictable extrapolation due to sensor refresh period"; }
            else if (cst == "10") { CST = "Predictable extrapolation in masked area"; }
            else if (cst == "11") { CST = "Extrapolation due to unpredictable absence of detection"; }

            string mah = myMissatge.Substring(4, 1);
            if (mah == "0") { MAH = "Default"; }
            else { MAH = "Horizontal manoeuvre"; }

            string tcc = myMissatge.Substring(5, 1);
            if (tcc == "0") { TCC = "Tracking performed in 'Sensor Plane', i.e. neither slant range correction nor projection was applied"; }
            else { TCC = "Slant range correction and a suitable projection technique are used to track in a 2D.reference plane, tangential to the earth model at the Sensor Site co-ordinates"; }

            string sth = myMissatge.Substring(6, 1);
            if (sth == "0") { STH = "Measured position"; }
            else { STH = "Smoothed position"; }

            track_status = "CNF: " + CNF + ";  TRE:" + TRE + "; CST: " + CST + "; MAH: " + MAH + "; TCC:" + TCC + "; STH:" + STH;
            int next_octet = octet + 1;

            string fx = myMissatge.Substring(7, 1);
            if (fx == "1")
            {
                string myMissatge2 = missatge[octet + 1];

                string tom = myMissatge2.Substring(0, 2);
                if (tom == "00") { TOM = "Unknown type of movement"; }
                else if (tom == "01") { TOM = "Taking-off"; }
                else if (tom == "10") { TOM = "Landing"; }
                else if (tom == "11") { TOM = "Other types of movement"; }

                string dou = myMissatge2.Substring(2, 3);
                if (dou == "0") { DOU = "No doubt"; }
                else if (dou == "000") { DOU = "Doubtful correlation (undetermined reason)"; }
                else if (dou == "001") { DOU = "Doubtful correlation in clutter"; }
                else if (dou == "010") { DOU = "Loss of accuracy"; }
                else if (dou == "011") { DOU = "Loss of accuracy in clutter"; }
                else if (dou == "101") { DOU = "Unstable track"; }
                else if (dou == "110") { DOU = "Previously coasted"; }

                string mrs = myMissatge2.Substring(5, 2);
                if (mrs == "00") { MRS = "Merge or split indication undetermined"; }
                else if (mrs == "01") { MRS = "Track merged by association to plot"; }
                else if (mrs == "10") { MRS = "Track merged by non-association to plot"; }
                else if (mrs == "11") { MRS = "Split track"; }

                track_status = track_status + "TOM: " + TOM + ";  DOU:" + DOU + "; MRS: " + MRS;
                next_octet = next_octet + 1;

                string fx2 = myMissatge2.Substring(7, 1);
                if (fx2 == "1")
                {
                    string myMissatge3 = missatge[octet + 2];

                    string gho = myMissatge.Substring(0, 1);
                    if (gho == "0") { GHO = "GHO: Default"; }
                    else { GHO = "Ghost track"; }

                    track_status = track_status + "; GHO:" + GHO;
                    next_octet = next_octet + 1;
                }
            }
            return next_octet;
        }

        //FRN 12
        string V_M3A; string G_M3A; string L_M3A;
        public int Find_Mode_3A(string[] missatge, int octet)
        {
            //Length in octets: FIXED 2

            string myMissatge = String.Concat(missatge[octet], missatge[octet + 1]);

            string v = myMissatge.Substring(0, 1);
            if (v == "0") { V_M3A = "Code validated"; }
            else { V_M3A = "Code not validated"; }

            string g = myMissatge.Substring(1, 1);
            if (g == "0") { G_M3A = "Default"; }
            else { G_M3A = "Garbled code"; }

            string l = myMissatge.Substring(2, 1);
            if (l == "0") { L_M3A = "Mode-3/A code derived from the reply of the transponder"; }
            else { L_M3A = "Mode-3/A code not extracted during the last scan"; }

            string M3A_missatge = myMissatge.Substring(4, 14);
            M3A_missatge = Convert.ToString(Useful.IntToOctal(Convert.ToInt32(M3A_missatge, 2)));

            // FALTA GUARDAR INFORMACION
            mode3A = "V: " + V_M3A + "; G:" + G_M3A + "; L: " + L_M3A + "; Message: " + M3A_missatge;

            int next_octet = octet + 2;
            return next_octet;
        }


        //FRN 13
        public int Find_Target_Address(string[] missatge, int octet)
        {
            //Length in octets: FIXED 3

            string address1 = Convert.ToInt32(missatge[octet], 2).ToString("X").PadLeft(2, '0');
            string address2 = Convert.ToInt32(missatge[octet + 1], 2).ToString("X").PadLeft(2, '0');
            string address3 = Convert.ToInt32(missatge[octet + 2], 2).ToString("X").PadLeft(2, '0');

            target_address = string.Concat(address1, address2, address3);

            //Console.WriteLine(target_address);

            int next_octet = octet + 3;
            return next_octet;
        }


        //FRN 14
        public int Find_Target_Id(string[] missatge, int octet)
        {
            string character1 = Useful.Decode_Character(missatge[octet].Substring(0, 6));
            string character2 = Useful.Decode_Character(string.Concat(missatge[octet].Substring(6, 2), missatge[octet + 1].Substring(0, 4)));
            string character3 = Useful.Decode_Character(string.Concat(missatge[octet + 1].Substring(4, 4), missatge[octet + 2].Substring(0, 2)));
            string character4 = Useful.Decode_Character(string.Concat(missatge[octet + 2].Substring(2, 6)));
            string character5 = Useful.Decode_Character(string.Concat(missatge[octet + 3].Substring(0, 6)));
            string character6 = Useful.Decode_Character(string.Concat(missatge[octet + 3].Substring(6, 2), missatge[octet + 4].Substring(0, 4)));
            string character7 = Useful.Decode_Character(string.Concat(missatge[octet + 4].Substring(4, 4), missatge[octet + 5].Substring(0, 2)));
            string character8 = Useful.Decode_Character(missatge[octet + 5].Substring(2, 6));

            target_id = string.Concat(character1, character2, character3, character4, character5, character6, character7, character8);

            return octet + 6;
        }

        //FRN 15 --> Les dades amb quin format estan? Ho deixo en bits de moment.
        public int Find_ModeS(string[] missatge, int octet)
        {
            string buffer;
            string rep = "";
            string data = "";
            string BDS1 = "";
            string BDS2 = "";

            buffer = missatge[octet];
            for (int o = 0; o < 1; o++)
            {
                for (int i = 0; i < 8; i++)
                {
                    rep = rep + buffer[i].ToString();
                }
                octet++;
                buffer = missatge[octet];
            }
            for (int o = 0; o < 7; o++)
            {
                for (int i = 0; i < 8; i++)
                {
                    data = data + buffer[i].ToString();
                }
                octet++;
                buffer = missatge[octet];
            }
            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                    BDS1 = BDS1 + buffer[i].ToString();
                else
                    BDS2 = BDS2 + buffer[i].ToString();
            }

            track_velocity_polar = Convert.ToString(Convert.ToInt32(rep, 2)) + ";" + data + ";" + BDS1 + ";" + BDS2;

            return octet++;
        }

        //FRN 16
        public int Find_Vehicle_Fleet_Id(string[] missatge, int octet)
        {
            string buffer;
            buffer = missatge[octet];
            string num = buffer.Substring(0, 8);

            switch (Convert.ToInt32(num, 2))
            {
                case 0:
                    vehicle_fleet_id = "Unknown";
                    break;
                case 1:
                    vehicle_fleet_id = "ATC equipment maintenance";
                    break;
                case 2:
                    vehicle_fleet_id = "Airport maintenance";
                    break;
                case 3:
                    vehicle_fleet_id = "Fire";
                    break;
                case 4:
                    vehicle_fleet_id = "Bird scarer";
                    break;
                case 5:
                    vehicle_fleet_id = "Snow plough";
                    break;
                case 6:
                    vehicle_fleet_id = "Runway sweeper";
                    break;
                case 7:
                    vehicle_fleet_id = "Emergency";
                    break;
                case 8:
                    vehicle_fleet_id = "Police";
                    break;
                case 9:
                    vehicle_fleet_id = "Bus";
                    break;
                case 10:
                    vehicle_fleet_id = "Tug (push/tow)";
                    break;
                case 11:
                    vehicle_fleet_id = "Grass cutter";
                    break;
                case 12:
                    vehicle_fleet_id = "Fuel";
                    break;
                case 13:
                    vehicle_fleet_id = "Baggage";
                    break;
                case 14:
                    vehicle_fleet_id = "Catering";
                    break;
                case 15:
                    vehicle_fleet_id = "Aircraft maintenance";
                    break;
                case 16:
                    vehicle_fleet_id = "Flyco (follow me)";
                    break;
                default:
                    vehicle_fleet_id = "UFO"; //Easter egg
                    break;
            }

            return octet++;
        }


        //FRN 17
        string V_FL; string G_FL; string FL;
        public int Find_Flight_Level_Binary(string[] missatge, int octet)
        {
            //Length in octets: FIXED 2

            char[] myMissatge = missatge[octet].ToCharArray(0, 8);

            if (myMissatge[0] == 0)
            {
                V_FL = "Code validated";
            }
            else
            {
                V_FL = "Code not validated";
            }

            if (myMissatge[1] == 0)
            {
                G_FL = "Default";
            }
            else
            {
                G_FL = "Garbled code";
            }

            string FL_string = string.Concat(missatge[octet], missatge[octet + 1]).Substring(2, 14);

            FL = Convert.ToString(Useful.A2Complement(FL_string) * (1 / 4));

            flight_level = V_FL + ", " + G_FL + ", Flight level: " + FL;

            int next_octet = octet + 2;
            return next_octet;
        }

        //FRN 18
        public int Find_Height(string[] missatge, int octet)
        {
            string num = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1]);

            height = Convert.ToString(Useful.A2Complement(num));

            height = height + " ft";

            return octet + 2;
        }

        //FRN 19
        string length; string orientation; string width;
        public int Find_Target_Size_Orientation(string[] missatge, int octet)
        {
            //Length in octets: VARIABLE
            length = "Lenght:  " + Convert.ToString(Convert.ToInt32(missatge[octet].Substring(0, 7), 2)) + "m";
            size_orientation = length;

            int next_octet = octet + 1;


            if (missatge[octet].Substring(7, 1) == "1")
            {
                orientation = "Orientation: " + Convert.ToString(Convert.ToDouble(Convert.ToInt32(missatge[octet + 1].Substring(0, 7), 2)) * (360 / 128)) + "°";
                size_orientation = length + "," + orientation;
                next_octet = next_octet + 1;

                if (missatge[octet + 1].Substring(7, 1) == "1")
                {
                    width = "Widht: " + Convert.ToString(Convert.ToInt32(missatge[octet + 2].Substring(0, 7), 2)) + "m";
                    size_orientation = length + "," + orientation + "," + width;
                    next_octet = next_octet + 1;
                }
            }
            return next_octet;
        }

        //FRN 20
        public int Find_System_Status(string[] missatge, int octet)
        {
            string buffer;
            buffer = missatge[octet];

            string nogo = buffer.Substring(0, 2);
            string ovl = buffer.Substring(2, 1);
            string tsv = buffer.Substring(3, 1);
            string div = buffer.Substring(4, 1);
            string ttf = buffer.Substring(5, 1);

            string NOGO, OVL, TSV, DIV, TTF;

            if (nogo == "00")
                NOGO = "Operational";
            else if (nogo == "01")
                NOGO = "Degraded";
            else
                NOGO = "NOGO";

            if (ovl == "0")
                OVL = "No overload";
            else
                OVL = "Overload";

            if (tsv == "0")
                TSV = "valid";
            else
                TSV = "invalid";

            if (div == "0")
                DIV = "Normal Operation";
            else
                DIV = "Diversity degraded";

            if (ttf == "0")
                TTF = "Test Target Operative";
            else
                TTF = "Test Target Failure";


            system_status = string.Concat(NOGO, ";", OVL, ";", TSV, ";", DIV, ";", TTF);

            return octet++;
        }

        //FRN 21
        string TRB;
        string preprogrammed_message;
        public int Find_Preprogrammed_Message(string[] missatge, int octet)
        {
            //Length in octets: FIXED 1
            string myMissatge = missatge[octet];

            if (myMissatge == "0")
            {
                TRB = "Default";
            }
            else
            {
                TRB = "In Trouble";
            }

            int M = Convert.ToInt32(myMissatge.Substring(1, 7), 2);

            if (M == 1)
            {
                preprogrammed_message = "Towing aircraft";
            }
            else if (M == 2)
            {
                preprogrammed_message = "Follow me operation";
            }
            else if (M == 3)
            {
                preprogrammed_message = "Runway check";
            }
            else if (M == 4)
            {
                preprogrammed_message = "Emergency operation (fire, medical ...)";
            }
            else if (M == 5)
            {
                preprogrammed_message = "Work in progress (maintenance, birds scarer, sweepers ...";
            }

            preprogrammed_msg = "Trouble: " + TRB + ";" + "Message: " + preprogrammed_message;
            int next_octet = octet + 1;
            return next_octet;
        }

        //FRN 22
        public int Find_Std_Deviation_Position(string[] missatge, int octet)
        {
            string x = missatge[octet].Substring(0, 8);
            string y = missatge[octet + 1].Substring(0, 8);
            string xy = string.Concat(missatge[octet + 2].Substring(0, 8), missatge[octet + 3].Substring(0, 8));

            string X = Convert.ToString(Convert.ToInt32(x, 2) * 0.25);
            string Y = Convert.ToString(Convert.ToInt32(y, 2) * 0.25);
            string XY = Convert.ToString(Useful.A2Complement(xy) * 0.25);

            std_deviation_position = string.Concat(X, ";", Y, ";", XY);
            return octet + 4;
        }

        //FRN 23
        int REP; string DRHO = ""; string DTHETA = "";
        public int Find_Presence(string[] missatge, int octet)
        {
            //Length in octets: FIXED 3
            int REP = Convert.ToInt32(missatge[octet], 2); //number of presence associated to the plot
            octet = octet + 1;
            for (int i = 0; i < REP; i++)
            {
                DRHO = DRHO + "DRHO rep" + REP + ":" + Convert.ToString(Convert.ToInt32(missatge[octet], 2)) + "m ,";
                DTHETA = DTHETA + "DTHETA rep" + REP + ":" + Convert.ToString(Convert.ToDouble(Convert.ToInt32(missatge[octet + 1], 2)) * 0.15) + "º ; ";
                octet = octet + 2;
                presence = DRHO + DTHETA;
            }


            int next_octet = octet - 2;
            return next_octet;
        }

        //FRN 24
        public int Find_Amplitude_Of_Primary_Plot(string[] missatge, int octet)
        {
            string PAM = missatge[octet].Substring(0, 8);

            amplitude_of_primary_plot = Convert.ToString(Convert.ToInt32(PAM, 2));

            return octet++;
        }

        //FRN 25
        public int Find_Calculated_Acceleration(string[] missatge, int octet)
        {
            //Length in octets: FIXED 2

            string ax = Convert.ToString(missatge[octet]);
            string ay = Convert.ToString(missatge[octet + 1]);

            int sum_ax = 0;
            int sum_ay = 0;
            for (int i = 1; i < 7; i++)
            {
                if (ax[i] == 1)
                {
                    sum_ax = sum_ax + 31 * 1 / (1 / 2 ^ i);
                }
                if (ay[i] == 1)
                {
                    sum_ay = sum_ay + 31 * 1 / (1 / 2 ^ i);
                }
            }

            if (ax[0] == 1)
            {
                sum_ax = (-1) * sum_ax;
            }
            if (ay[0] == 1)
            {
                sum_ay = (-1) * sum_ay;
            }

            acceleration = "ax:" + sum_ax + "m/s^2; ay:" + sum_ay + "m/s^2";
            Console.WriteLine(acceleration);

            int next_octet = octet + 2;
            return next_octet;
        }


        //FRN 27 FUERAAAA! NO EN ESTA VERSION
        public void Find_Special_Purpose_Field(string missatge, int octet)
        {
            //Length in octets: VARIABLE
        }

    }
}

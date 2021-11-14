using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT21
    {
        public string SAC;
        public string SIC;
        public string target_report_descriptor;
        public string target_status;
        public string track_number;
        public string service_identification;
        public string time_applicability_position;
        public string position_WGS84;
        public string position_WGS84_high_res;
        public string time_applicability_velocity;
        public string air_speed;
        public string true_air_speed;
        public string target_address;
        public string time_message_reception_position;
        public string time_message_reception_position_high;
        public string time_message_reception_velocity;
        public string time_message_reception_velocity_high_precision;
        public string geometric_height;
        public string receiver_id;
        public string ACAS_resolution_advisory_report;
        public string surface_capabilities_characteristics;
        public string service_management;
        public string final_state_selected_altitude;
        public string met_information;
        public string emitter_category;
        public string track_angle_rate;
        public string geometric_vertical_rate;
        public string MOPS_version;
        public string roll_angle;
        public string magnetic_heading;
        public string barometric_vertical_rate;
        public string airbone_ground_vector;
        public string time_report_transmission;
        public string target_id;
        public string selected_altitude;
        public string aircraft_operational_status;
        public string trajectory_intend;
        public string message_amplitude;
        public string mode_s;
        public string flight_level;
        public string data_ages;
        public string mode3A;
        public string quality_indicators;
        public string special_purpose_field;
        public string reserved_expansion_field;

        /*public CAT21(string SAC, string SIC, string message_type, string target_report_descriptor, string time_day, string position_WGS84, string position_polar, string position_cartesian, string track_velocity_polar, string track_velocity_cartesian, string track_number, string track_status, string mode3A, string target_address, string target_id, string modeS, string vehicle_fleet_id, string flight_level, string height, string size_orientation, string system_status, string preprogrammed_msg, string std_deviation_position, string presence, string amplitude_of_primary_plot, string acceleration, string special_purpose, string reserved_expansion)
        {
            this.SAC = SAC;
            this.SIC = SIC;
            this.target_report_descriptor = target_report_descriptor;
            this.target_status = target_status;
            this.service_identification = service_identification;
            this.air_speed = air_speed;
            this.target_address = target_address;
            this.receiver_id = receiver_id;
            this.ACAS_resolution_advisory_report = ACAS_resolution_advisory_report;
            this.surface_capabilities_characteristics = surface_capabilities_characteristics;
            this.service_management = service_management;
            this.final_state_selected_altitude = final_state_selected_altitude;
            this.met_information = met_information;
            this.emitter_category = emitter_category;
            this.track_angle_rate = track_angle_rate;
            this.geometric_vertical_rate = geometric_vertical_rate;
        }*/

        public CAT21()
        {
            SAC = "No data";
            SIC = "No data";
            target_report_descriptor = "No data";
            target_status = "No data";
            track_number = "No data";
            service_identification = "No data";
            time_applicability_position = "No data";
            position_WGS84 = "No data";
            position_WGS84_high_res = "No data";
            time_applicability_velocity = "No data";
            air_speed = "No data";
            true_air_speed = "No data";
            target_address = "No data";
            time_message_reception_position = "No data";
            time_message_reception_position_high = "No data";
            time_message_reception_velocity = "No data";
            time_message_reception_velocity_high_precision = "No data";
            geometric_height = "No data";
            receiver_id = "No data";
            ACAS_resolution_advisory_report = "No data";
            surface_capabilities_characteristics = "No data";
            service_management = "No data";
            final_state_selected_altitude = "No data";
            met_information = "No data";
            emitter_category = "No data";
            track_angle_rate = "No data";
            geometric_vertical_rate = "No data";
            MOPS_version = "No data";
            roll_angle = "No data";
            magnetic_heading = "No data";
            barometric_vertical_rate = "No data";
            airbone_ground_vector = "No data";
            time_report_transmission = "No data";
            target_id = "No data";
            selected_altitude = "No data";
            aircraft_operational_status = "No data";
            trajectory_intend = "No data";
            message_amplitude = "No data";
            mode_s = "No data";
            flight_level = "No data";
            data_ages = "No data";
            mode3A = "No data";
            quality_indicators = "No data";
            special_purpose_field = "No data";
            reserved_expansion_field = "No data";
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

                        if (missatge[6].Substring(7, 1) == "1")
                        {
                            next_octet++;

                            if (missatge[7].Substring(7, 1) == "1")
                            {
                                next_octet++;

                                if (missatge[8].Substring(7, 1) == "1")
                                {
                                    next_octet++;

                                }
                            }
                        }
                    }
                }
            }

            string rf = missatge[3].Substring(0, 1);
            if (rf == "1") { next_octet = Find_Data_Source_Identifier(missatge, next_octet); }

            rf = missatge[3].Substring(1, 1);
            if (rf == "1") { next_octet = Find_Target_Report_Descriptor(missatge, next_octet); }

            rf = missatge[3].Substring(2, 1);
            if (rf == "1") { next_octet = Find_Track_Number(missatge, next_octet); }

            rf = missatge[3].Substring(3, 1);
            if (rf == "1") { next_octet = Find_Service_Identification(missatge, next_octet); }

            rf = missatge[3].Substring(4, 1);
            if (rf == "1") { next_octet = Find_Time_Applicability_Position(missatge, next_octet); }

            rf = missatge[3].Substring(5, 1);
            if (rf == "1") { next_octet = Find_Position_WGS84(missatge, next_octet); }

            rf = missatge[3].Substring(6, 1);
            if (rf == "1") { next_octet = Find_Position_WGS84_High_Res(missatge, next_octet); }

            rf = missatge[3].Substring(7, 1);
            if (rf == "1")
            {

                rf = missatge[4].Substring(0, 1);
                if (rf == "1") { next_octet = Find_Time_Applicability_Velocity(missatge, next_octet); }

                rf = missatge[4].Substring(1, 1);
                if (rf == "1") { next_octet = Find_Air_Speed(missatge, next_octet); }

                rf = missatge[4].Substring(2, 1);
                if (rf == "1") { next_octet = Find_True_Air_Speed(missatge, next_octet); }

                rf = missatge[4].Substring(3, 1);
                if (rf == "1") { next_octet = Find_Target_Address(missatge, next_octet); }

                rf = missatge[4].Substring(4, 1);
                if (rf == "1") { next_octet = Find_Time_Message_Reception_Position(missatge, next_octet); }

                rf = missatge[4].Substring(5, 1);
                if (rf == "1") { next_octet = Find_Time_Message_Reception_Position_High_Precision(missatge, next_octet); }

                rf = missatge[4].Substring(6, 1);
                if (rf == "1") { next_octet = Find_Time_Message_Reception_Velocity(missatge, next_octet); }

                rf = missatge[4].Substring(7, 1);
                if (rf == "1")
                {
                    rf = missatge[5].Substring(0, 1);
                    if (rf == "1") { next_octet = Find_Time_Message_Reception_Velocity_High_Precision(missatge, next_octet); }

                    rf = missatge[5].Substring(1, 1);
                    if (rf == "1") { next_octet = Find_Geometric_Height(missatge, next_octet); }

                    rf = missatge[5].Substring(2, 1);
                    if (rf == "1") { next_octet = Find_Quality_Indicators(missatge, next_octet); }

                    rf = missatge[5].Substring(3, 1);
                    if (rf == "1") { next_octet = Find_MOPS_Version(missatge, next_octet); }

                    rf = missatge[5].Substring(4, 1);
                    if (rf == "1") { next_octet = Find_Mode3A_Code(missatge, next_octet); }

                    rf = missatge[5].Substring(5, 1);
                    if (rf == "1") { next_octet = Find_Roll_Angle(missatge, next_octet); }

                    rf = missatge[5].Substring(6, 1);
                    if (rf == "1") { next_octet = Find_Flight_Level(missatge, next_octet); }

                    rf = missatge[5].Substring(7, 1);
                    if (rf == "1")
                    {
                        rf = missatge[6].Substring(0, 1);
                        if (rf == "1") { next_octet = Find_Magnetic_Heading(missatge, next_octet); }

                        rf = missatge[6].Substring(1, 1);
                        if (rf == "1") { next_octet = Find_Target_Status(missatge, next_octet); }

                        rf = missatge[6].Substring(2, 1);
                        if (rf == "1") { next_octet = Find_Barometric_Vertical_Rate(missatge, next_octet); }

                        rf = missatge[6].Substring(3, 1);
                        if (rf == "1") { next_octet = Find_Geometric_Vertical_Rate(missatge, next_octet); }

                        rf = missatge[6].Substring(4, 1);
                        if (rf == "1") { next_octet = Find_Airborne_Ground_Vector(missatge, next_octet); }

                        rf = missatge[6].Substring(5, 1);
                        if (rf == "1") { next_octet = Find_Track_Angle_Rate(missatge, next_octet); }

                        rf = missatge[6].Substring(6, 1);
                        if (rf == "1") { next_octet = Find_Time_Report_Transmission(missatge, next_octet); }

                        rf = missatge[6].Substring(7, 1);
                        if (rf == "1")
                        {
                            rf = missatge[7].Substring(0, 1);
                            if (rf == "1") { next_octet = Find_Target_Identification(missatge, next_octet); }

                            rf = missatge[7].Substring(1, 1);
                            if (rf == "1") { next_octet = Find_Emitter_Category(missatge, next_octet); }

                            rf = missatge[7].Substring(2, 1);
                            if (rf == "1") { next_octet = Find_Met_Information(missatge, next_octet); }

                            rf = missatge[7].Substring(3, 1);
                            if (rf == "1") { next_octet = Find_Selected_Altitude(missatge, next_octet); }

                            rf = missatge[7].Substring(4, 1);
                            if (rf == "1") { next_octet = Find_Final_State_Selected_Altitude(missatge, next_octet); }

                            rf = missatge[7].Substring(5, 1);
                            if (rf == "1") { next_octet = Find_Trajectory_Intent(missatge, next_octet); }

                            rf = missatge[7].Substring(6, 1);
                            if (rf == "1") { next_octet = Find_Service_Management(missatge, next_octet); }

                            rf = missatge[7].Substring(7, 1);
                            if (rf == "1")
                            {
                                rf = missatge[8].Substring(0, 1);
                                if (rf == "1") { next_octet = Find_Aircraft_Operational_Status(missatge, next_octet); }

                                rf = missatge[8].Substring(1, 1);
                                if (rf == "1") { next_octet = Find_Surface_Capabilities_And_Characteristics(missatge, next_octet); }

                                rf = missatge[8].Substring(2, 1);
                                if (rf == "1") { next_octet = Find_Message_Amplitude(missatge, next_octet); }

                                rf = missatge[8].Substring(3, 1);
                                if (rf == "1") { next_octet = Find_Mode_S(missatge, next_octet); }

                                rf = missatge[8].Substring(4, 1);
                                if (rf == "1") { next_octet = Find_ACAS_Resolution_Advisory_Report(missatge, next_octet); }

                                rf = missatge[8].Substring(5, 1);
                                if (rf == "1") { next_octet = Find_Receiver_ID(missatge, next_octet); }

                                rf = missatge[8].Substring(6, 1);
                                if (rf == "1") { next_octet = Find_Data_Ages(missatge, next_octet); }
                            }
                        }
                    }
                }
            }
        }

        //FRN 1 --> MAR
        public int Find_Data_Source_Identifier(string[] missatge, int octet)
        {
            //Length in octets: FIXED 2

            SAC = missatge[octet];
            SIC = missatge[octet + 1];

            //SIC = String.Format("{0:X2}", Convert.ToUInt64(SIC, 2));
            //SAC = String.Format("{0:X2}", Convert.ToUInt64(SAC, 2));

            int sic = Convert.ToInt32(SIC, 2);
            int sac = Convert.ToInt32(SAC, 2);

            SIC = Convert.ToString(sic);
            SAC = Convert.ToString(sac);

            int next_octet = octet + 2;
            return next_octet;
        }

        // FRN 2 --> MAR
        string ATP; string ARC; string RC; string RAB;
        string DCR; string GBS; string SIM; string TST; string SAA; string CL;
        string IPC; string NOGO; string CPR; string LDPJ; string RCF;
        public int Find_Target_Report_Descriptor(string[] missatge, int octet)
        {
            //Length in octets: VARIABLE
            string myMissatge = missatge[octet];

            string atp = myMissatge.Substring(0, 3); //address type
            if (atp == "000") { ATP = "24-Bit ICAO address"; }
            else if (atp == "001") { ATP = "Duplicate address"; }
            else if (atp == "010") { ATP = "Surface vehicle address"; }
            else if (atp == "011") { ATP = "Anonymous address"; }
            else { atp = "Reserved for future use"; }

            string arc = myMissatge.Substring(3, 2);//altitude reporting capacity
            if (arc == "00") { ARC = "25 ft"; }
            else if (arc == "01") { ARC = "100 ft"; }
            else if (arc == "10") { ARC = "Unknown"; }
            else if (arc == "11") { ARC = "Invalid"; }

            string rc = myMissatge.Substring(5, 1); //Range Check
            if (rc == "0") { RC = "Default"; }
            else if (rc == "1") { RC = "Range Check passed, CPR Validation pending"; }

            string rab = myMissatge.Substring(6, 1); //Report type
            if (rab == "0") { RAB = "Report from target transponder"; }
            else if (rab == "1") { RAB = "Report from field monitor (fixed transponder)"; }

            int next_octet = octet + 1;
            target_report_descriptor = "ATP: " + ATP + "; ARC:" + ARC + "; RC:" + RC + "; RAB: " + RAB;

            string fx = myMissatge.Substring(7, 1);
            if (fx == "1")
            {
                string myMissatge2 = missatge[octet + 1];

                string dcr = myMissatge2.Substring(0, 1); //Differential Correction
                if (dcr == "0") { DCR = "No differential correction (ADS-B)"; }
                else if (dcr == "1") { DCR = "Differential correction (ADS-B)"; }

                string gbs = myMissatge2.Substring(1, 1); //Ground Bit Setting
                if (gbs == "0") { GBS = "Ground Bit not set"; }
                else if (gbs == "1") { GBS = "Ground Bit set"; }

                string sim = myMissatge2.Substring(2, 1); //Simulated Target
                if (sim == "0") { SIM = "Actual target report"; }
                else if (sim == "1") { SIM = "Simulated target report"; }

                string tst = myMissatge.Substring(3, 1); //Test Target
                if (tst == "0") { TST = "Default"; }
                else if (tst == "1") { TST = "Test Target"; }

                string saa = myMissatge.Substring(4, 1); //Selected Altitude Available
                if (saa == "0") { SAA = "Equipment capable to provide Selected Altitude"; }
                else if (saa == "1") { SAA = "Equipment not capable to provide Selected Altitude"; }

                string cl = myMissatge.Substring(5, 2); //Confidence Level
                if (cl == "00") { CL = "Report valid"; }
                else if (cl == "01") { CL = "Report suspect"; }
                else if (cl == "10") { CL = "No information"; }
                else if (cl == "11") { CL = "Reserved for future use"; }

                next_octet = next_octet + 1;
                target_report_descriptor = target_report_descriptor + "; DCR:" + DCR + "; GBS: " + GBS + "; SIM: " + SIM + "; TST:" + TST + "; SAA:" + SAA + "; CL: " + CL;

                fx = myMissatge.Substring(7, 1);
                if (fx == "1")
                {
                    string myMissatge3 = missatge[octet + 2];

                    string ipc = myMissatge2.Substring(2, 1); //Independent Position Check
                    if (ipc == "0") { IPC = "Default"; }
                    else if (ipc == "1") { IPC = "Independent Position Check failed"; }

                    string nogo = myMissatge2.Substring(3, 1); //No-go Bit Status
                    if (nogo == "0") { NOGO = "NOGO-bit not set"; }
                    else if (nogo == "1") { NOGO = "NOGO-bit set"; }

                    string cpr = myMissatge2.Substring(4, 1); //Compact Position Reporting
                    if (cpr == "0") { CPR = "CPR Validation correct"; }
                    else if (cpr == "1") { CPR = "CPR Validation failed"; }

                    string ldpj = myMissatge2.Substring(5, 1); //Local Decoding Position Jump
                    if (ldpj == "0") { LDPJ = "LDPJ not detected"; }
                    else if (ldpj == "1") { LDPJ = "LDPJ detected"; }

                    string rcf = myMissatge2.Substring(6, 1); //Range Check
                    if (rcf == "0") { RCF = "Default"; }
                    else if (rcf == "1") { RCF = "Range Check failed"; }

                    next_octet = next_octet + 1;
                    target_report_descriptor = target_report_descriptor + "; IPC:" + IPC + "; NOGO: " + NOGO + "; CPR:" + CPR + "; LDPJ:" + LDPJ + "; RCF:" + RCF;
                }
            }

            return next_octet;
        }

        // FRN 3 --> ANDREU
        public int Find_Track_Number(string[] missatge, int octet)
        {
            string num = string.Concat(missatge[octet].Substring(4, 4), missatge[octet + 1].Substring(0, 8));

            track_number = Convert.ToString(Convert.ToInt32(num, 2));
            return octet + 2;
        }

        // FRN 4 --> MAR
        public int Find_Service_Identification(string[] missatge, int octet)
        {
            // FIXED TO 1 OCTET
            string myMissatge = missatge[octet];

            myMissatge = Convert.ToString(Convert.ToInt32(myMissatge, 2));
            service_identification = myMissatge;

            int next_octet = octet + 1;
            return next_octet;
        }

        // FRN 5 --> ANDREU
        public int Find_Time_Applicability_Position(string[] missatge, int octet)
        {
            string bits = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8));
            double total_seconds = Convert.ToDouble(Convert.ToInt32(bits, 2)) / 128;

            TimeSpan ts = TimeSpan.FromSeconds(Math.Truncate(total_seconds));
            time_applicability_position = ts.ToString();

            //time_applicability_position = string.Concat(Convert.ToString(hours), ";", Convert.ToString(Math.Truncate(minutes)), ";", Convert.ToString(seconds));
            return octet + 3;
        }

        // FRN 6 --> ANDREU - S'haurà de revisar compilant
        public int Find_Position_WGS84(string[] missatge, int octet)
        {
            string lat_bits = string.Concat(missatge[octet], missatge[octet + 1], missatge[octet + 2]);
            string lon_bits = string.Concat(missatge[octet + 3], missatge[octet + 4], missatge[octet + 5]);

            double lat_decimal = Useful.A2Complement(lat_bits) * (180 / Math.Pow(2, 23));
            double lon_decimal = Useful.A2Complement(lon_bits) * (180 / Math.Pow(2, 23));

            double lat_sec = (lat_decimal * 3600);
            double lat_deg = lat_sec / 3600;
            lat_sec = lat_sec % 3600;
            double lat_min = lat_sec / 60;
            lat_sec %= 60;

            double lon_sec = lon_decimal * 3600;
            double lon_deg = lon_sec / 3600;
            lon_sec = lon_sec % 3600;
            double lon_min = lon_sec / 60;
            lon_sec %= 60;

            //
            string lat_sec_str = Math.Round(lat_sec,3).ToString(); string lon_sec_str = Math.Round(lon_sec,3).ToString();
            string lat_deg_str = Math.Round(lat_deg).ToString(); string lon_deg_str = Math.Round(lon_deg).ToString();
            string lat_min_str = Math.Round(lat_min).ToString(); string lon_min_str = Math.Round(lon_min).ToString();
            //

            position_WGS84 = lat_deg_str + "d" + lat_min_str + "m" + lat_sec_str + "s;" + lon_deg_str + "d" + lon_min_str + "m" + lon_sec_str + "s";

            return octet + 6;
        }

        // FRN 7 --> MAR - S'haurà de revisar compilant
        public int Find_Position_WGS84_High_Res(string[] missatge, int octet)
        {
            string lat_bits = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8), missatge[octet + 3].Substring(0, 8));
            string lon_bits = string.Concat(missatge[octet + 4].Substring(0, 8), missatge[octet + 5].Substring(0, 8), missatge[octet + 6].Substring(0, 8), missatge[octet + 7].Substring(0, 8));

            double lat_decimal = Useful.A2Complement(lat_bits) * (180 / Math.Pow(2, 30));
            double lon_decimal = Useful.A2Complement(lon_bits) * (180 / Math.Pow(2, 30));

            int lat_sec = (int)Math.Round(lat_decimal * 3600, 5);
            int lat_deg = lat_sec / 3600;
            lat_sec = Math.Abs(lat_sec % 3600);
            int lat_min = lat_sec / 60;
            lat_sec %= 60;

            int lon_sec = (int)Math.Round(lon_decimal * 3600, 5);
            int lon_deg = lon_sec / 3600;
            lon_sec = Math.Abs(lon_sec % 3600);
            int lon_min = lon_sec / 60;
            lon_sec %= 60;

            //
            string lat_sec_str = lat_sec.ToString(); string lon_sec_str = lon_sec.ToString();
            string lat_deg_str = lat_deg.ToString(); string lon_deg_str = lon_deg.ToString();
            string lat_min_str = lat_min.ToString(); string lon_min_str = lon_min.ToString();
            //

            position_WGS84_high_res = "LAT: " + lat_deg_str + "º " + lat_min_str + "' " + lat_sec_str + "'', LON: " + lon_deg_str + "º " + lon_min_str + "' " + lon_sec_str + "'' ";

            return octet + 8;
        }

        // FRN 8 --> ANDREU
        public int Find_Time_Applicability_Velocity(string[] missatge, int octet)
        {
            string bits = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8));
            double total_seconds = Convert.ToDouble(Convert.ToInt32(bits, 2)) / 128;

            TimeSpan ts = TimeSpan.FromSeconds(Math.Truncate(total_seconds));
            time_applicability_velocity = ts.ToString();

            //time_applicability_velocity = string.Concat(Convert.ToString(hours), ";", Convert.ToString(Math.Truncate(minutes)), ";", Convert.ToString(seconds));
            return octet + 3;
        }

        // FRN 9 --> MAR
        string IM;
        string ASpeed;
        public int Find_Air_Speed(string[] missatge, int octet)
        {
            //FIXED LENGTH : 2 OCTETS

            string myMissatge = String.Concat(missatge[octet], missatge[octet + 1]);

            string im = myMissatge.Substring(0, 1);
            string airspeed = myMissatge.Substring(1, 15);

            if (im == "0")
            {
                im = "IAS";
                ASpeed = Convert.ToString(Convert.ToInt32(airspeed, 2) * Math.Pow(2, -14));
                air_speed = "Air Speed in " + im + ":" + ASpeed + "NM/s";
            }
            else
            {
                im = "Mach";
                ASpeed = Convert.ToString(Convert.ToInt32(airspeed, 2) * 0.001);
                air_speed = "Air Speed in " + im + ":" + ASpeed;
            }
            int next_octet = octet + 2;
            return next_octet;
        }

        // FRN 10 --> ANDREU
        public int Find_True_Air_Speed(string[] missatge, int octet)
        {
            int RE = Convert.ToInt32(missatge[octet].Substring(0, 1));
            string m;

            if (RE == 0)
                m = "";
            else
                m = "Value exceeds defined range: ";

            string tas_bits = string.Concat(missatge[octet].Substring(1, 7), missatge[octet + 1].Substring(0, 8));
            string tas = Convert.ToString(Convert.ToInt32(tas_bits, 2));

            true_air_speed = m + tas + "knt";

            return octet + 2;
        }

        // FRN 11 --> MAR
        public int Find_Target_Address(string[] missatge, int octet)
        {
            //FIXED LENGTH : 3 OCTETS

            string myMissatge = missatge[octet];

            target_address = String.Concat(String.Format("{0:X2}", Convert.ToUInt64(missatge[octet], 2)), String.Format("{0:X2}", Convert.ToUInt64(missatge[octet + 1], 2)), String.Format("{0:X2}", Convert.ToUInt64(missatge[octet + 2], 2)));

            int next_octet = octet + 3;
            return next_octet;
        }

        // FRN 12 --> ANDREU
        public int Find_Time_Message_Reception_Position(string[] missatge, int octet)
        {
            string bits = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8));
            double total_seconds = Convert.ToDouble(Convert.ToInt32(bits, 2)) / 128;

            TimeSpan ts = TimeSpan.FromSeconds(Math.Truncate(total_seconds));
            time_message_reception_position = ts.ToString();

            return octet + 3;
        }

        // FRN 13 --> ANDREU - crec que no està bé
        public int Find_Time_Message_Reception_Position_High_Precision(string[] missatge, int octet)
        {
            string FSI = missatge[octet].Substring(0, 2);
            string fsi;

            if (FSI == "00")
                fsi = "whole seconds";
            else if (FSI == "01")
                fsi = "whole seconds + 1";
            else if (FSI == "10")
                fsi = "whole seconds - 1";
            else
                fsi = "Reserved";

            string bits = string.Concat(missatge[octet].Substring(2, 6), missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8), missatge[octet + 3].Substring(0, 8));
            double total_seconds = Convert.ToDouble(Convert.ToInt32(bits, 2)) * Math.Pow(2, -30);

            TimeSpan ts = TimeSpan.FromSeconds(Math.Truncate(total_seconds));
            time_message_reception_position_high = "FSI: " + FSI + "; Time FSI reception:" + ts.ToString();

            return octet + 4;
        }

        // FRN 14 --> ANDREU
        public int Find_Time_Message_Reception_Velocity(string[] missatge, int octet)
        {
            string bits = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8));
            double total_seconds = Convert.ToDouble(Convert.ToInt32(bits, 2)) / 128;

            TimeSpan ts = TimeSpan.FromSeconds(Math.Truncate(total_seconds));
            time_message_reception_velocity = ts.ToString();

            return octet + 3;
        }
        // FRN 15 --> ANDREU - crec que no està bé
        public int Find_Time_Message_Reception_Velocity_High_Precision(string[] missatge, int octet)
        {
            string FSI = missatge[octet].Substring(0, 2);
            string fsi;

            if (FSI == "00")
                fsi = "whole seconds";
            else if (FSI == "01")
                fsi = "whole seconds + 1";
            else if (FSI == "10")
                fsi = "whole seconds - 1";
            else
                fsi = "Reserved";

            string bits = string.Concat(missatge[octet].Substring(2, 6), missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8), missatge[octet + 3].Substring(0, 8));
            double total_seconds = Convert.ToDouble(Convert.ToInt32(bits, 2)) * Math.Pow(2, -30);

            TimeSpan ts = TimeSpan.FromSeconds(Math.Round(total_seconds, 3));
            time_message_reception_velocity_high_precision = ts.ToString();

            return octet + 4;
        }

        // FRN 16 --> ANDREU
        public int Find_Geometric_Height(string[] missatge, int octet)
        {
            string height_bits = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8));
            string height = Convert.ToString(Convert.ToDouble(Useful.A2Complement(height_bits)) * 6.25);

            string m;

            if (height_bits == "0111111111111111")
                m = "Greater than";
            else
                m = height;

            geometric_height = string.Concat(m) + " ft";

            return octet + 2;
        }

        // FRN 17 --> MAR
        //comença la funció
        string NUCr_or_NACv; string NUCp_or_NIC;
        string NICbaro; string SIL; string NACp;
        string SIL2; string SDA; string GVA;
        string PIC;
        public int Find_Quality_Indicators(string[] missatge, int octet)
        {
            // VARIABLE LENGTH

            string myMissatge = missatge[octet];
            //NO TENGO CLARA LA INFO QUE SE SACA DE AQUÍ!!!!!!!!!!!!!!!!!!
            NUCr_or_NACv = Convert.ToString(Convert.ToInt32(myMissatge.Substring(0, 3), 2));
            NUCp_or_NIC = Convert.ToString(Convert.ToInt32(myMissatge.Substring(3, 4), 2));
            quality_indicators = "NUCr or NACv:" + NUCr_or_NACv + "; NUCp or NIC:" + NUCp_or_NIC;

            int next_octet = octet + 1;

            string fx = myMissatge.Substring(7, 1);
            if (fx == "1")
            {
                //FIRST EXTENSION
                NICbaro = Convert.ToString(Convert.ToInt32(missatge[octet + 1].Substring(0, 1), 2));
                SIL = Convert.ToString(Convert.ToInt32(missatge[octet + 1].Substring(1, 2), 2));
                NACp = Convert.ToString(Convert.ToInt32(missatge[octet + 1].Substring(3, 4), 2));

                quality_indicators = quality_indicators + "; NICbaro: " + NICbaro + "; SIL: " + SIL + "; NACp: " + NACp;

                next_octet = next_octet + 1;

                fx = missatge[octet + 1].Substring(7, 1);
                if (fx == "1")
                {
                    //SECOND EXTENSION
                    if (missatge[octet + 2].Substring(2, 1) == "0") { SIL2 = " SIL: measured per flight hour "; }
                    else { SIL2 = " SIL: measured per sample"; }
                    SDA = Convert.ToString(Convert.ToInt32(missatge[octet + 2].Substring(3, 2), 2));
                    GVA = Convert.ToString(Convert.ToInt32(missatge[octet + 2].Substring(5, 2), 2));

                    quality_indicators = quality_indicators + "; SIL2: " + SIL2 + "; SDA:" + SDA + "; GVA: " + GVA;

                    next_octet = next_octet + 1;

                    fx = missatge[octet + 2].Substring(7, 1);
                    if (fx == "1")
                    {
                        //SECOND EXTENSION
                        int pic = Convert.ToInt32(missatge[octet + 3].Substring(0, 4), 2);
                        if (pic == 0) { PIC = " Integrity Containment Bound: No integrity or >20.0NM; NUCp:0; NIC(DO260A): 0; NIC(DO260B):0"; }
                        else if (pic == 1) { PIC = " Integrity Containment Bound: <20.0 NM; NUCp:1 ; NIC(DO260A):1 ; NIC(DO260B):1"; }
                        else if (pic == 2) { PIC = " Integrity Containment Bound: <10.0 NM; NUCp:2 ; NIC(DO260A):- ; NIC(DO260B):-"; }
                        else if (pic == 3) { PIC = " Integrity Containment Bound: <8.0 NM; NUCp:- ; NIC(DO260A):2 ; NIC(DO260B):2"; }
                        else if (pic == 4) { PIC = " Integrity Containment Bound: <4.0 NM; NUCp:- ; NIC(DO260A):3 ; NIC(DO260B):3"; }
                        else if (pic == 5) { PIC = " Integrity Containment Bound: <2.0 NM; NUCp:3 ; NIC(DO260A):4 ; NIC(DO260B):4"; }
                        else if (pic == 6) { PIC = " Integrity Containment Bound: <1.0 NM; NUCp:4 ; NIC(DO260A):5 ; NIC(DO260B):5"; }
                        else if (pic == 7) { PIC = " Integrity Containment Bound: <0.6 NM; NUCp:- ; NIC(DO260A):6(+1) ; NIC(DO260B):6(+1/1)"; }
                        else if (pic == 8) { PIC = " Integrity Containment Bound: <0.5 NM; NUCp:5 ; NIC(DO260A):6(+0) ; NIC(DO260B):6(+0/0)"; }
                        else if (pic == 9) { PIC = " Integrity Containment Bound: <0.3 NM; NUCp:- ; NIC(DO260A):- ; NIC(DO260B):6(+0/1)"; }
                        else if (pic == 10) { PIC = " Integrity Containment Bound: <0.2 NM; NUCp:6 ; NIC(DO260A):7 ; NIC(DO260B):7"; }
                        else if (pic == 11) { PIC = " Integrity Containment Bound: <0.1 NM; NUCp:7 ; NIC(DO260A):8 ; NIC(DO260B):8"; }
                        else if (pic == 12) { PIC = " Integrity Containment Bound: <0.04 NM; NUCp:- ; NIC(DO260A):9 ; NIC(DO260B):9"; }
                        else if (pic == 13) { PIC = " Integrity Containment Bound: <0.013 NM; NUCp:8 ; NIC(DO260A):10 ; NIC(DO260B):10"; }
                        else if (pic == 14) { PIC = " Integrity Containment Bound: <0.004 NM; NUCp:9 ; NIC(DO260A):11 ; NIC(DO260B):11"; }

                        quality_indicators = quality_indicators + "; PIC:" + PIC;

                        next_octet = next_octet + 1;
                    }
                }
            }
            return next_octet;
        }

        // FRN 18 --> ANDREU
        public int Find_MOPS_Version(string[] missatge, int octet)
        {
            string VNS = missatge[octet].Substring(1, 1);
            int VN = Convert.ToInt32(missatge[octet].Substring(2, 3), 2);
            int LTT = Convert.ToInt32(missatge[octet].Substring(5, 3), 2);

            string vns, vn, ltt;

            if (VNS == "0")
                vns = "The MOPS Version is supported by the GS";
            else
                vns = "The MOPS Version is not supported by the GS";

            if (VN == 0)
                vn = "ED102/DO-260 [Ref. 8]";
            else if (VN == 1)
                vn = "DO-260A [Ref. 9]";
            else
                vn = "ED102A/DO-260B [Ref. 11]";

            if (LTT == 0)
                ltt = "OTHER";
            else if (LTT == 1)
                ltt = "UAT";
            else if (LTT == 2)
                ltt = "1090 ES";
            else if (LTT == 3)
                ltt = "VDL 4";

            MOPS_version = string.Concat("Version: ", vn, ";Link Technology Type: ", LTT);
            return octet + 1;
        }

        // FRN 19 --> MAR
        public int Find_Mode3A_Code(string[] missatge, int octet)
        {
            // 2 OCTET FIXED LENGTH DATA ITEM

            string myMissatge = String.Concat(missatge[octet], missatge[octet + 1]);

            myMissatge = myMissatge.Substring(4, 12);

            //mode3A = Convert.ToString(Convert.ToInt32(myMissatge, 2),8);
            mode3A = Convert.ToString(Useful.IntToOctal(Convert.ToInt32(myMissatge, 2))).PadLeft(4, '0');
            int next_octet = octet + 2;

            return next_octet;
        }

        // FRN 20 --> ANDREU
        public int Find_Roll_Angle(string[] missatge, int octet)
        {
            string num = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8));

            roll_angle = Convert.ToString(Useful.A2Complement(num) * 0.01);

            return octet + 2;
        }

        // FRN 21 --> MAR
        public int Find_Flight_Level(string[] missatge, int octet)
        {
            // FIXED LENGTH: 2 OCTET
            string myMissatge = String.Concat(missatge[octet], missatge[octet + 1]);
            double fl = Useful.A2Complement(myMissatge);
            fl = fl * 0.25;

            flight_level = fl.ToString() + " FL";

            int next_octet = octet + 2;
            return next_octet;
        }

        // FRN 22 --> ANDREU
        public int Find_Magnetic_Heading(string[] missatge, int octet)
        {
            string num = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8));

            magnetic_heading = Convert.ToString(Convert.ToDouble(Convert.ToInt32(num, 2)) * (360 / Math.Pow(2, 16)));

            return octet + 2;
        }

        // FRN 23 --> MAR
        string ICF; string LNAV; string PS; string SS;
        public int Find_Target_Status(string[] missatge, int octet)
        {
            //Length in octets: 1 FIXED
            string myMissatge = missatge[octet];

            string icf = myMissatge.Substring(0, 1); //Intent Change Flag
            if (icf == "0") { ICF = "No intent change active"; }
            else if (icf == "1") { ICF = "Intent change flag raised"; }

            string lnav = myMissatge.Substring(1, 1); //LNAV Mode
            if (lnav == "0") { LNAV = "LNAV Mode engaged"; }
            else if (lnav == "1") { LNAV = "LNAV Mode not engaged"; }

            string ps = myMissatge.Substring(3, 3);//Priority Status
            if (ps == "000") { PS = "No emergency / not reported"; }
            else if (ps == "001") { PS = "General emergency"; }
            else if (ps == "010") { PS = "Lifeguard / medical emergency"; }
            else if (ps == "011") { PS = "Minimum fuel"; }
            else if (ps == "100") { PS = "No communications"; }
            else if (ps == "101") { PS = "Unlawful interference"; }
            else if (ps == "110") { PS = "“Downed” Aircraft"; }

            string ss = myMissatge.Substring(6, 2); //Surveillance Status
            if (ss == "00") { SS = "No condition reported"; }
            else if (ss == "01") { SS = "Permanent Alert (Emergency condition)"; }
            else if (ss == "10") { SS = "Temporary Alert (change in Mode 3/A Code other than emergency)"; }
            else if (ss == "11") { SS = "SPI set"; }

            target_status = "ICF: " + ICF + "; LNAV:" + LNAV + "; PS:" + PS + "; SS: " + SS;

            int next_octet = octet + 1;
            return next_octet;
        }

        // FRN 24 --> ANDREU
        public int Find_Barometric_Vertical_Rate(string[] missatge, int octet)
        {
            string RE = missatge[octet].Substring(0, 1);
            string m;

            if (RE == "0")
                m = "";
            else
                m = "Value exceeds defined range: ";

            string bits = string.Concat(missatge[octet].Substring(1, 7), missatge[octet + 1].Substring(0, 8));
            double num = Useful.A2Complement(bits) * 6.25;

            barometric_vertical_rate = m + num.ToString() + "ft/min";

            return octet + 2;
        }

        // FRN 25 --> MAR
        string RE;
        public int Find_Geometric_Vertical_Rate(string[] missatge, int octet)
        {
            // FIXED LENGTH : 2 OCTETS

            string myMissatge = String.Concat(missatge[octet], missatge[octet + 1]);

            string re = myMissatge.Substring(0, 1);
            if (re == "0")
            {
                RE = "Value in defined range";
                string GVR = Convert.ToString(Useful.A2Complement(myMissatge.Substring(1, 15)) * (6.25));
                geometric_vertical_rate = GVR + "feet/minute";
            }
            else
            {
                RE = "Value exceeds defined range";
                geometric_vertical_rate = RE;
            }

            int next_octet = octet + 2;
            return next_octet;
        }

        // FRN 26 --> ANDREU
        public int Find_Airborne_Ground_Vector(string[] missatge, int octet)
        {
            string RE = missatge[octet].Substring(0, 1);
            string m;

            if (RE == "0")
                m = "Value in defined range";
            else
                m = "Value exceeds defined range";

            string ground_speed = string.Concat(missatge[octet].Substring(1, 7), missatge[octet + 1].Substring(0, 8));
            string track_angle = string.Concat(missatge[octet + 2].Substring(0, 8), missatge[octet + 3].Substring(0, 8));

            airbone_ground_vector = string.Concat("Ground speed: ", Convert.ToString(Convert.ToDouble(Convert.ToInt32(ground_speed, 2)) * Math.Pow(2, -14)), "kts \n Track angle: ", Convert.ToString(Convert.ToDouble(Convert.ToInt32(track_angle, 2)) * (360 / Math.Pow(2, 16)))) + "º";

            return octet + 4;
        }

        // FRN 27 --> MAR
        public int Find_Track_Angle_Rate(string[] missatge, int octet)
        {
            // FIXED LENGTH : 2 OCTETS

            string myMissatge = String.Concat(missatge[octet], missatge[octet + 1]);

            string tar = myMissatge.Substring(6, 10);
            tar = Convert.ToString(Useful.A2Complement(tar) * (1 / 32));

            track_angle_rate = tar + "º/s";

            int next_octet = octet + 2;
            return next_octet;
        }

        // FRN 28 --> ANDREU -- no hi ha explicació?? l'hi foto el mateix que a tots
        public int Find_Time_Report_Transmission(string[] missatge, int octet)
        {
            string bits = string.Concat(missatge[octet].Substring(0, 8), missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8));
            double total_seconds = Convert.ToDouble(Convert.ToInt32(bits, 2)) / 128;

            TimeSpan ts = TimeSpan.FromSeconds(Math.Truncate(total_seconds));
            time_report_transmission = ts.ToString();

            return octet + 3;
        }

        // FRN 29 --> ANDREU
        public int Find_Target_Identification(string[] missatge, int octet)
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

        // FRN 30 --> MAR
        string ECAT;
        public int Find_Emitter_Category(string[] missatge, int octet)
        {
            // DATA LENGTH FIXED : 1 OCTET   

            string myMissatge = missatge[octet];
            int ecat = Convert.ToInt32(myMissatge, 2);

            if (ecat == 0) { ECAT = "No ADS-B Emitter Category Information"; }
            else if (ecat == 1) { ECAT = "Light aircraft <= 15500 lbs"; }
            else if (ecat == 2) { ECAT = "15500 lbs < small aircraft <75000 lbs"; }
            else if (ecat == 3) { ECAT = "75000 lbs < medium a/c < 300000 lbs"; }
            else if (ecat == 4) { ECAT = "High Vortex Large"; }
            else if (ecat == 5) { ECAT = "300000 lbs <= Heavy aircraft"; }
            else if (ecat == 6) { ECAT = "Highly manoeuvrable(5g acceleration capability) and high speed(> 400 knots cruise)"; }
            else if (ecat == 7) { ECAT = "Reserved"; }
            else if (ecat == 8) { ECAT = "Reserved"; }
            else if (ecat == 9) { ECAT = "Reserved"; }
            else if (ecat == 10) { ECAT = "Rotocraft"; }
            else if (ecat == 11) { ECAT = "Glider / sailplane"; }
            else if (ecat == 12) { ECAT = "Lighter than air"; }
            else if (ecat == 13) { ECAT = "Unmanned Aerial Vehicle"; }
            else if (ecat == 14) { ECAT = "Space / transatmospheric Vehicle"; }
            else if (ecat == 15) { ECAT = "Ultralight / handglider / paraglider"; }
            else if (ecat == 16) { ECAT = "Parachutist / Skydiver"; }
            else if (ecat == 17) { ECAT = "Reserved"; }
            else if (ecat == 18) { ECAT = "Reserved"; }
            else if (ecat == 19) { ECAT = "Reserved"; }
            else if (ecat == 20) { ECAT = "Surface emergency vehicle"; }
            else if (ecat == 21) { ECAT = "Surface service vehicle"; }
            else if (ecat == 22) { ECAT = "Fixed ground or tethered obstruction"; }
            else if (ecat == 23) { ECAT = "Cluster obstacle"; }
            else if (ecat == 24) { ECAT = "Line obstacle"; }

            emitter_category = ECAT;
            int next_octet = octet + 1;
            return next_octet;
        }

        // FRN 31 --> MAR
        public int Find_Met_Information(string[] missatge, int octet)
        {
            // VARIABLE LENGTH

            string myMissatge = missatge[octet];
            int next_octet = octet + 1;

            string ws = myMissatge.Substring(0, 1); // wind speed
            if (ws == "1")
            {
                string windspeed = String.Concat(missatge[next_octet], missatge[next_octet + 1]);
                windspeed = "Wind speed: " + Convert.ToString(Convert.ToInt32(windspeed, 2)) + "kts";
                met_information = windspeed;
                next_octet = next_octet + 2;
            }

            string wd = myMissatge.Substring(1, 1);
            if (wd == "1")
            {
                string winddirection = String.Concat(missatge[next_octet], missatge[next_octet + 1]);
                winddirection = "Wind direction: " + Convert.ToString(Convert.ToInt32(winddirection, 2)) + "º";
                met_information = met_information + ";" + winddirection;
                next_octet = next_octet + 2;
            }

            string tmp = myMissatge.Substring(2, 1);
            if (tmp == "1")
            {
                string temperature = String.Concat(missatge[next_octet], missatge[next_octet + 1]);
                temperature = Convert.ToString(Useful.A2Complement(temperature) * 0.25);
                temperature = "Temperature: " + temperature + "º";
                met_information = met_information + ";" + temperature;
                next_octet = next_octet + 2;
            }

            string trb = myMissatge.Substring(3, 1);
            if (trb == "1")
            {
                string turbulence = missatge[next_octet];
                turbulence = "Turbulence: " + Convert.ToString(Convert.ToInt32(turbulence, 2));
                met_information = met_information + ";" + turbulence;
                next_octet = next_octet + 1;
            }
            return next_octet;
        }

        // FRN 32 --> ANDREU
        public int Find_Selected_Altitude(string[] missatge, int octet)
        {
            string SAS = missatge[octet].Substring(0, 1);
            string SOURCE = missatge[octet].Substring(1, 2);
            string sas, source;
            string altitude_bits = string.Concat(missatge[octet].Substring(3, 5), missatge[octet + 1].Substring(0, 8));

            string altitude = Convert.ToString(Useful.A2Complement(altitude_bits) * 25);

            if (SAS == "0")
                sas = ";SAS: No source information provided;";
            else
                sas = "";
            //sas = "Source information provided";


            if (SOURCE == "00")
                source = "Unknown";
            else if (SOURCE == "01")
                source = "Aircraft Altitude (Holding Altitude)";
            else if (SOURCE == "10")
                source = "MCP/FCU Selected Altitude";
            else
                source = "FMS Selected Altitude";

            selected_altitude = string.Concat(altitude, ";Source: ", source, sas);

            return octet + 2;
        }

        // FRN 33 --> MAR
        string MV; string AH; string AM; string Altitude;
        public int Find_Final_State_Selected_Altitude(string[] missatge, int octet)
        {
            // LENGTH FIXED : 2 OCTET

            string myMissatge = String.Concat(missatge[octet], missatge[octet + 1]);

            string mv = myMissatge.Substring(0, 1); //Manage Vertical Mode
            if (MV == "0") { MV = "Not active or unknown"; }
            else { MV = "Active"; }

            string ah = myMissatge.Substring(1, 1); //Altitude Hold Mode
            if (ah == "0") { AH = "Not active or unknown"; }
            else { AH = "Active"; }

            string am = myMissatge.Substring(2, 1); //Approach Mode
            if (am == "0") { AM = "Not active or unknown"; }
            else { AM = "Active"; }

            string Altitude = myMissatge.Substring(3, 13);
            double alt = Useful.A2Complement(Altitude) * 25;
            Altitude = Convert.ToString(alt);

            final_state_selected_altitude = "Manage Vertical Mode: " + MV + "; Altitude Hold Mode: " + AH + "; Approach Mode: " + AM + "; Altitude: " + Altitude + "ft";

            int next_octet = octet + 2;
            return next_octet;
        }

        // FRN 34
        public int Find_Trajectory_Intent(string[] missatge, int octet)
        {
            string TIS = missatge[octet].Substring(0, 1);
            string TID = missatge[octet].Substring(1, 1);
            string fx1 = missatge[octet].Substring(7, 1);
            octet++;
            string fx2 = missatge[octet].Substring(7, 1);
            string REP = "", TCA = "", NC = "", TCP_number = "", altitude = "", lat = "", lon = "", TD = "", TRA = "", TOA = "", TOV = "", TTR = "";
            int POINT_TYPE;
            string NAV = missatge[octet].Substring(0, 1);
            string NVB = missatge[octet].Substring(1, 1);
            string nav = "", nvb = "";
            string tca = "", nc = "", point_type = "", td = "", tra = "", toa = "";

            bool subfield2 = false;

            if (fx1 == "1")
            {
                if (TIS == "1")
                {
                    if (NAV == "0")
                        nav = "Trajectory Intent Data is available for this aircraft";
                    else
                        nav = "Trajectory Intent Data is not available for this aircraft";

                    if (NVB == "0")
                        nvb = "Trajectory Intent Data is valid";
                    else
                        nvb = "Trajectory Intent Data is not valid";

                    if (fx2 == "1")
                    {
                        subfield2 = true;
                    }


                }
                if (TID == "1")
                {
                    subfield2 = true;
                }
            }


            if (subfield2 == true)
            {
                REP = Convert.ToInt32(missatge[octet + 1].Substring(0, 8), 2).ToString();

                TCA = missatge[octet + 2].Substring(0, 1);

                NC = missatge[octet + 2].Substring(1, 1);

                TCP_number = Convert.ToInt32(missatge[octet + 2].Substring(2, 6), 2).ToString();

                string altitude_bits = string.Concat(missatge[octet + 3].Substring(0, 8), missatge[octet + 4].Substring(0, 8));
                altitude = Convert.ToString(Convert.ToInt32(altitude_bits) * 10);

                string lat_bits = string.Concat(missatge[octet + 5].Substring(0, 8), missatge[octet + 6].Substring(0, 8), missatge[octet + 7].Substring(0, 8));
                lat = Convert.ToString(Useful.A2Complement(lat_bits) * (180 / Math.Pow(2, 23)));

                string lon_bits = string.Concat(missatge[octet + 8].Substring(0, 8), missatge[octet + 9].Substring(0, 8), missatge[octet + 10].Substring(0, 8));
                lon = Convert.ToString(Useful.A2Complement(lon_bits) * (180 / Math.Pow(2, 23)));

                POINT_TYPE = Convert.ToInt32(missatge[octet + 11].Substring(0, 4), 2);
                point_type = Convert.ToString(POINT_TYPE);

                TD = missatge[octet + 11].Substring(4, 2);

                TRA = missatge[octet + 11].Substring(6, 1);

                TOA = missatge[octet + 11].Substring(7, 1);

                TOV = Convert.ToInt32(string.Concat(missatge[octet + 12].Substring(0, 8), missatge[octet + 13].Substring(0, 8), missatge[octet + 14].Substring(0, 8)), 2).ToString();

                string TTR_bits = string.Concat(missatge[octet + 15].Substring(0, 8), missatge[octet + 16].Substring(0, 8));
                TTR = Convert.ToString(Convert.ToDouble(Convert.ToInt32(TTR_bits, 2)) * 0.01);

                if (TCA == "0")
                    tca = "TCP number available";
                else
                    tca = "TCP number not available";

                if (NC == "0")
                    nc = "TCP compliance";
                else
                    nc = "TCP non-compliance";

                switch (POINT_TYPE)
                {
                    case 1:
                        point_type = "Fly by waypoint (LT)";
                        break;
                    case 2:
                        point_type = "Fly over waypoint (LT)";
                        break;
                    case 3:
                        point_type = "Hold pattern (LT)";
                        break;
                    case 4:
                        point_type = "Procedure hold (LT)";
                        break;
                    case 5:
                        point_type = "Procedure turn (LT)";
                        break;
                    case 6:
                        point_type = "RF leg (LT)";
                        break;
                    case 7:
                        point_type = "Top of climb (VT)";
                        break;
                    case 8:
                        point_type = "Top of descent (VT)";
                        break;
                    case 9:
                        point_type = "Start of level (VT)";
                        break;
                    case 10:
                        point_type = "Cross-over altitude (VT)";
                        break;
                    case 11:
                        point_type = "Transition altitude (VT)";
                        break;
                    default:
                        point_type = "Unknown";
                        break;

                }

                if (TD == "00")
                    td = "N/A";
                else if (TD == "01")
                    td = "Turn right";
                else if (TD == "10")
                    td = "Turn left";
                else
                    td = "No turn";

                if (TRA == "0")
                    tra = "TTR not available";
                else
                    tra = "TTR available";

                if (TOA == "0")
                    toa = "TOV available";
                else
                    toa = "TOV not available";
            }

            trajectory_intend = string.Concat(nav, ";", nvb, ";", REP, ";", tca, ";", nc, ";", TCP_number, ";", altitude, ";", lat, ";", lon, ";", point_type, ";", td, ";", tra, ";", toa, ";", TOV, ";", TTR);

            return octet + 16;
        }

        // FRN 35 --> MAR
        string RP;
        public int Find_Service_Management(string[] missatge, int octet)
        {
            // FIXED LENGTH:  1 OCTET
            RP = Convert.ToString(Convert.ToDouble(Convert.ToInt32(missatge[octet], 2)) * 0.5);

            if (RP == "0") { service_management = "0: Data driven mode"; }
            else { service_management = RP + "sec"; }

            int next_octet = octet + 1;
            return next_octet;
        }

        // FRN 36 --> ANDREU
        public int Find_Aircraft_Operational_Status(string[] missatge, int octet)
        {
            string RA = missatge[octet].Substring(0, 1);
            int TC = Convert.ToInt32(missatge[octet].Substring(1, 2), 2);
            string TS = missatge[octet].Substring(3, 1);
            string ARV = missatge[octet].Substring(4, 1);
            string CDTI_A = missatge[octet].Substring(5, 1);
            string NOT_TCAS = missatge[octet].Substring(6, 1);
            string SA = missatge[octet].Substring(7, 1);

            string ra, tc, ts, arv, cdti_a, not_tcas, sa;

            if (RA == "1")
                ra = "TCAS RA active";
            else
                ra = "TCAS II or ACAS RA not active";

            if (TC == 0)
                tc = "no capability for Trajectory Change Reports";
            else if (TC == 1)
                tc = "support for TC+0 reports only";
            else if (TC == 2)
                tc = "support for multiple TC reports";
            else
                tc = "reserved";

            if (TS == "1")
                ts = "capable of supporting target State Reports";
            else
                ts = "no capability to support Target State Reports";

            if (ARV == "1")
                arv = "capable of generate ARV-reports";
            else
                arv = "no capability to generate ARV-reports";

            if (CDTI_A == "1")
                cdti_a = "CDTI operational";
            else
                cdti_a = "CDTI not operational";

            if (NOT_TCAS == "1")
                not_tcas = "TCAS not operational";
            else
                not_tcas = "TCAS operational";

            if (SA == "1")
                sa = "Single Antenna only";
            else
                sa = "Antenna Diversity";

            aircraft_operational_status = string.Concat(ra, ";", tc, ";", ts, ";", arv, ";", cdti_a, ";", not_tcas, ";", sa);

            return octet + 1;
        }

        // FRN 37 --> MAR
        string POA; string CDTIS; string B2low; string RAS; string IDENT; string LW;
        public int Find_Surface_Capabilities_And_Characteristics(string[] missatge, int octet)
        {
            //VARIABLE LENGTH

            string myMissatge = missatge[octet];

            string poa = myMissatge.Substring(2, 1); //Position Offset Applied
            if (poa == "0") { POA = "Position transmitted is not ADS-B position reference point"; }
            else { POA = "Position transmitted is the ADS-B position reference point"; }

            string cdtis = myMissatge.Substring(3, 1); //Cockpit Display of Traffic Information
            if (cdtis == "0") { CDTIS = "CDTI not operational"; }
            else { POA = "CDTI operational"; }

            string b2low = myMissatge.Substring(4, 1); //Class B2 transmit power less than 70 Watts
            if (b2low == "0") { B2low = "≥ 70 Watts"; }
            else { B2low = "< 70 Watts"; }

            string ras = myMissatge.Substring(5, 1); //Receiving ATC Services
            if (ras == "0") { RAS = "Aircraft not receiving ATC-services"; }
            else { RAS = "Aircraft receiving ATC services"; }

            string ident = myMissatge.Substring(6, 1); //Setting of “IDENT”-switch
            if (ident == "0") { IDENT = "IDENT switch not active"; }
            else { IDENT = "IDENT switch active"; }

            string surface_capabilities_characteristics = "POA: " + POA + "; CDTI/S: " + CDTIS + "; B2 low: " + B2low + "; RAS: " + RAS + "; IDENT: " + IDENT;

            string fx = myMissatge.Substring(7, 1);
            int next_octet = octet + 1;

            if (fx == "1")
            {
                int lw = Convert.ToInt32(missatge[octet + 1].Substring(4, 4), 2);

                if (lw == 0) { LW = "Lenght<15m and Width<11.5m"; }
                else if (lw == 1) { LW = "Lenght<15m  and Width<23m"; }
                else if (lw == 2) { LW = "Lenght<25m  and Width<28.5m"; }
                else if (lw == 3) { LW = "Lenght<25m  and Width<34m"; }
                else if (lw == 4) { LW = "Lenght<35m  and Width<33m"; }
                else if (lw == 5) { LW = "Lenght<35m  and Width<38m"; }
                else if (lw == 6) { LW = "Lenght<45m  and Width<39.5m"; }
                else if (lw == 7) { LW = "Lenght<45m  and Width<45m"; }
                else if (lw == 8) { LW = "Lenght<55m  and Width<45m"; }
                else if (lw == 9) { LW = "Lenght<55m  and Width<52m"; }
                else if (lw == 10) { LW = "Lenght<65m  and Width<59.5m"; }
                else if (lw == 11) { LW = "Lenght<65m  and Width<67m"; }
                else if (lw == 12) { LW = "Lenght<75m  and Width<72.5m"; }
                else if (lw == 13) { LW = "Lenght<75m  and Width<80m"; }
                else if (lw == 14) { LW = "Lenght<85m  and Width<80m"; }
                else if (lw == 15) { LW = "(version1) Lenght<85m  and Width>80m ; (version2) Lenght>85m  and Width>80m "; }

                next_octet = next_octet + 1;
                surface_capabilities_characteristics = surface_capabilities_characteristics + "; Length and Width: " + LW;
            }
            return next_octet;
        }

        // FRN 38 --> ANDREU
        public int Find_Message_Amplitude(string[] missatge, int octet)
        {
            double MAM = Useful.A2Complement(missatge[octet].Substring(0, 8));
            message_amplitude = MAM.ToString() + " dBm";
            return octet + 1;
        }

        // FRN 39 --> ANDREU --> no sé com està codificat el missatge. ho deixo en bits (el mateix per cat10)
        public int Find_Mode_S(string[] missatge, int octet)
        {
            string REP = Convert.ToString(Convert.ToInt32(missatge[octet].Substring(0, 8), 2));
            string mode_s_bits = string.Concat(missatge[octet + 1].Substring(0, 8), missatge[octet + 2].Substring(0, 8), missatge[octet + 3].Substring(0, 8), missatge[octet + 4].Substring(0, 8), missatge[octet + 5].Substring(0, 8), missatge[octet + 6].Substring(0, 8), missatge[octet + 7].Substring(0, 8));
            string BDS1 = Convert.ToString(Convert.ToInt32(missatge[octet + 8].Substring(0, 4), 2));
            string BDS2 = Convert.ToString(Convert.ToInt32(missatge[octet + 8].Substring(4, 4), 2));

            mode_s = string.Concat(REP, ";", mode_s_bits, ";", BDS1, ";", BDS2);

            return octet + 9;
        }

        // FRN 40 --> MAR ///NO ME QUEDA CLARO COMO HAN DE SALIR LOS BITS
        string TYP; string STYP; string ARA; string RAC; string RAT; string MTE; string TTI; string TID;
        public int Find_ACAS_Resolution_Advisory_Report(string[] missatge, int octet)
        {
            // 7 octet fixed data legth

            string myMissatge = string.Concat(missatge[octet], missatge[octet + 1], missatge[octet + 2], missatge[octet + 3], missatge[octet + 4], missatge[octet + 5], missatge[octet + 6]);
            TYP = Convert.ToString(Convert.ToInt32(myMissatge.Substring(0, 5), 2));
            TYP = "Message Type" + TYP;
            STYP = Convert.ToString(Convert.ToInt32(myMissatge.Substring(5, 3), 2));
            STYP = "Message Sub-type" + STYP;
            ARA = Convert.ToString(Convert.ToInt32(myMissatge.Substring(8, 14), 2));
            ARA = "Active Resolution Advisories" + ARA;
            RAC = Convert.ToString(Convert.ToInt32(myMissatge.Substring(22, 4), 2));
            RAC = "RAC (RA Complement) Record" + RAC;
            RAT = Convert.ToString(Convert.ToInt32(myMissatge.Substring(26, 1), 2));
            RAT = "RA Terminated" + RAT;
            MTE = Convert.ToString(Convert.ToInt32(myMissatge.Substring(27, 1), 2));
            MTE = "Multiple Threat Encounter" + MTE;
            TTI = Convert.ToString(Convert.ToInt32(myMissatge.Substring(28, 2), 2));
            TTI = "Threat Type Indicator" + TTI;
            //DUDA
            TID = Convert.ToString(Convert.ToInt32(myMissatge.Substring(30, 26), 2));
            TID = "Threat Identity Data" + TID;

            ACAS_resolution_advisory_report = TYP + ";" + STYP + ";" + ARA + ";" + RAC + ";" + RAT + ";" + MTE + ";" + TTI + ";" + TID;
            int next_octet = octet + 7;
            return next_octet;
        }

        // FRN 41 --> MAR
        public int Find_Receiver_ID(string[] missatge, int octet)
        {
            // FIXED LENGTH 1 OCTET

            string myMissatge = missatge[octet];
            receiver_id = Convert.ToString(Convert.ToInt32(myMissatge, 2));

            int next_octet = octet + 1;
            return next_octet;
        }

        // FRN 42 --> ANDREU
        public int Find_Data_Ages(string[] missatge, int octet)
        {
            data_ages = "";
            int next_octet = 0;
            string aos = "", trd = "", m3a = "", qi = "", ti = "", mam = "", gh = "", fl = "", isa = "", fsa = "";
            string aass = "", tas = "", mh = "", bvr = "", gvr = "", gv = "", tar = "", tid = "";
            string ts = "", met = "", roa = "", ara = "", scc = "";

            int AOS = Convert.ToInt32(missatge[octet].Substring(0, 1));
            int TRD = Convert.ToInt32(missatge[octet].Substring(1, 1));
            int M3A = Convert.ToInt32(missatge[octet].Substring(2, 1));
            int QI = Convert.ToInt32(missatge[octet].Substring(3, 1));
            int TI = Convert.ToInt32(missatge[octet].Substring(4, 1));
            int MAM = Convert.ToInt32(missatge[octet].Substring(5, 1));
            int GH = Convert.ToInt32(missatge[octet].Substring(6, 1));

            if (AOS == 1)
            {
                data_ages = data_ages + "AOS,\n ";
            }

            if (TRD == 1)
            {
                data_ages = data_ages + "TRD,\n ";
            }

            if (M3A == 1)
            {
                data_ages = data_ages + "M3A,\n ";
            }

            if (QI == 1)
            {
                data_ages = data_ages + "QI,\n ";
            }

            if (TI == 1)
            {
                data_ages = data_ages + "TI,\n ";
            }

            if (MAM == 1)
            {
                data_ages = data_ages + "MAM,\n ";
            }

            if (GH == 1)
            {
                data_ages = data_ages + "GH,\n ";
            }

            next_octet++;

            if (missatge[octet].Substring(7, 1) == "1")
            {
                int FL = Convert.ToInt32(missatge[octet + 1].Substring(0, 1));
                int ISA = Convert.ToInt32(missatge[octet + 1].Substring(1, 1));
                int FSA = Convert.ToInt32(missatge[octet + 1].Substring(2, 1));
                int AS = Convert.ToInt32(missatge[octet + 1].Substring(3, 1));
                int TAS = Convert.ToInt32(missatge[octet + 1].Substring(4, 1));
                int MH = Convert.ToInt32(missatge[octet + 1].Substring(5, 1));
                int BVR = Convert.ToInt32(missatge[octet + 1].Substring(6, 1));

                if (FL == 1)
                {
                    data_ages = data_ages + "FL, ";
                }

                if (ISA == 1)
                {
                    data_ages = data_ages + "ISA, ";
                }

                if (FSA == 1)
                {
                    data_ages = data_ages + "FSA, ";
                }

                if (AS == 1)
                {
                    data_ages = data_ages + "AS, ";
                }

                if (TAS == 1)
                {
                    data_ages = data_ages + "TAS, ";
                }

                if (MH == 1)
                {
                    data_ages = data_ages + "MH, ";
                }

                if (BVR == 1)
                {
                    data_ages = data_ages + "BVR, ";
                }

                next_octet++;

                if (missatge[octet + 1].Substring(7, 1) == "1")
                {
                    int GVR = Convert.ToInt32(missatge[octet + 2].Substring(0, 1));
                    int GV = Convert.ToInt32(missatge[octet + 2].Substring(1, 1));
                    int TAR = Convert.ToInt32(missatge[octet + 2].Substring(2, 1));
                    int TId = Convert.ToInt32(missatge[octet + 2].Substring(3, 1));
                    int TS = Convert.ToInt32(missatge[octet + 2].Substring(4, 1));
                    int MET = Convert.ToInt32(missatge[octet + 2].Substring(5, 1));
                    int ROA = Convert.ToInt32(missatge[octet + 2].Substring(6, 1));

                    if (GVR == 1)
                    {
                        data_ages = data_ages + "GVR, ";
                    }

                    if (GV == 1)
                    {
                        data_ages = data_ages + "GV, ";
                    }

                    if (TAR == 1)
                    {
                        data_ages = data_ages + "TAR, ";
                    }

                    if (TId == 1)
                    {
                        data_ages = data_ages + "TId, ";
                    }

                    if (TS == 1)
                    {
                        data_ages = data_ages + "TS, ";
                    }

                    if (MET == 1)
                    {
                        data_ages = data_ages + "MET, ";
                    }

                    if (ROA == 1)
                    {
                        data_ages = data_ages + "ROA, ";
                    }

                    next_octet++;

                    if (missatge[octet + 2].Substring(7, 1) == "1")
                    {
                        int ARA = Convert.ToInt32(missatge[octet + 3].Substring(0, 1));
                        int SCC = Convert.ToInt32(missatge[octet + 3].Substring(1, 1));

                        if (ARA == 1)
                        {
                            data_ages = data_ages + "ARA, ";
                        }

                        if (SCC == 1)
                        {
                            data_ages = data_ages + "SCC, ";
                        }

                        next_octet++;

                        if (missatge[octet + 3].Substring(7, 1) == "1")
                        {
                            data_ages = data_ages + ";";
                            if (AOS == 1)
                            {
                                aos = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "AOS: " + aos;
                                next_octet++;
                            }

                            if (TRD == 1)
                            {
                                trd = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "TRD: " + trd;
                                next_octet++;
                            }

                            if (M3A == 1)
                            {
                                m3a = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "M3A: " + m3a;
                                next_octet++;
                            }

                            if (QI == 1)
                            {
                                qi = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "QI: " + qi;
                                next_octet++;
                            }

                            if (TI == 1)
                            {
                                ti = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "TI: " + ti;
                                next_octet++;
                            }

                            if (MAM == 1)
                            {
                                mam = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "MAM: " + mam;
                                next_octet++;
                            }

                            if (GH == 1)
                            {
                                gh = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "GH: " + gh;
                                next_octet++;
                            }

                            if (FL == 1)
                            {
                                fl = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "FL: " + fl;
                                next_octet++;
                            }

                            if (ISA == 1)
                            {
                                isa = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "ISA: " + isa;
                                next_octet++;
                            }

                            if (FSA == 1)
                            {
                                fsa = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "FSA: " + fsa;
                                next_octet++;
                            }

                            if (AS == 1)
                            {
                                aass = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "AS: " + aass;
                                next_octet++;
                            }

                            if (TAS == 1)
                            {
                                tas = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "TAS: " + tas;
                                next_octet++;
                            }

                            if (MH == 1)
                            {
                                mh = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "MH: " + mh;
                                next_octet++;
                            }

                            if (BVR == 1)
                            {
                                bvr = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "BVR: " + bvr;
                                next_octet++;
                            }

                            if (GVR == 1)
                            {
                                gvr = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "GVR: " + gvr;
                                next_octet++;
                            }

                            if (GV == 1)
                            {
                                gv = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "GV: " + gv;
                                next_octet++;
                            }

                            if (TAR == 1)
                            {
                                tar = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "TAR: " + tar;
                                next_octet++;
                            }

                            if (TId == 1)
                            {
                                tid = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "TId: " + tid;
                                next_octet++;
                            }

                            if (TS == 1)
                            {
                                ts = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "TS: " + ts;
                                next_octet++;
                            }

                            if (MET == 1)
                            {
                                met = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "MET: " + met;
                                next_octet++;
                            }

                            if (ROA == 1)
                            {
                                roa = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "ROA: " + roa;
                                next_octet++;
                            }

                            if (ARA == 1)
                            {
                                ara = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "ARA: " + ara;
                                next_octet++;
                            }

                            if (SCC == 1)
                            {
                                scc = Convert.ToString(0.1 * Convert.ToDouble(Convert.ToInt32(missatge[octet + next_octet].Substring(0, 8), 2)));
                                data_ages = data_ages + "SCC: " + scc;
                                next_octet++;
                            }
                        }
                    }
                }
            }

            return octet + next_octet + 1;
        }
    }
}

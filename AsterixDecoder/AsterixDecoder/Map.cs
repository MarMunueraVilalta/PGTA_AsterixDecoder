using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using System.Runtime.Serialization;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET.ObjectModel;
using GMapMarker = GMap.NET.WindowsForms.GMapMarker;
using GMap.NET.MapProviders;

namespace AsterixDecoder
{
    public partial class Map : Form
    {
        DateTime time = new DateTime();
        DateTime time_to = new DateTime();
        MySqlConnection myConnection;
        int tick = 0;
        MapUtils map_form;
        GMapOverlay Gmarkers = new GMapOverlay("markers");
        int one_second_counter_SMR = 0;
        int one_second_counter_ADS_B = 0;
        int one_second_counter_MLAT = 0;
        string received_time;
        bool SMR_loaded = false;
        bool MLAT_loaded = false;
        bool ADS_B_loaded = false;
        LoadFile f_m;

        bool ticking = false;

        List<Markers> list_markers_ADS_B;
        List<GMarkerGoogle> list_Gmarkers_ADS_B;
        List<Markers> list_markers_SMR;
        List<GMarkerGoogle> list_Gmarkers_SMR;
        List<Markers> list_markers_MLAT;
        List<GMarkerGoogle> list_Gmarkers_MLAT;

        private GMapOverlay markerOverlay;

        public Map()
        {
            InitializeComponent();
            play_btn.Visible = true;
            pause_btn.Visible = false;
            stop_btn.Visible = false;
            resume_btn.Visible = false;
        }

        public void setLoadFile(LoadFile loadfile)
        {
            f_m = loadfile;
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {
            Map f_m = new Map();
            this.Hide();
            f_m.ShowDialog();
            this.Close();
        }

        private void buttonLoadDecoder_Click(object sender, EventArgs e)
        {
            Table_form f_tf = new Table_form();
            this.Hide();
            f_tf.ShowDialog();
            this.Close();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            //gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.Position = new GMap.NET.PointLatLng(41.29754155978781, 2.0838729239265663);

            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 13;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            gMapControl1.ShowCenter = false;
            gMapControl1.IgnoreMarkerOnMouseWheel = true;
        }


        private void play_btn_Click(object sender, EventArgs e)
        { 
            time = dateTimePicker_from.Value;
            tick = 0;

            map_form = new ClassLibrary.MapUtils();
            
            if (checkBox_SMR.Checked == true)
                SMR_loaded = map_form.LoadDataSMR(dateTimePicker_from.Text, dateTimePicker_to.Text);
            if (checkBox_MLAT.Checked == true)
                MLAT_loaded = map_form.LoadDataMLAT(dateTimePicker_from.Text, dateTimePicker_to.Text);
            if (checkBox_ADS_B.Checked == true)
                ADS_B_loaded = map_form.LoadDataADS_B(dateTimePicker_from.Text, dateTimePicker_to.Text);

            string alert_message = "No data for: ";

            if (MLAT_loaded == false && checkBox_MLAT.Checked == true)
            {
                checkBox_MLAT.Checked = false;
                alert_message = alert_message + "MLAT ";
            }
            if (SMR_loaded == false && checkBox_SMR.Checked == true)
            {
                checkBox_SMR.Checked = false;
                alert_message = alert_message + "SMR ";
            }
            if (ADS_B_loaded == false && checkBox_ADS_B.Checked == true)
            {
                checkBox_ADS_B.Checked = false;
                alert_message = alert_message + "ADS-B ";
            }

            // Alert Message Box
            if (alert_message != "No data for: ")
            {
                string title = "Alert Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(alert_message, title, buttons, MessageBoxIcon.Warning);
            }

            list_markers_ADS_B = new List<Markers>();
            list_Gmarkers_ADS_B = new List<GMarkerGoogle>();

            list_markers_SMR = new List<Markers>();
            list_Gmarkers_SMR = new List<GMarkerGoogle>();

            list_markers_MLAT = new List<Markers>();
            list_Gmarkers_MLAT = new List<GMarkerGoogle>();

            markerOverlay = new GMapOverlay("markers");
            gMapControl1.MapProvider = GMapProviders.GoogleMap;

            timer1.Interval = 1000;
            ticking = true;
            play_btn.Visible = false;
            pause_btn.Visible = true;
            stop_btn.Visible = false;
            resume_btn.Visible = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_to = dateTimePicker_to.Value;

            if (checkBox_ADS_B.Checked == true && ADS_B_loaded == true)
            {
                paint_ADS_B();
            }

            if (checkBox_SMR.Checked == true && SMR_loaded == true)
            {
                paint_SMR();
            }

            if (checkBox_MLAT.Checked == true && MLAT_loaded == true)
            {
                paint_MLAT();
            }

            if (time == time_to || ticking == false)
                timer1.Stop();

            dateTimePicker_from.Refresh();
            tick++;
            time = time.AddSeconds(1);
            dateTimePicker_from.Value = time;
        }

        public void CreateMapMarker(PointLatLng point, string tooltip)
        {
            GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.red);
            marker.ToolTipText = tooltip;
            marker.IsVisible = true;
            gMapControl1.Overlays[1].Markers.Add(marker);
            gMapControl1.UpdateMarkerLocalPosition(marker);
        }

        // COORDINATES CONVERSION FUNCTIONS

        // POSICION RADAR SMR (WGS84)
        // 41 17 44 226 N
        // 002 05 42 411 E


        // POSICION DEL ARP LEBL (WGS84)
        // 41 17 49 426 N
        // 002 04 42 410 E

        // FROM CARTESIAN TO WGS84
        public PointLatLng Compute_Pos_WGS84_from_Cartesian_SMR(Point carteisan_position)
        {
            GeoUtils gU = new GeoUtils();

            //RADAR
            // Radar coordinates
            PointLatLng RadarSMR = new PointLatLng(41.297063, 2.078447);
            // PointLatLng --> Coordinates WGS84 
            CoordinatesWGS84 RadarSMR_GeodesicCoord = new CoordinatesWGS84(RadarSMR.Lat * (Math.PI / 180), RadarSMR.Lng * (Math.PI / 180));
            gU.setCenterProjection(RadarSMR_GeodesicCoord);

            //POSITION
            PointLatLng pos = new PointLatLng();
            double X_coordinate = carteisan_position.X;
            double Y_coordinate = carteisan_position.Y;

            // From Point -->  CoordinatesXYZ
            CoordinatesXYZ myCoordinatesXYZ_cartesian = new CoordinatesXYZ(X_coordinate, Y_coordinate, 0);

            //system cartesian --> geocentric cartesian
            CoordinatesXYZ geocentric_coord = gU.change_system_cartesian2geocentric(myCoordinatesXYZ_cartesian);
            // geocentric cartesian --> geodesic
            CoordinatesWGS84 geodesic_coord = gU.change_geocentric2geodesic(geocentric_coord);

            double Latitude_WGS84 = geodesic_coord.Lat * (180 / Math.PI);
            double Longitude_WGS84 = geodesic_coord.Lon * (180 / Math.PI);
            pos.Lat = Latitude_WGS84;
            pos.Lng = Longitude_WGS84;
            return pos;

        }

        public PointLatLng Compute_Pos_WGS84_from_Cartesian_MLAT(Point carteisan_position)
        {
            GeoUtils gU = new GeoUtils();

            //RADAR
            // Radar coordinates
            PointLatLng RadarSMR = new PointLatLng(41.295618, 2.095114);
            // PointLatLng --> Coordinates WGS84 
            CoordinatesWGS84 RadarSMR_GeodesicCoord = new CoordinatesWGS84(RadarSMR.Lat * (Math.PI / 180), RadarSMR.Lng * (Math.PI / 180));
            gU.setCenterProjection(RadarSMR_GeodesicCoord);

            //POSITION
            PointLatLng pos = new PointLatLng();
            double X_coordinate = carteisan_position.X;
            double Y_coordinate = carteisan_position.Y;

            // From Point -->  CoordinatesXYZ
            CoordinatesXYZ myCoordinatesXYZ_cartesian = new CoordinatesXYZ(X_coordinate, Y_coordinate, 0);

            //system cartesian --> geocentric cartesian
            CoordinatesXYZ geocentric_coord = gU.change_system_cartesian2geocentric(myCoordinatesXYZ_cartesian);
            // geocentric cartesian --> geodesic
            CoordinatesWGS84 geodesic_coord = gU.change_geocentric2geodesic(geocentric_coord);

            double Latitude_WGS84 = geodesic_coord.Lat * (180 / Math.PI);
            double Longitude_WGS84 = geodesic_coord.Lon * (180 / Math.PI);
            pos.Lat = Latitude_WGS84;
            pos.Lng = Longitude_WGS84;
            return pos;

        }


        // FROM POLAR TO WGS84
        public PointLatLng Compute_Pos_WGS84_from_Polar_MLAT(CoordinatesPolar polar_position)
        {
            GeoUtils gU = new GeoUtils();

            //RADAR
            // Radar coordinates
            PointLatLng RadarSMR = new PointLatLng(41.295618, 2.095114);
            // PointLatLng --> Coordinates WGS84 
            CoordinatesWGS84 RadarSMR_GeodesicCoord = new CoordinatesWGS84(RadarSMR.Lat * (Math.PI / 180), RadarSMR.Lng * (Math.PI / 180));
            gU.setCenterProjection(RadarSMR_GeodesicCoord);

            //POSITION
            // From spherical --> cartesian  
            CoordinatesXYZ myXYZ_coord = new CoordinatesXYZ();
            myXYZ_coord.X = polar_position.Rho * Math.Cos(polar_position.Elevation) * Math.Sin(polar_position.Theta);
            myXYZ_coord.Y = polar_position.Rho * Math.Cos(polar_position.Elevation) * Math.Cos(polar_position.Theta);
            myXYZ_coord.Z = polar_position.Rho * Math.Sin(polar_position.Elevation);

            //system cartesian --> geocentric cartesian
            CoordinatesXYZ geocentric_coord = gU.change_system_cartesian2geocentric(myXYZ_coord);

            // geocentric cartesian --> geodesic
            CoordinatesWGS84 geodesic_coord = gU.change_geocentric2geodesic(geocentric_coord);

            double Latitude_WGS84 = geodesic_coord.Lat * (180 / Math.PI);
            double Longitude_WGS84 = geodesic_coord.Lon * (180 / Math.PI);

            PointLatLng pos = new PointLatLng();
            pos.Lat = Latitude_WGS84;
            pos.Lng = Longitude_WGS84;
            return pos;
        }

        private void paint_SMR()
        {
            string received_time = map_form.SMR.Rows[one_second_counter_SMR]["Time_of_day"].ToString();
            while (Convert.ToDateTime(dateTimePicker_from.Text) == Convert.ToDateTime(received_time) && map_form.SMR.Rows.Count > (one_second_counter_SMR + 1))
            {
                received_time = map_form.SMR.Rows[one_second_counter_SMR]["Time_of_day"].ToString();
                int[] myxy = map_form.getPositionSMR_cartesian(one_second_counter_SMR);

                // MARKER INFO
                Point p = new Point(myxy[0], myxy[1]);
                PointLatLng latlng = Compute_Pos_WGS84_from_Cartesian_SMR(p);
                double[] latlng_double = { latlng.Lat, latlng.Lng };
                Bitmap bmpMarker = (Bitmap)Image.FromFile("img/plane2.png");
                //string flight_level = map_form.SMR.Rows[one_second_counter]["Flight_Level"].ToString();
                //string Mode_3A = map_form.SMR.Rows[one_second_counter]["Mode_3A_Code"].ToString();
                string Track_Number = map_form.SMR.Rows[one_second_counter_SMR]["Track_Number"].ToString();
                string Target_ID = map_form.SMR.Rows[one_second_counter_SMR]["Target_ID"].ToString();
                string angle = "NO DATA";
                Markers myMarker = new Markers(latlng_double, dateTimePicker_from.Text, bmpMarker, "", "", Track_Number, Target_ID, angle);
                list_markers_SMR.Add(myMarker);

                // MARKER GOOGLE MAP
                GMarkerGoogle marker = new GMarkerGoogle(latlng, bmpMarker);
                marker.ToolTipText = string.Format("Target_ID: {0} \n Track_Number: {1}", Target_ID, Track_Number);
                //marker.ToolTipMode = MarkerTooltipMode.Always;
                list_Gmarkers_SMR.Add(marker);

                one_second_counter_SMR++;
            }
            //markerOverlay.Markers.Clear();
            //gMapControl1.Overlays.Clear();

            for (int i = 0; i < list_Gmarkers_SMR.Count; i++)
            {
                markerOverlay.Markers.Add(list_Gmarkers_SMR[i]);
            }
            //markerOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markerOverlay);
        }
        private void paint_MLAT()
        {
            received_time = map_form.MLAT.Rows[one_second_counter_MLAT]["Time_of_day"].ToString();
            while (Convert.ToDateTime(dateTimePicker_from.Text) == Convert.ToDateTime(received_time) && map_form.MLAT.Rows.Count > (one_second_counter_MLAT + 1))
            {
                received_time = map_form.MLAT.Rows[one_second_counter_MLAT]["Time_of_day"].ToString();
                int[] myxy = map_form.getPositionMLAT_cartesian(one_second_counter_MLAT);

                // MARKER INFO
                Point p = new Point(myxy[0], myxy[1]);
                PointLatLng latlng = Compute_Pos_WGS84_from_Cartesian_MLAT(p);
                double[] latlng_double = { latlng.Lat, latlng.Lng };
                Bitmap bmpMarker = (Bitmap)Image.FromFile("img/plane1.png");
                //string flight_level = map_form.MLAT.Rows[one_second_counter]["Flight_Level"].ToString();
                //string Mode_3A = map_form.MLAT.Rows[one_second_counter]["Mode_3A_Code"].ToString();
                string Track_Number = map_form.MLAT.Rows[one_second_counter_MLAT]["Track_Number"].ToString();
                string Target_ID = map_form.MLAT.Rows[one_second_counter_MLAT]["Target_ID"].ToString();
                string angle = "NO DATA";
                Markers myMarker = new Markers(latlng_double, dateTimePicker_from.Text, bmpMarker, "", "", Track_Number, Target_ID, angle);
                list_markers_MLAT.Add(myMarker);

                // MARKER GOOGLE MAP
                GMarkerGoogle marker = new GMarkerGoogle(latlng, bmpMarker);
                marker.ToolTipText = string.Format("Target_ID: {0} \n Track_Number: {1}", Target_ID, Track_Number);
                //marker.ToolTipMode = MarkerTooltipMode.Always;
                list_Gmarkers_MLAT.Add(marker);

                one_second_counter_MLAT++;
            }
            //markerOverlay.Markers.Clear();
            //gMapControl1.Overlays.Clear();

            for (int i = 0; i < list_Gmarkers_MLAT.Count; i++)
            {
                markerOverlay.Markers.Add(list_Gmarkers_MLAT[i]);
            }
            //markerOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markerOverlay);
        }
        private void paint_ADS_B()
        {
            received_time = map_form.ADS_B.Rows[one_second_counter_ADS_B]["Time_of_Report_Transmission"].ToString();
            while (Convert.ToDateTime(dateTimePicker_from.Text) == Convert.ToDateTime(received_time) && map_form.ADS_B.Rows.Count > (one_second_counter_ADS_B + 1))
            {
                received_time = map_form.ADS_B.Rows[one_second_counter_ADS_B]["Time_of_Report_Transmission"].ToString();
                double[] latlng = map_form.getPositionADS_B(one_second_counter_ADS_B);

                // MARKER INFO
                PointLatLng p = new PointLatLng(latlng[0], latlng[1]);
                Bitmap bmpMarker = (Bitmap)Image.FromFile("img/plane1.png");
                string flight_level = map_form.ADS_B.Rows[one_second_counter_ADS_B]["Flight_Level"].ToString();
                string Mode_3A = map_form.ADS_B.Rows[one_second_counter_ADS_B]["Mode_3A_Code"].ToString();
                string Track_Number = map_form.ADS_B.Rows[one_second_counter_ADS_B]["Track_Number"].ToString();
                string Target_ID = map_form.ADS_B.Rows[one_second_counter_ADS_B]["Target_Identification"].ToString();
                string angle = "NO DATA";
                Markers myMarker = new Markers(latlng, dateTimePicker_from.Text, bmpMarker, flight_level, Mode_3A, Track_Number, Target_ID, angle);
                list_markers_ADS_B.Add(myMarker);

                // MARKER GOOGLE MAP
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(latlng[0], latlng[1]), bmpMarker);
                marker.ToolTipText = string.Format("Target_ID: {0} \n Track_Number: {1}", Target_ID, Track_Number);
                //marker.ToolTipMode = MarkerTooltipMode.Always;
                list_Gmarkers_ADS_B.Add(marker);

                one_second_counter_ADS_B++;
            }

            //markerOverlay.Markers.Clear();
            //gMapControl1.Overlays.Clear();

            for (int i = 0; i < list_Gmarkers_ADS_B.Count; i++)
            {
                markerOverlay.Markers.Add(list_Gmarkers_ADS_B[i]);
            }
            //markerOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void pause_btn_Click(object sender, EventArgs e)
        {
            ticking = false;
            play_btn.Visible = false;
            pause_btn.Visible = false;
            stop_btn.Visible = true;
            resume_btn.Visible = true;
        }

        private void resume_btn_Click(object sender, EventArgs e)
        {
            play_btn.Visible = false;
            pause_btn.Visible = true;
            stop_btn.Visible = false;
            resume_btn.Visible = false;
            ticking = true;
            timer1.Start();
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            play_btn.Visible = true;
            pause_btn.Visible = false;
            stop_btn.Visible = false;
            resume_btn.Visible = false;
            list_Gmarkers_ADS_B.Clear();
            list_Gmarkers_MLAT.Clear();
            list_Gmarkers_SMR.Clear();
            list_markers_ADS_B.Clear();
            list_markers_MLAT.Clear();
            list_markers_SMR.Clear();
            ADS_B_loaded = false;
            SMR_loaded = false;
            MLAT_loaded = false;
            map_form.SMR.Clear();
            map_form.ADS_B.Clear();
            map_form.MLAT.Clear();
            markerOverlay.Markers.Clear();
            gMapControl1.Overlays.Clear();
            one_second_counter_ADS_B = 0;
            one_second_counter_MLAT = 0;
            one_second_counter_SMR = 0;
        }

        private void buttonLoadFile_Click_1(object sender, EventArgs e)
        {
            if (f_m == null)
            {
                f_m = new LoadFile();
                this.Hide();
                f_m.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                f_m.Show();
                this.Close();
            }
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



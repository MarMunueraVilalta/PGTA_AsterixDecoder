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
        int one_second_counter = 0; //posar-ho a zero!! això és provisional

        List<Markers> list_markers_ADS_B;
        List<GMarkerGoogle> list_Gmarkers_ADS_B;
        private GMapOverlay markerOverlay;

        public Map()
        {
            InitializeComponent();
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

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            LoadFile f_lf = new LoadFile();
            this.Hide();
            f_lf.ShowDialog();
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
                map_form.LoadDataSMR(dateTimePicker_from.Text, dateTimePicker_to.Text);
            if (checkBox_MLAT.Checked == true)
                map_form.LoadDataMLAT(dateTimePicker_from.Text, dateTimePicker_to.Text);
            if (checkBox_ADS_B.Checked == true)
                map_form.LoadDataADS_B(dateTimePicker_from.Text, dateTimePicker_to.Text);

            list_markers_ADS_B = new List<Markers>();
            list_Gmarkers_ADS_B = new List<GMarkerGoogle>();

            markerOverlay = new GMapOverlay("markers");
            gMapControl1.MapProvider = GMapProviders.GoogleMap;

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_to = dateTimePicker_to.Value;

            time = time.AddSeconds(1);
            dateTimePicker_from.Value = time;

            if (checkBox_ADS_B.Checked == true)
            {
                string received_time = map_form.ADS_B.Rows[one_second_counter]["Time_of_Report_Transmission"].ToString();
                while (Convert.ToDateTime(dateTimePicker_from.Text) == Convert.ToDateTime(received_time) && map_form.ADS_B.Rows.Count > (one_second_counter+1))
                {
                    received_time = map_form.ADS_B.Rows[one_second_counter]["Time_of_Report_Transmission"].ToString();
                    double[] latlng = map_form.getPositionADS_B(one_second_counter);

                    // MARKER INFO
                    PointLatLng p = new PointLatLng(latlng[0], latlng[1]);
                    Bitmap bmpMarker = (Bitmap)Image.FromFile("img/plane1.png");
                    string flight_level = map_form.ADS_B.Rows[one_second_counter]["Flight_Level"].ToString();
                    string Mode_3A = map_form.ADS_B.Rows[one_second_counter]["Mode_3A_Code"].ToString();
                    string Track_Number = map_form.ADS_B.Rows[one_second_counter]["Track_Number"].ToString();
                    string Target_ID = map_form.ADS_B.Rows[one_second_counter]["Target_Identification"].ToString();
                    string angle = "NO DATA";
                    Markers myMarker = new Markers(latlng, dateTimePicker_from.Text, bmpMarker, flight_level, Mode_3A, Track_Number, Target_ID, angle);
                    list_markers_ADS_B.Add(myMarker);

                    // MARKER GOOGLE MAP
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(latlng[0], latlng[1]),bmpMarker);
                    marker.ToolTipText = string.Format("Target_ID: {0} \n Track_Number: {1}", Target_ID, Track_Number);
                    //marker.ToolTipMode = MarkerTooltipMode.Always;
                    list_Gmarkers_ADS_B.Add(marker);

                    one_second_counter++;
                }

                markerOverlay.Markers.Clear();
                gMapControl1.Overlays.Clear();

                for (int i=0; i < list_Gmarkers_ADS_B.Count; i++) {
                    markerOverlay.Markers.Add(list_Gmarkers_ADS_B[i]);
                }
                //markerOverlay.Markers.Add(marker);
                gMapControl1.Overlays.Add(markerOverlay);
            }

            if (checkBox_SMR.Checked == true)
            {
                string received_time = map_form.SMR.Rows[one_second_counter]["Time_of_day"].ToString();
                while (Convert.ToDateTime(dateTimePicker_from.Text) == Convert.ToDateTime(received_time) && map_form.SMR.Rows.Count > (one_second_counter + 1))
                {
                    received_time = map_form.SMR.Rows[one_second_counter]["Time_of_day"].ToString();
                    int[] myxy = map_form.getPositionSMR_cartesian(one_second_counter);

                    // MARKER INFO
                    Point p = new Point(myxy[0], myxy[1]);
                    PointLatLng latlng = Compute_Pos_WGS84_from_Cartesian_SMR(p);
                    double[] latlng_double = {latlng.Lat,latlng.Lng};
                    Bitmap bmpMarker = (Bitmap)Image.FromFile("img/plane1.png");
                    //string flight_level = map_form.SMR.Rows[one_second_counter]["Flight_Level"].ToString();
                    //string Mode_3A = map_form.SMR.Rows[one_second_counter]["Mode_3A_Code"].ToString();
                    string Track_Number = map_form.SMR.Rows[one_second_counter]["Track_Number"].ToString();
                    string Target_ID = map_form.SMR.Rows[one_second_counter]["Target_ID"].ToString();
                    string angle = "NO DATA";
                    Markers myMarker = new Markers(latlng_double, dateTimePicker_from.Text, bmpMarker, "", "", Track_Number, Target_ID, angle);
                    list_markers_ADS_B.Add(myMarker);

                    // MARKER GOOGLE MAP
                    GMarkerGoogle marker = new GMarkerGoogle(latlng, bmpMarker);
                    marker.ToolTipText = string.Format("Target_ID: {0} \n Track_Number: {1}", Target_ID, Track_Number);
                    //marker.ToolTipMode = MarkerTooltipMode.Always;
                    list_Gmarkers_ADS_B.Add(marker);

                    one_second_counter++;
                }

                markerOverlay.Markers.Clear();
                gMapControl1.Overlays.Clear();

                for (int i = 0; i < list_Gmarkers_ADS_B.Count; i++)
                {
                    markerOverlay.Markers.Add(list_Gmarkers_ADS_B[i]);
                }
                //markerOverlay.Markers.Add(marker);
                gMapControl1.Overlays.Add(markerOverlay);
            }


            if (time == time_to)
                timer1.Stop();

            dateTimePicker_from.Refresh();
            tick++;
        }

        //public readonly ObservableCollectionThreadSafe<GMarkerGoogle> Markers = ObservableCollectionThreadSafe<GMarkerGoogle>;
        private void button1_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            markerOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(41.27794, 1.97033), GMarkerGoogleType.green);
            marker.ToolTipText = string.Format("Gimnazija: \n Latituda: {0} \n     Longituda: {1}", 41.27794, 1.97033);
            markerOverlay.Markers.Add(marker);

            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(41.27900, 1.97033), GMarkerGoogleType.pink);
            markerOverlay.Markers.Add(marker2);

            //marker.ToolTipMode = MarkerTooltipMode.Always;
            marker2.ToolTipText = string.Format("Gimnazija: \n Latituda: {0} \n     Longituda: {1}", 41.27794, 1.97033);
            gMapControl1.Overlays.Add(markerOverlay);

            GMarkerGoogle marker3 = new GMarkerGoogle(new PointLatLng(41.27800, 1.97033), GMarkerGoogleType.blue);
            markerOverlay.Markers.Add(marker3);

            //marker.ToolTipMode = MarkerTooltipMode.Always;
            marker3.ToolTipText = string.Format("Gimnazija: \n Latituda: {0} \n     Longituda: {1}", 41.27794, 1.97033);
            gMapControl1.Overlays.Add(markerOverlay);
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

        private void button2_Click(object sender, EventArgs e)
        {
            map_form = new ClassLibrary.MapUtils();
            map_form.LoadDataADS_B(dateTimePicker_from.Text, dateTimePicker_to.Text);
            list_markers_ADS_B = new List<Markers>();
            list_Gmarkers_ADS_B = new List<GMarkerGoogle>();
            int i = 0;

            
            gMapControl1.MapProvider = GMapProviders.GoogleMap;

            for (int tick = 0; tick < 8; tick++) {
                double[] latlng = map_form.getPositionADS_B(tick);

                // MARKER INFO
                PointLatLng p = new PointLatLng(latlng[0], latlng[1]);
                Bitmap bmpMarker = (Bitmap)Image.FromFile("img/plane.png");
                string flight_level = map_form.ADS_B.Rows[tick]["Flight_Level"].ToString();
                string Mode_3A = map_form.ADS_B.Rows[tick]["Mode_3A_Code"].ToString();
                string Track_Number = map_form.ADS_B.Rows[tick]["Track_Number"].ToString();
                string Target_ID = map_form.ADS_B.Rows[tick]["Target_Identification"].ToString();
                string angle = "NO DATA";
                Markers myMarker = new Markers(latlng, dateTimePicker_from.Text, bmpMarker, flight_level, Mode_3A, Track_Number, Target_ID, angle);
                list_markers_ADS_B.Add(myMarker);

                // MARKER GOOGLE MAP
                markerOverlay = new GMapOverlay("markers");

                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(latlng[0], latlng[1]), GMarkerGoogleType.pink);
                marker.ToolTipText = string.Format("Target_ID: {0} \n Track_Number: {1}", Target_ID, Track_Number);
                //marker.ToolTipMode = MarkerTooltipMode.Always;
                list_Gmarkers_ADS_B.Add(marker);

                i++;
            }

            for (int y = 0; y < list_Gmarkers_ADS_B.Count; y++)
            {
                markerOverlay.Markers.Add(list_Gmarkers_ADS_B[y]);
            }
            //markerOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(markerOverlay);
        }


    }
}



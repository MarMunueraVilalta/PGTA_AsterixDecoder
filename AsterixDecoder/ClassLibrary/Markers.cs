using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows;
using System.Drawing;

namespace ClassLibrary
{
    public class Markers
    {
        double[] coordinates;
        string time;
        Bitmap picture;
        string flight_level;
        string Mode_3A;
        string Track_Number;
        string Target_ID;
        string angle;

        //public Markers(double[] coordinates, string time, string flight_level, string Mode_3A, string Track_Number, string Target_ID, string picture, string angle)
        //{
        //    this.coordinates = coordinates;
        //    this.time = time;
        //    this.flight_level = flight_level;
        //    this.Mode_3A = Mode_3A;
        //    this.Track_Number = Track_Number;
        //    this.Target_ID = Target_ID;
        //    this.picture = picture;
        //    this.angle = angle;
        //}
        public Markers(double[] coordinates, string time, Bitmap picture, string flight_level, string Mode_3A, string Track_Number, string Target_ID, string angle)
        {
            this.coordinates = coordinates;
            this.time = time;
            this.picture = picture;
            this.flight_level = flight_level;
            this.Mode_3A = Mode_3A;
            this.Track_Number = Track_Number;
            this.Target_ID = Target_ID;
            this.angle = angle;
        }


       
    }
}

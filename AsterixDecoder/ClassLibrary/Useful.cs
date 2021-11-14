using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Useful
    {
        static double info_total;
        public static double A2Complement(string info)
        {
            double info_total = 0.0;

            if (Convert.ToString(info[0]) == "0")
            {
                info_total = Convert.ToInt32(info, 2);
            }

            else
            {
                string neg_info = info.Substring(1, info.Length - 1);
                string corrected_info = "";
                int i = 0;
                while (i < neg_info.Length)
                {
                    if (Convert.ToString(neg_info[i]) == "1")
                        corrected_info = corrected_info + "0";
                    if (Convert.ToString(neg_info[i]) == "0")
                        corrected_info = corrected_info + "1";

                    i++;
                }
                info_total = (-1) * (Convert.ToInt32(corrected_info, 2) + 1);
            }
            return info_total;
        }

        public static int IntToOctal(int value)
        {
            //Console.WriteLine("value: " + value.ToString());
            int i = 1;
            int num_octal = 0;

            while (value != 0)
            {
                num_octal = num_octal + (value % 8) * i;
                value = value / 8;
                i *= 10;
            }
            //Console.WriteLine("Num octal: " + num_octal);
            return num_octal;
        }

        public static string Decode_Character(string c)
        {
            int code = Convert.ToInt32(c, 2);
            List<string> code_list = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (code == 0)
                return "";
            else
                return code_list[code - 1];
        }

    }
}

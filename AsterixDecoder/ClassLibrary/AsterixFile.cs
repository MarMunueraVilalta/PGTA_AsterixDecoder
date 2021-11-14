using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class AsterixFile
    {

        public void ReadAsterixFile() // Function to read an Asterix File
        {
            /* Method statements here */
            fromHexToBinary();
        }


        // Separate the file in blocs


        string path;
        string CAT;
        /*List<CAT10> listaCAT10 = new List<CAT10>();
        List<CAT21> listaCAT21 = new List<CAT21>();
        DataTable tablaCAT10 = new DataTable();
        DataTable tablaCAT21 = new DataTable();
        */

        public AsterixFile(string nombre)
        {
            this.path = nombre;
        }

        public string getCAT()
        {
            return this.CAT;
        }


        /*public List<CAT10> getListCAT10()
        {
            return listaCAT10;
        }

        public List<CAT21> getListCAT21()
        {
            return listaCAT21;
        }*/

        public List<string[]> fromHexToBinary()
        {
            //StreamReader fichero = new StreamReader(path);
            //string linea_1 = fichero.ReadLine();
            byte[] fileBytes = File.ReadAllBytes(path);
            List<byte[]> listabyte = new List<byte[]>();
            int i = 0;
            int contador = fileBytes[2];
            //int length = 0;
            CAT = fileBytes[0].ToString("X2");

            while (i < fileBytes.Length)
            {
                byte[] array = new byte[contador];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = fileBytes[i];
                    i++;
                }
                listabyte.Add(array);
                //length += array.Length;
                if (i + 2 < fileBytes.Length)
                {
                    contador = fileBytes[i + 2];
                }
            }

            //Agafa listabyte i ho passa a hexa, que s'emmagatzema a listahex
            //////////////////////////////////////////////////////
            List<string[]> listahex = new List<string[]>();
            for (int x = 0; x < listabyte.Count; x++)
            {
                byte[] buffer = listabyte[x];
                string[] arrayhex = new string[buffer.Length];
                for (int y = 0; y < buffer.Length; y++)
                {
                    arrayhex[y] = Convert.ToString(Convert.ToInt32(buffer[y].ToString("X2"), 16), 2).PadLeft(8, '0');
                }
                listahex.Add(arrayhex);
            }
            return listahex;
            //////////////////////////////////////////////////////

            /*           //Organitza en classes les dades obtingudes
                       //////////////////////////////////////////////////////
                       for (int q = 0; q < listahex.Count; q++)
                       {
                           string[] arraystring = listahex[q];
                           int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber);

                           if (CAT == 10)
                           {
                               CAT10 newcat10 = new CAT10(arraystring);
                               listaCAT10.Add(newcat10);
                           }
                           else if (CAT == 21)
                           {
                               CAT21 newcat21 = new CAT21(arraystring);
                               listaCAT21.Add(newcat21);
                           }
                       }
                       //////////////////////////////////////////////////////*/
        }

        /*public DataTable getTablaCAT10()
        {
            return tablaCAT10;
        }

        public DataTable getTablaCAT21()
        {
            return tablaCAT21;
        }*/
    }

}

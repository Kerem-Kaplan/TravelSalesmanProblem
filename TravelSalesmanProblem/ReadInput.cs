using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSalesmanProblem
{
    public class ReadInput
    {
        public List<Double> GetCoordinateX()    //input dosyalarındaki boşluğa kadar olan kısım
                                                //x olarak tanımlanır ve ona göre okunup diziye atandı.
        {
            
            StreamReader streamReader = new StreamReader("D:/ÜNİVERSİTE/6.DÖNEM/Algoritma Analizi Ve Tasarımı/Ödevler/Ödev-1/uygulama dosyaları/uygulama dosyaları/tsp_5_1");

            string line;

            line = streamReader.ReadLine();

            List<Double> CoordinateX = new List<Double>();

            while (line != null)
            {

                string[] coordinates = line.Split(' ');
                if (coordinates[0].Contains("e"))
                {

                    string[] ContainE = line.Split('e');

                    string[] Numbers = ContainE[1].Split(" ");
                    if (Numbers[0].Contains("+"))
                    {
                        Numbers[0].Replace("+", "");
                    }
                    double number = Convert.ToDouble(Numbers[0]);
                    var DoubleE = Convert.ToDouble(ContainE[0]);
                    var result = (DoubleE * (2.7182)) + number;

                    var coordinateX = Convert.ToDouble(result);

                    CoordinateX.Add(coordinateX);
                }
                else
                {
                    var coordinateX = Convert.ToDouble(coordinates[0]);

                    CoordinateX.Add(coordinateX);
                }

                line = streamReader.ReadLine();
            }

            streamReader.Close();
            return CoordinateX;

        }

        public List<Double> GetCoordinateY()    //input dosyalarındaki boşluktan sonraki kısım y ekseni
                                                //olarak tanımlanır ve diziye atandı
        {
            StreamReader streamReader = new StreamReader("D:/ÜNİVERSİTE/6.DÖNEM/Algoritma Analizi Ve Tasarımı/Ödevler/Ödev-1/uygulama dosyaları/uygulama dosyaları/tsp_5_1");

            string line;

            line = streamReader.ReadLine();

            List<Double> CoordinateY = new List<Double>();

            while (line != null)
            {
                string[] coordinates = line.Split(' ');
                if (coordinates[1].Contains("e"))
                {

                    string[] ContainE = line.Split('e');

                    string[] Numbers = ContainE[1].Split(" ");
                    if (Numbers[0].Contains("+"))
                    {
                        Numbers[0].Replace("+", "");
                    }
                    double number = Convert.ToDouble(Numbers[0]);
                    var DoubleE = Convert.ToDouble(ContainE[0]);
                    var result = (DoubleE * (2.7182)) + number;

                    var coordinateX = Convert.ToDouble(result);

                    CoordinateY.Add(coordinateX);
                }
                else
                {
                    var coordinateX = Convert.ToDouble(coordinates[1]);

                    CoordinateY.Add(coordinateX);
                }
                line = streamReader.ReadLine();
            }

            streamReader.Close();
            return CoordinateY;

        }


    }
}


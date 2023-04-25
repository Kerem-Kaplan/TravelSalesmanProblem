using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSalesmanProblem
{
    public class Solving
    {
        List<Double> CoordinatesX;
        List<Double> CoordinatesY;

        public Solving(List<Double> coordinatesX, List<Double> coordinatesY)
        {
            CoordinatesX = coordinatesX;
            CoordinatesY = coordinatesY;
        }

        private double GetDistance(int City1, int City2)    //iki nokta arası uzaklık hesaplanması
        {
            double City1X = (double)CoordinatesX[City1];
            double City1Y = (double)CoordinatesY[City1];

            double City2X = (double)CoordinatesY[City2];
            double City2Y = (double)CoordinatesY[City2];

            double DifferenceX = City2X - City1X;
            double DifferenceY = City2Y - City1Y;

            var result = Math.Sqrt((DifferenceX * DifferenceX) + (DifferenceY * DifferenceY));

            return result;

        }


        int visitedNumberOfCity = 0;
        public List<double> SolvingTSP(double CityCount)    //inputtaki toplam şehir sayısına göre
                                                            //çalıştırılan fonksiyon
        {

            List<Double> result = new();

            double DistanceCount = 0;

            List<int> VisitedCities = new List<int>();

            double CityNumber = CityCount;
            int CitiesNumber = (int)Math.Floor(CityNumber);

            bool[] visited = new bool[CitiesNumber];


            visited[visitedNumberOfCity] = true;

            VisitedCities.Add(visitedNumberOfCity);

            int CitiesToVisit = CitiesNumber - 1;

            while (CitiesToVisit > 0)
            {
                int lastCity = VisitedCities[VisitedCities.Count - 1];

                int NearestCity = -1;

                double nearestCity = Double.MaxValue;
                for (int i = 0; i < CitiesNumber; i++)
                {
                    if (!visited[i])
                    {
                        double distance = GetDistance(lastCity, i);
                        if (distance < nearestCity)
                        {
                            NearestCity = i;
                            nearestCity = distance;
                        }
                    }

                }
                visited[NearestCity] = true;
                VisitedCities.Add(NearestCity);

                DistanceCount += nearestCity;

                CitiesToVisit--;
            }

            int LastCity = (int)VisitedCities[VisitedCities.Count - 1];
            int StartCity = (int)VisitedCities[visitedNumberOfCity];

            double LastDistance = GetDistance(LastCity, StartCity);

            DistanceCount += LastDistance;

            visitedNumberOfCity++;

            result.Add(DistanceCount);
            for (int i = 0; i < VisitedCities.Count; i++)
            {

                result.Add(VisitedCities[i]);
                visited[i] = false;
            }


            return result;


        }
    }
}

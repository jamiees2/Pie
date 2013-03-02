using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Metric
    {
        public double MM(int mm, string measurement)
        {
            switch (measurement)
            {
                //Milli
                case "cm": //Centi
                    return mm * 10;
                case "d": //Deci
                    return mm * 100;
                case "m": //Meter
                    return mm * 1000;
                case "k": //Kilo
                    return mm * 10000;
                default:
                    return 0;
            }
        }
        public double CM(int cm, string measurement)
        {
            switch (measurement)
            {
                case "mm": //Milli
                    return cm / 10;
                //Centi
                case "d": //Deci
                    return cm * 10;
                case "m": //Meter
                    return cm * 100;
                case "k": //Kilo
                    return cm * 1000;
                default:
                    return 0;
            }
        }
        public double D(int d, string measurement)
        {
            switch (measurement)
            {
                case "mm": //Milli
                    return d / 100;
                case "cm": //Centi
                    return d / 10;
                //Deci
                case "m": //Meter
                    return d * 10;
                case "k": //Kilo
                    return d * 100;
                default:
                    return 0;
            }
        }
        public double M(int m, string measurement)
        {
            switch (measurement)
            {
                case "mm": //Milli
                    return m / 1000;
                case "cm": //Centi
                    return m / 100;
                case "d": //Deci
                    return m / 10;
                //Meter
                case "k": //Kilo
                    return m * 10;
                default:
                    return 0;
            }
        }
        public double K(int k, string measurement)
        {
            switch (measurement)
            {
                case "mm": //Milli
                    return k / 10000;
                case "cm": //Centi
                    return k / 1000;
                case "d": //Deci
                    return k / 100;
                case "m": //Meter
                    return k / 10;
                //Kilo
                case "e"://Ekrar
                    return k * 4046;
                default:
                    return 0;
            }
        }
        public double E(int e, string measurement)
        {
            switch (measurement)
            {
                /*case "mm": //Milli
                    return e / 10000;
                case "cm": //Centi
                    return e / 1000;
                case "d": //Deci
                    return e / 100;
                case "m": //Meter
                    return e / 10;*/
                case "k": //Kilo
                    return e / 4046;
                default:
                    return 0;
            }
        }
    }
}

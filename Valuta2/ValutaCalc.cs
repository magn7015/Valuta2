using System;

namespace Valuta2
{
    public class ValutaCalc
    {
        public static double TilSvenskeKroner(double danskeKroner)
        {
            return danskeKroner / 0.7041;
        }

        public static double TilDanskeKroner(double svenskeKroner)
        {
            return svenskeKroner * 0.7041;
        }
    }
}

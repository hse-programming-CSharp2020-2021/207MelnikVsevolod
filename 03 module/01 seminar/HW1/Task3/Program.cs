using System;

namespace Task3
{
    class TemperatureConvertImp
    {
        static public double CtoF(double c)
        {
            return 9.0 / 5 * c + 32;
        }

        static public double CtoK(double c)
        {
            return c + 273.15;
        }

        static public double CtoR(double c)
        {
            return 1.8 * CtoK(c);
        }

        static public double CtoRe(double c)
        {
            return 0.8 * c;
        }

        static public double FtoC(double c)
        {
            return 5.0 / 9 * (c - 32);
        }

        static public double KtoC(double c)
        {
            return c - 273.15;
        }

        static public double RtoC(double c)
        {
            return KtoC(c / 1.8);
        }

        static public double RetoC(double c)
        {
            return c / 0.8;
        }
    }

    class Program
    {
        delegate double delegateConvertTemperature(double x);

        static void Main(string[] args)
        {
            delegateConvertTemperature[] delConvert = new delegateConvertTemperature[8];
            delConvert[0] = TemperatureConvertImp.CtoK;
            delConvert[1] = TemperatureConvertImp.CtoR;
            delConvert[2] = TemperatureConvertImp.CtoRe;
            delConvert[3] = TemperatureConvertImp.CtoF;
            delConvert[4] = TemperatureConvertImp.KtoC;
            delConvert[5] = TemperatureConvertImp.RtoC;
            delConvert[6] = TemperatureConvertImp.RetoC;
            delConvert[7] = TemperatureConvertImp.FtoC;

            int x = int.Parse(Console.ReadLine());
            for (int i = 0; i < 8; ++i)
                Console.WriteLine(delConvert[i](x));
        }
    }
}

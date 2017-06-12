using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    //класс для обыкновенной дроби

    public class SimpleFraction : Fraction
    {
        private int numerator;//числитель
        private int denominator;//знаменатель

        public int Nominator
        {
            get
            {
                return numerator;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
        }

        public SimpleFraction(int nominator, int denominator)
        {
            this.numerator = nominator;
            this.denominator = denominator;
        }

        public static bool IsValid(string data)//проверка является ли дробь обыкновенной
        {
            return data.Contains("/");
        }

        public SimpleFraction(string data)
        {
            if (IsValid(data))
            {
                numerator = int.Parse(data.Substring(0, data.IndexOf("/")));
                denominator = int.Parse(data.Substring(data.IndexOf("/") + 1, data.Length - data.IndexOf("/") - 1));
            }
            else
            {
                throw new Exception("Не удалось преобразовать в обыкновенную дробь!");
            }
        }

        public DecimalFraction ConvertTo()//преобразование обыкновенной в десятичную
        {
            float val = (float)Nominator / Denominator;

            DecimalFraction decimalFraction = new DecimalFraction(val);

            return decimalFraction;
        }

        public static SimpleFraction operator +(SimpleFraction fr1, SimpleFraction fr2)
        {
            int numerator = fr1.Nominator * fr2.Denominator + fr2.Nominator * fr1.Denominator;
            int denominator = fr1.Denominator * fr2.Denominator;

            SimpleFraction res = new SimpleFraction(numerator, denominator);

            return res;
        }

        public static SimpleFraction operator -(SimpleFraction fr1, SimpleFraction fr2)
        {
            int numerator = fr1.Nominator * fr2.Denominator - fr2.Nominator * fr1.Denominator;
            int denominator = fr1.Denominator * fr2.Denominator;

            SimpleFraction res = new SimpleFraction(numerator, denominator);

            return res;
        }

        public static SimpleFraction operator *(SimpleFraction fr1, SimpleFraction fr2)
        {
            int numerator = fr1.Nominator * fr2.Nominator;
            int denominator = fr1.Denominator * fr2.Denominator;

            SimpleFraction res = new SimpleFraction(numerator, denominator);

            return res;
        }

        public static SimpleFraction operator /(SimpleFraction fr1, SimpleFraction fr2)
        {
            int numerator = fr1.Nominator * fr2.Denominator;
            int denominator = fr1.Denominator * fr2.Nominator;

            SimpleFraction res = new SimpleFraction(numerator, denominator);

            return res;
        }
    }
}

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

        public int Numerator
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

        public SimpleFraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        //public static implicit operator DecimalFraction(SimpleFraction df)
        //{
        //    //float number = sf.Numerator * 0.1F / 0.1F / sf.Denominator;
        //    //DecimalFraction temp = new DecimalFraction(number);
        //    //return temp;

            
        //    //float val = (float)numerator / denominator;

        //    DecimalFraction decimalFraction = new DecimalFraction(val);

        //    return decimalFraction;
        //}

        //public static implicit operator SimpleFraction(float f)
        //{
        //    //float number = f.Nominator * 0.1F / 0.1F / f.Denominator;

        //    float number = (float)Numerator / Denominator;
        //    DecimalFraction temp = new DecimalFraction(f);
        //    return temp;
        //}

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
            double val = (double)Numerator / Denominator;

            DecimalFraction decimalFraction = new DecimalFraction(val);

            return decimalFraction;
        }

        public static SimpleFraction operator +(SimpleFraction fr1, SimpleFraction fr2)
        {
            int numerator = fr1.Numerator * fr2.Denominator + fr2.Numerator * fr1.Denominator;
            int denominator = fr1.Denominator * fr2.Denominator;

            SimpleFraction res = new SimpleFraction(numerator, denominator);

            return res;
        }

        public static SimpleFraction operator -(SimpleFraction fr1, SimpleFraction fr2)
        {
            int numerator = fr1.Numerator * fr2.Denominator - fr2.Numerator * fr1.Denominator;
            int denominator = fr1.Denominator * fr2.Denominator;

            SimpleFraction res = new SimpleFraction(numerator, denominator);

            return res;
        }

        public static SimpleFraction operator *(SimpleFraction fr1, SimpleFraction fr2)
        {
            int numerator = fr1.Numerator * fr2.Numerator;
            int denominator = fr1.Denominator * fr2.Denominator;

            SimpleFraction res = new SimpleFraction(numerator, denominator);

            return res;
        }

        public static SimpleFraction operator /(SimpleFraction fr1, SimpleFraction fr2)
        {
            int numerator = fr1.Numerator * fr2.Denominator;
            int denominator = fr1.Denominator * fr2.Numerator;

            SimpleFraction res = new SimpleFraction(numerator, denominator);

            return res;
        }


        public override string ToString() //метод для вывода дроби
        {
            // Console.Write(name + " = ");
            string temp = "";
            int absNum = Math.Abs(numerator);
            int absDenum = Math.Abs(denominator);

            if (numerator == 0) //дробь равна 0
            {
                //Console.WriteLine(0);
                temp = "0";
                return temp;
            }

            //отрицательная дробь
            if (numerator * denominator < 0) //Console.Write("-");
                temp = temp + "-";

            //дробь сокращается
            if (absNum % absDenum == 0)
            {
                // Console.WriteLine(absNum / absDenum);
                int number = absNum / absDenum;
                temp = temp + number.ToString();
                return temp;
            }

            //числитель меньше знаменателя => целой части нет
            if (absNum < absDenum)
            {
                // Console.WriteLine(absNum + "/" + absDenum);
                temp = absNum.ToString() + "/" + absDenum.ToString();
                return temp;
            }

            //числитель больше знаменателя => целая часть есть

            //   Console.WriteLine((absNum / absDenum) + " " + (absNum % absDenum) + "/" + absDenum);
            temp = (absNum / absDenum) + " " + (absNum % absDenum) + "/" + absDenum;
            return temp;
        }
    }
}

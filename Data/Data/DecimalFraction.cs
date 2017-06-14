using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    //класс для десятичной дроби
    public class DecimalFraction : Fraction 
    {
        private double value;//сама десятичная дробь
        private int countSigns; //кол-во знаков после запятой

        public double Value
        {
            get
            {
                return value;
            }
        }

        public DecimalFraction(double value)//если на вход подана дробь
        {
            this.value = value;

            //считаем количество знаков после запятой
            countSigns = Value.ToString().Substring(Value.ToString().IndexOf(",") + 1).Length;

            //if (countSigns > 15)
            //    throw new Exception("Слишком много знаков после запятой!");
        }

        public DecimalFraction(string data)//если на вход подана строка
        {
            if (IsValid(data))
            {
                data = data.Replace(".", ",");
                value = float.Parse(data);
                DecimalFraction s = (DecimalFraction)value;
                //value = float.Parse(data);
            }
        }

        public static implicit operator DecimalFraction(SimpleFraction sf)
        {
            double number = sf.Numerator * 0.1 / 0.1 / sf.Denominator;
            DecimalFraction temp = new DecimalFraction(number);
            return temp;
        }

        public static implicit operator DecimalFraction(double f)
        {
            //float number = f.Nominator * 0.1F / 0.1F / f.Denominator;
            DecimalFraction temp = new DecimalFraction(f);
            return temp;
        }


        public SimpleFraction ConvertTo() //преобразование десятичной дроби в обыкновенную
        {
            int numerator = Convert.ToInt32(Value * Math.Pow(10, countSigns));
            int denominator = Convert.ToInt32(Math.Pow(10, countSigns));

            return new SimpleFraction(numerator, denominator);
        }

        public static bool IsValid(string data) //проверка является ли дробь десятичной
        {
            return data.Contains(".") || data.Contains(",");
        }

        public static DecimalFraction operator +(DecimalFraction fr1, DecimalFraction fr2)
        {
            DecimalFraction res = new DecimalFraction(fr1.Value + fr2.Value);
            return res;
        }

        public static DecimalFraction operator -(DecimalFraction fr1, DecimalFraction fr2)
        {
            DecimalFraction res = new DecimalFraction(fr1.Value - fr2.Value);

            return res;
        }

        public static DecimalFraction operator *(DecimalFraction fr1, DecimalFraction fr2)
        {
            DecimalFraction res = new DecimalFraction(fr1.Value * fr2.Value);

            return res;
        }

        public static DecimalFraction operator /(DecimalFraction fr1, DecimalFraction fr2)
        {
            DecimalFraction res = new DecimalFraction(fr1.Value / fr2.Value);

            return res;
        }

        public override string ToString()
        {
            return value.ToString();
        }


    }
}

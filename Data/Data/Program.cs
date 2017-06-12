using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Decimal
    {
        private float _value;
        private int _countZnak; //кол-во знаков после запятой

        public float Value
        {
            get
            {
                return _value;
            }
        }
    }
}

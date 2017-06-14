using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data
{
    public partial class Design : Form
    {
        bool plus, minus, div, mult;
        DecimalFraction res;
        SimpleFraction Res;

        public Design()
        {
            InitializeComponent();
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            plus = true;
            minus = false;
            div = false;
            mult = false;
            if (FirstFraction.Text.Length > 0 && SecondFraction.Text.Length > 0)
                ResultButton.Enabled = true;
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = true;
            label6.Visible = false;
            label7.Visible = false;
            plus = false;
            minus = true;
            div = false;
            mult = false;
            if (FirstFraction.Text.Length > 0 && SecondFraction.Text.Length > 0)
                ResultButton.Enabled = true;
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = true;
            label7.Visible = false;
            plus = false;
            minus = false;
            div = false;
            mult = true;
            if (FirstFraction.Text.Length > 0 && SecondFraction.Text.Length > 0)
                ResultButton.Enabled = true;
        }

        protected void button4_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = true;
            plus = false;
            minus = false;
            div = true; 
            mult = false;
            if (FirstFraction.Text.Length > 0 && SecondFraction.Text.Length > 0)
                ResultButton.Enabled = true;
        }

        protected void button5_Click(object sender, EventArgs e)
        {
            if (FirstFraction.Text.Contains("/") && SecondFraction.Text.Contains("/")&&!FirstFraction.Text.Contains(".") && !SecondFraction.Text.Contains(",")&& !FirstFraction.Text.Contains(",") && !SecondFraction.Text.Contains("."))
            {
                SimpleFraction sr1 = new SimpleFraction(FirstFraction.Text);
                SimpleFraction sr2 = new SimpleFraction(SecondFraction.Text);
                if (plus)
                {
                    Res = sr1 + sr2;
                }
                if (minus)
                {
                    Res = sr1 - sr2;
                }
                if (div)
                {
                    Res = sr1 / sr2;
                }
                if (mult)
                {
                    Res = sr1 * sr2;
                }
                ResultBox.Text = Res.ToString();
            }
            else
            {
                DecimalFraction Fr1 = new DecimalFraction(3.5);
                DecimalFraction Fr2 = new DecimalFraction(3.5);
                if (FirstFraction.Text.Contains("/"))
                {
                    SimpleFraction fr1 = new SimpleFraction(FirstFraction.Text);
                    Fr1 = (DecimalFraction)fr1;
                }
                else
                {
                    if (SecondFraction.Text.Contains("/"))
                    {
                        SimpleFraction fr2 = new SimpleFraction(SecondFraction.Text);
                        Fr2 = (DecimalFraction)fr2;
                    }
                    else
                    {
                        double fr1 = double.Parse(FirstFraction.Text);
                        Fr1 = (DecimalFraction)fr1;
                    }
                }

                
                //if (FirstFraction.Text.Contains("/"))
                //{
                //    SimpleFraction fr2 = new SimpleFraction(SecondFraction.Text);
                //    Fr2 = (DecimalFraction)fr2;
                //}
                //else
                //{
                //    float fr2 = float.Parse(FirstFraction.Text);
                //    Fr2 = (DecimalFraction)fr2;
                //}

                if (plus)
                {
                    res = Fr1 + Fr2;
                }
                if (minus)
                {
                    res = Fr1 - Fr2;
                }
                if (div)
                {
                    res = Fr1 / Fr2;
                }
                if (mult)
                {
                    res = Fr1 * Fr2;
                }
                ResultBox.Text = res.ToString();
            }
            FirstFraction.Enabled = false;
            SecondFraction.Enabled = false;
            ResultButton.Enabled = false;
        }

        protected void button6_Click(object sender, EventArgs e)
        {
            string fr = ConvertBox1.Text;
            ConvertBox1.Enabled = false;
            ConvertResultBut.Enabled = false;
        }

        protected void button8_Click(object sender, EventArgs e)
        {

        }

        private void SecondFraction_TextChanged(object sender, EventArgs e)
        {
            if (SecondFraction.Text.Length == 0)
                ResultButton.Enabled = false;
        }

        private void ConvertBox1_TextChanged(object sender, EventArgs e)
        {
            if (ConvertBox1.Text.Length > 0)
                ConvertResultBut.Enabled = true;
            if (ConvertBox1.Text.Length == 0)
                ConvertResultBut.Enabled = false;
        }

        protected void button9_Click(object sender, EventArgs e)
        {
            FirstFraction.Clear();
            SecondFraction.Clear();
            ResultBox.Clear();
            ConvertBox1.Clear();
            ConvertBox2.Clear();
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            ResultButton.Enabled = false;
            FirstFraction.Enabled = true;
            SecondFraction.Enabled = true;
            ConvertBox1.Enabled = true;
        }

        protected void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected void FirstFraction_TextChanged(object sender, EventArgs e)
        {
            if (FirstFraction.Text.Length == 0)
                ResultButton.Enabled = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_calculator
{
    public partial class Calculator : Form
    {

        public Calculator()
        {
            InitializeComponent();
        } 

        double tmpTotal;
        char operatorSymbol;
        bool operanClicked;

        private void onfocus()
        {
            mainDisplay.Focus();
            mainDisplay.Select(mainDisplay.Text.Length, 1);
        }

        private void onclear()
        {
            reset();
            mainDisplay.Text = "0";
            tmpDisplay.Text = "";
        }

        private void reset()
        {
            tmpTotal = 0;
            operatorSymbol = ' ';
            operanClicked = false;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            onclear();
            onfocus();
        }

        private void btnAngka_Click(object sender, EventArgs e)
        {
            Button btnN = (Button)sender;
            if (mainDisplay.Text == "0")
            {
                mainDisplay.Clear();
            }
            if(operatorSymbol == '=')
            {
                mainDisplay.Clear(); 
                operatorSymbol = ' '; 
                tmpTotal = 0;
            }
            operanClicked = false;
            mainDisplay.Text = mainDisplay.Text + btnN.Text;
            onfocus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mainDisplay.Text = mainDisplay.Text.Remove(mainDisplay.Text.Length - 1);
            if(mainDisplay.Text == "" || mainDisplay.Text == "-")
            {
                onclear();
            }
            if(operatorSymbol == '=')
            {
                reset();
            }
            onfocus();
        }

        private void btnKoma_Click(object sender, EventArgs e)
        {
            if (!mainDisplay.Text.Contains(','))
            {
                mainDisplay.Text = mainDisplay.Text + ',';
            }
            if (operatorSymbol == '=')
            {
                reset();
            }
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            mainDisplay.Text = (Convert.ToDouble(mainDisplay.Text) * -1).ToString();
            onfocus();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            onclear();
            onfocus();
        }

        private void btnOperan_Click(object sender, EventArgs e)
        {
            Button btnSet = (Button)sender;
            if(operanClicked == false)
            {
                if (tmpDisplay.Text == "")
                {
                    tmpTotal = Convert.ToDouble(mainDisplay.Text);
                }
                else
                {
                    switch (operatorSymbol)
                    {
                        case '+':
                            tmpTotal = tmpTotal + Convert.ToDouble(mainDisplay.Text);
                            break;
                        case '-':
                            tmpTotal = tmpTotal - Convert.ToDouble(mainDisplay.Text);
                            break;
                        case 'x':
                            tmpTotal = tmpTotal * Convert.ToDouble(mainDisplay.Text);
                            break;
                        case '/':
                            tmpTotal = tmpTotal / Convert.ToDouble(mainDisplay.Text);
                            break;
                    }
                }
            }

            if(btnSet.Text == "=")
            {
                tmpDisplay.Text = "";
                mainDisplay.Text = tmpTotal.ToString();
            }
            else
            {
                tmpDisplay.Text = tmpTotal.ToString() + ' ' + btnSet.Text;
                mainDisplay.Text = "0";
            }
         
            operatorSymbol = Convert.ToChar(btnSet.Text);
            operanClicked = true;
            onfocus();
        }
    }
}

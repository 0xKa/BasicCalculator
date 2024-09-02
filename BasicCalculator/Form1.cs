using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double Result = 0;
        string Operation = "";
        bool isOperationPerformed = false;

        private void button_click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || isOperationPerformed)
                txtResult.Clear();

            isOperationPerformed = false;

            Button btn = (Button)sender; //get the sender button
            txtResult.Text += btn.Text;
        }
        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.IndexOf('.') == -1) //check if there is any '.'
                txtResult.Text += '.';
        //also you can use .Contains() method
        }

        private void operator_click(object sender, EventArgs e)
        {
            if (Result == 0)
                Result = Convert.ToDouble(txtResult.Text); //save the txtResult Value before saving the operation
            else
                btnResult.PerformClick(); //perform '=' button

            Button btn = (Button)sender;
            Operation = btn.Text; //get the operation char on from the button (sender)

            lblResult.Text = Result + " " + Operation;
            isOperationPerformed = true;
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            lblResult.Text = Result + " " + Operation;
            txtResult.Clear(); //only clear the entry 
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            Result = 0;
            lblResult.Text = "";
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            switch (Operation)
            {
                case "+":
                    Result += Convert.ToDouble(txtResult.Text);
                    break;
                case "-":
                    Result -= Convert.ToDouble(txtResult.Text);
                    break;
                case "*":
                    Result *= Convert.ToDouble(txtResult.Text);
                    break;
                case "/":
                    Result /= Convert.ToDouble(txtResult.Text);
                    break;
                case "^":
                    Result = Math.Pow(Result, Convert.ToDouble(txtResult.Text));
                    break;
                case "sqrt":
                    Result = Math.Sqrt(Convert.ToDouble(txtResult.Text));
                    break;
                case "tan":
                    Result = Math.Tan(Convert.ToDouble(txtResult.Text));
                    break;
                case "sin":
                    Result = Math.Sin(Convert.ToDouble(txtResult.Text));
                    break;
                case "cos":
                    Result = Math.Cos(Convert.ToDouble(txtResult.Text));
                    break;
                default:
                    Result = 0;
                    MessageBox.Show("Operation Error!\nPlease Choose an Operator.", "Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            lblResult.Text = Result + " " + Operation;
            txtResult.Text = Result.ToString();
            isOperationPerformed = true;
        }
    }
}

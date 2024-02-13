using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select an operation.");
                return;
            }

            string selectedOperation = comboBox2.SelectedItem.ToString();

            // Using delegate to perform calculation based on selected operation
            Func<float, float, float> calculateOperation = null;

            switch (selectedOperation)
            {
                case "Add":
                    calculateOperation = Add;
                    break;
                case "Subtract":
                    calculateOperation = Subtract;
                    break;
                case "Multiply":
                    calculateOperation = Multiply;
                    break;
                case "Divide":
                    calculateOperation = Divide;
                    break;
                case "Power":
                    calculateOperation = Power;
                    break;
                case "Average":
                    calculateOperation = Average;
                    break;
            }

            float operand1, operand2;
            if (!float.TryParse(comboBox1.Text, out operand1) || !float.TryParse(comboBox3.Text, out operand2))
            {
                MessageBox.Show("Invalid operands. Please enter valid integer values.");
                return;
            }

            float result = calculateOperation(operand1, operand2);
            resultLabel.Text = $"Result: {result}";
        }

        private float Add(float a, float b)
        {
            return a + b;
        }

        private float Subtract(float a, float b)
        {
            return a - b;
        }

        private float Multiply(float a, float b)
        {
            return a * b;
        }

        private float Divide(float a, float b)
        {
            return a / b;
        }

        private float Power(float a, float b)
        {
            return (int)Math.Pow(a, b);
        }

        private float Average(float a, float b)
        {
            return (a + b) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculateButton_Click(sender, e);
        }
    }
}


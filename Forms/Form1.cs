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
            Func<int, int, int> calculateOperation = null;

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
                default:
                    MessageBox.Show("Invalid operation.");
                    return;
            }

            int operand1, operand2;
            if (!int.TryParse(comboBox1.Text, out operand1) || !int.TryParse(comboBox3.Text, out operand2))
            {
                MessageBox.Show("Invalid operands. Please enter valid integer values.");
                return;
            }

            int result = calculateOperation(operand1, operand2);
            resultLabel.Text = $"Result: {result}";
        }

        private int Add(int a, int b)
        {
            return a + b;
        }

        private int Subtract(int a, int b)
        {
            return a - b;
        }

        private int Multiply(int a, int b)
        {
            return a * b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculateButton_Click(sender, e);
        }
    }
}


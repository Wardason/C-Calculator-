using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace calculator_wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Calculation Function
        int Multiplication(int num1, int num2)
        {
            int result = num1 * num2;
            return result;
        }

        int Division(int num1, int num2)
        {
            int result = 0;
            try
            {
                 result = num1 / num2;
            }
            catch 
            {
                textblock_value.Text = "ERROR";
                MessageBox.Show("Division by 0 is not allowed");
            }
            return result;
        }
          
        int Addition(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }

        int Subtraction(int num1, int num2)
        {
            int result = num1 - num2;
            return result;
        }
        #endregion


        #region Calculator Buttons
        private void sevenButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "7";

        }

        private void eightButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "8";
        }

        private void nineButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "9";
        }

        private void multiplicationButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += " * ";
        }

        private void fourButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "4";
        }

        private void fiveButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "5";
        }

        private void sixButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "6";
        }

        private void subtractionButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += " - ";
        }

        private void oneButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "1";
        }

        private void twoButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "2";
        }

        private void threeButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "3";
        }

        private void additionButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += " + ";
        }

        private void divisionButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += " / ";
        }

        private void zeroButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "0";
        }

        private void decimalButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += ".";
        }

        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            string exercise = textblock_value.Text;
            list_sorting(exercise);
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_result.Text = String.Empty;
            textblock_value.Text = String.Empty;
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void percentageButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        void list_sorting(string exercise)

        {
            List<string> double_tokens = new List<string>();
            List<string> operator_tokens = new List<string>();
            string[] tokens = exercise.Split(' ');

            foreach (string token in tokens)
            {
                if (token == "+" || token == "-" || token == "/" || token == "*")
                {
                    operator_tokens.Add(token);
                }
                else
                {
                    double_tokens.Add(token);
                }
            }

            checking_if_operator_included(operator_tokens, double_tokens);
        }
        void checking_if_operator_included(List<string> operator_tokens, List<string> double_tokens)
        {
            while (operator_tokens.Count > 0)
            {

                if (operator_tokens.Contains("*"))
                {
                    analysing_list_element_position(operator_tokens, double_tokens, "*");

                }
                if (operator_tokens.Contains("/"))
                {
                    analysing_list_element_position(operator_tokens, double_tokens, "/");

                }
                if (operator_tokens.Contains("+"))
                {
                    analysing_list_element_position(operator_tokens, double_tokens, "+");

                }
                if (operator_tokens.Contains("-"))
                {
                    analysing_list_element_position(operator_tokens, double_tokens, "-");
                }
            }
        }

        void analysing_list_element_position(List<string> operator_tokens, List<string> double_tokens, string operation)
        {
            int index = operator_tokens.FindIndex(token => token == operation);
            string left_of_op = double_tokens.ElementAt(index);
            string right_of_op = double_tokens.ElementAt(index + 1);

            operator_tokens.RemoveAt(index);
            double_tokens.RemoveAt(index + 1);
            double_tokens.RemoveAt(index);
            displaying_result(double_tokens, operation, index, left_of_op, right_of_op);
        }

        void displaying_result(List<string> double_tokens, string operation, int index, string left_of_op, string right_of_op)
        {
            int result = calculation(left_of_op, right_of_op, operation);

            double_tokens.Insert(index, result.ToString());
            textblock_result.Text = result.ToString();
        }

        int calculation(string left_of_op, string right_of_op, string operation)
        {
            int left_num = Int32.Parse(left_of_op);
            int right_num = Int32.Parse(right_of_op);
            int result = 0;

            switch (operation)
            {
                case "*":
                    result = Multiplication(left_num, right_num);
                    return result;

                case "/":
                    result = Division(left_num, right_num);
                    return result;

                case "+":
                    result = Addition(left_num, right_num);
                    return result;

                case "-":
                    result = Subtraction(left_num, right_num);
                    return result;

                default:
                    result = 0;
                    return result;

            }
        }

    }
}
    


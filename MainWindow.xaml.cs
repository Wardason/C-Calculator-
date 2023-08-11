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
using System.Xml.Schema;

namespace calculator_wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Calculation Function
        double Multiplication(double num1, double num2)
        {
            double result = num1 * num2;
            double rounded_result = Math.Round(result, 2);
            return rounded_result;
        }

        double Division(double num1, double num2)
        {
            double result = num1 / num2;

            if (Double.IsInfinity(result))
            {
                Error_Message("Division Error");
                return 0;
            }
            else
            {
                double rounded_result = Math.Round(result, 2);
                return rounded_result;
            }
        }

        double Addition(double num1, double num2)
        {
            double result = num1 + num2;
            double rounded_result = Math.Round(result, 2);
            return rounded_result;
        }

        double Subtraction(double num1, double num2)
        {
            double result = num1 - num2;
            double rounded_result = Math.Round(result, 2);
            return rounded_result;
        }
        #endregion


        #region Calculator Buttons
        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "7";

        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "8";
        }

        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "9";
        }

        private void MultiplicationButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += " * ";
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "4";
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "5";
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "6";
        }

        private void SubtractionButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += " - ";
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "1";
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "2";
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "3";
        }

        private void AdditionButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += " + ";
        }

        private void DivisionButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += " / ";
        }

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += "0";
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Text += ",";
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            string exercise = textblock_value.Text;
            List_Sorting(exercise);
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textblock_value.Foreground = Brushes.White;
            textblock_result.Foreground = Brushes.White;
            textblock_result.Text = String.Empty;
            textblock_value.Text = String.Empty;
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        void List_Sorting(string exercise)
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

            Checking_Which_Operator_Included(operator_tokens, double_tokens);
        }
        void Checking_Which_Operator_Included(List<string> operator_tokens, List<string> double_tokens)
        {
            while (operator_tokens.Count > 0)
            {

                if (operator_tokens.Contains("*"))
                {
                    Analysing_List_Element_Position(operator_tokens, double_tokens, "*");

                }
                if (operator_tokens.Contains("/"))
                {
                    Analysing_List_Element_Position(operator_tokens, double_tokens, "/");

                }
                if (operator_tokens.Contains("+"))
                {
                    Analysing_List_Element_Position(operator_tokens, double_tokens, "+");

                }
                if (operator_tokens.Contains("-"))
                {
                    Analysing_List_Element_Position(operator_tokens, double_tokens, "-");
                }
            }
        }

        void Analysing_List_Element_Position(List<string> operator_tokens, List<string> double_tokens, string operation)
        {
            int index = operator_tokens.FindIndex(token => token == operation);
            string left_of_op = double_tokens.ElementAt(index);
            string right_of_op = double_tokens.ElementAt(index + 1);

            operator_tokens.RemoveAt(index);
            double_tokens.RemoveAt(index + 1);
            double_tokens.RemoveAt(index);
            Displaying_Result(double_tokens, operation, index, left_of_op, right_of_op);
        }

        void Displaying_Result(List<string> double_tokens, string operation, int index, string left_of_op, string right_of_op)
        {
            double result = Calculation(left_of_op, right_of_op, operation);

            double_tokens.Insert(index, result.ToString());
            textblock_result.Text = result.ToString();
        }

        double Calculation(string left_of_op, string right_of_op, string operation)
        {
            double left_num = 0;
            double right_num = 0;
            double result = 0;
            try
            {
                 left_num = Convert.ToDouble(left_of_op);
                 right_num = Convert.ToDouble(right_of_op);
            }
            catch (Exception ex)
            {
                Error_Message("Input Error");
            }

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

        double Error_Message(string message)
        {
            textblock_value.Foreground = Brushes.IndianRed;
            textblock_result.Foreground = Brushes.IndianRed;
            textblock_value.Text = message;
            return 0;
        }
    }
}
    


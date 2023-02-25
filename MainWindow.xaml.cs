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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator__2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool checkOperator = false;//plus,minus ve s. vermek ucun;
        public bool checkHistory = false;//history label ucun;
        double number = 0;
        string oprtr = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                int index = btn.Name.Length - 1;
                if (btn.Content.ToString() != ".")
                {
                    if (lbl_main.Content.ToString() == "0")
                    {
                        lbl_main.Content = null;
                    }
                    if (checkHistory)
                    {
                        lbl_main.Content = null;
                        checkHistory = false;
                    }
                    lbl_main.Content += btn.Name[index].ToString();
                    checkOperator = true;

                }
                else
                {
                    foreach (var item in lbl_main.Content.ToString())
                    {
                        if (item == '.')
                            return;
                    }
                    lbl_main.Content += btn.Content.ToString();
                }
            }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button btn)
            {
                if (lbl_history.Content is null)
                    number = Convert.ToDouble(lbl_main.Content);
                if (btn.Name.ToString() == "btn_remove")
                {

                    string temp = lbl_main.Content.ToString();
                    temp = temp.Remove(temp.Length - 1);
                    if (temp == "")
                        lbl_main.Content = "0";
                    else
                        lbl_main.Content = temp;
                    return;
                }
                else if (btn.Name.ToString() == "btn_percentage")
                {
                    if (lbl_main.Content is not null)
                    {
                        if (lbl_history.Content is not null)
                        {
                            string temp = lbl_history.Content.ToString();
                            temp = temp.Remove(temp.Length - 1);
                            double numberPercentage = Convert.ToDouble(temp);
                            double numberPercentage2 = Convert.ToDouble(lbl_main.Content);
                            lbl_main.Content = ((numberPercentage * numberPercentage2) / 100).ToString();
                        }
                        else
                        {

                            lbl_history.Content = "0";
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else if (btn.Name.ToString() == "btn_squareRoot")
                {
                    number = Math.Sqrt(Convert.ToDouble(lbl_main.Content));
                    lbl_main.Content = number.ToString();
                    return;
                }
                else if (btn.Name.ToString() == "btn_X2")
                {
                    double number1 = Convert.ToDouble(lbl_main.Content);
                    number1 = number1 * number1;
                    lbl_main.Content = number1.ToString();
                    return;
                }
                else if (btn.Name.ToString() == "btn_1DivX")
                {
                    number = Convert.ToDouble(lbl_main.Content);
                    number = 1 / number;
                    lbl_main.Content = number.ToString(); return;
                }
                else if (btn.Name.ToString() == "btn_CE")
                {
                    lbl_main.Content = "0";
                    return;
                }
                else if (btn.Name.ToString() == "btn_C")
                {
                    lbl_history.Content = null;
                    lbl_main.Content = "0";
                    number = 0;
                    oprtr = "";
                    return;

                }
                else if (btn.Name.ToString() == "btn_plusMinus")
                {
                    string temp = lbl_main.Content.ToString();

                    temp = (Convert.ToDouble(temp) * -1).ToString();
                    lbl_main.Content = temp;
                    return;
                }

                else if (checkOperator)
                {

                    switch (oprtr)
                    {
                        case "+":
                            number += Convert.ToDouble(lbl_main.Content);
                            break;
                        case "-":
                            number -= Convert.ToDouble(lbl_main.Content);
                            break;
                        case "x":
                            number *= Convert.ToDouble(lbl_main.Content);
                            break;
                        case "÷":
                            if (Convert.ToDouble(lbl_main.Content) == 0)
                            {
                                MessageBox.Show("sifira bolmek olmaz", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            else
                            {
                                number /= Convert.ToDouble(lbl_main.Content);
                            }
                            break;
                        default:
                            break;
                    }
                    if (btn.Name.ToString() == "btn_equal")
                    {
                        lbl_history.Content += lbl_main.Content.ToString() + "=";
                        lbl_main.Content = number.ToString();
                        oprtr = "";
                        return;
                    }
                }
                oprtr = btn.Content.ToString()!;
                if (btn.Content.ToString() == "x" || btn.Content.ToString() == "÷" || btn.Content.ToString() == "+" || btn.Content.ToString() == "-")
                    lbl_history.Content = number.ToString() + btn.Content;


                checkHistory = true;
                checkOperator = false;

            }
        }


    }
}
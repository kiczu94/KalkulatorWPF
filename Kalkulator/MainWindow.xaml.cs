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

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Display display { get; set; }
        public Display display2 { get; set; }
        string text1, text2, text3;
        public MainWindow()
        {
            InitializeComponent();
            display = new Display();
            display2 = new Display();
            DataContext = new
            {
                MainDisplay = display,
                AdditionalDisplay = display2
            };
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "1";
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "2";
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "3";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            text1 = display.Wyswietlacz;
            text2 = "+";
            display.Wyswietlacz = "+";
            display2.Wyswietlacz = display.Wyswietlacz;
            display.Wyswietlacz = null;
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "4";
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "5";
        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "6";
        }
        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            text1 = display.Wyswietlacz;
            text2 = "-";
            display.Wyswietlacz = "-";
            display2.Wyswietlacz = display.Wyswietlacz;
            display.Wyswietlacz = null;
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "7";
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "8";
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "9";
        }
        private void ButtonStar_Click(object sender, RoutedEventArgs e)
        {
            text1 = display.Wyswietlacz;
            text2 = "*";
            display.Wyswietlacz = "*";
            display2.Wyswietlacz = display.Wyswietlacz;
            display.Wyswietlacz = null;
        }
        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = "0";
        }

        private void ButtonPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            string textHelper = display.Wyswietlacz;
            if (display.Wyswietlacz.Contains('-'))
            {
                textHelper=textHelper.Replace('-', '\0');
                display.Wyswietlacz = null;
                display.Wyswietlacz = textHelper;
            }
            else
            {
                display.Wyswietlacz = null;
                display.Wyswietlacz = "-" + textHelper;
            }

        }

        private void ButtonComa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            display2.Wyswietlacz = null;
            text1 = display.Wyswietlacz;
            text2 = "sqrt";
            display2.Wyswietlacz = "sqrt(" + display.Wyswietlacz + ")" + "=";
            display.Wyswietlacz = null;
            Calculations calc = new Calculations(text1, text2);
            display.Wyswietlacz = calc.CalculateValue().ToString();
            display2.Wyswietlacz = display.Wyswietlacz;
        }

        private void ButtonPower_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonOneOver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteOneNumber_Click(object sender, RoutedEventArgs e)
        {
            string textHelper = display.Wyswietlacz.Remove((display.Wyswietlacz.Length) - 1);
            display.Wyswietlacz = null;
            display.Wyswietlacz = textHelper;
        }

        private void ButtonDeleteActualDisplay_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = null;
        }

        private void ButtonRestOfDividing_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            display.Wyswietlacz = null;
            display2.Wyswietlacz = null;
        }
        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            text3 = display.Wyswietlacz;
            display2.Wyswietlacz = display.Wyswietlacz + "=";
            display.Wyswietlacz = null;
            Calculations calc = new Calculations(text1, text3, text2);
            display.Wyswietlacz = calc.CalculateValue().ToString();
            display2.Wyswietlacz = display.Wyswietlacz;
        }
    }
}

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
        string firstPartOfEquation, signOfCalculation, secondPartOfEquation, lastResult = null;
        bool wasClickedAlready = false;
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
            DisplayNumber("1");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber("2");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber("3");
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            CheckIfCalcWasDone();
            CreateEquation("+");
            DeleteActualDisplay();
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber("4");
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber("5");
        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber("6");
        }
        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            CheckIfCalcWasDone();
            CreateEquation("-");
            DeleteActualDisplay();
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber("7");
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber("8");
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber("9");
        }
        private void ButtonStar_Click(object sender, RoutedEventArgs e)
        {
            CheckIfCalcWasDone();
            CreateEquation("*");
            DeleteActualDisplay();
        }
        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            CheckIfCalcWasDone();
            CreateEquation("/");
            DeleteActualDisplay();
        }
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber("0");
        }

        private void ButtonPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            ChangeSign();
        }

        private void ButtonComa_Click(object sender, RoutedEventArgs e)
        {
            Coma();
        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            CheckIfCalcWasDone();
            CreateEquation("sqrt");
            DeleteActualDisplay();
            PerformCalculation();
        }

        private void ButtonPower_Click(object sender, RoutedEventArgs e)
        {
            CheckIfCalcWasDone();
            CreateEquation("^2");
            DeleteActualDisplay();
            PerformCalculation();
        }

        private void ButtonOneOver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteOneNumber_Click(object sender, RoutedEventArgs e)
        {
            DeleteOneNumberFromMainDisplay();
        }

        private void ButtonDeleteActualDisplay_Click(object sender, RoutedEventArgs e)
        {
            DeleteActualDisplay();
        }

        private void ButtonRestOfDividing_Click(object sender, RoutedEventArgs e)
        {
            CheckIfCalcWasDone();
            CreateEquation("%");
            DeleteActualDisplay();
        }
        private void ButtonDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            DeleteAbsolutelyAll();
        }
        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            ResultClickedAgain();
            Result();
        }
        //------------------------------------------------------------------------------------------------------------------------------------
        private void DeleteAll()
        {
            DeleteActualDisplay();
            DeleteHistoryDisplay();
            firstPartOfEquation = null;
            secondPartOfEquation = null;
            signOfCalculation = null;
            wasClickedAlready = false;
        }
        private void DeleteActualDisplay()
        {
            display.Wyswietlacz = null;
        }
        private void DeleteHistoryDisplay()
        {
            display2.Wyswietlacz = null;
        }
        private void DisplayNumber(string text)
        {
            display.Wyswietlacz = text;
        }
        private void CreateEquation(string text)
        {
            signOfCalculation = text;
            if (lastResult == null && firstPartOfEquation == null)
            {
                firstPartOfEquation = display.Wyswietlacz;
            }
            else if (lastResult != null && signOfCalculation != "*-1")
            {
                firstPartOfEquation = lastResult;
            }
            if (signOfCalculation == "sqrt")
            {
                display2.Wyswietlacz = "sqrt(" + display.Wyswietlacz + ")" + "=";
            }
            else if (signOfCalculation == "^2")
            {
                display2.Wyswietlacz = display.Wyswietlacz + "^2 = ";
            }
            else
            {
                display.Wyswietlacz = text;
                display2.Wyswietlacz = display.Wyswietlacz;
            }
        }
        private void PerformCalculation()
        {
            Calculations calc;
            if (signOfCalculation == "sqrt" || signOfCalculation == "^2")
            {
                calc = new Calculations(firstPartOfEquation, signOfCalculation);
            }
            else
            {
                calc = new Calculations(firstPartOfEquation, secondPartOfEquation, signOfCalculation);
            }
            lastResult = calc.CalculateValue().ToString();
            display.Wyswietlacz = lastResult;
            display2.Wyswietlacz = display.Wyswietlacz;
        }
        private void DeleteOneNumberFromMainDisplay()
        {
            if (display.Wyswietlacz != null)
            {
                string textHelper = display.Wyswietlacz.Remove((display.Wyswietlacz.Length) - 1);
                DeleteActualDisplay();
                display.Wyswietlacz = textHelper;
            }
        }
        private void ChangeSign()
        {
            if (display.Wyswietlacz == null)
            {
                display.Wyswietlacz = "-";
            }
            else if (display.Wyswietlacz == "-")
            {
                display.Wyswietlacz = null;
            }
            else
            {
                Calculations calc = new Calculations(display.Wyswietlacz, "*-1");
                lastResult = calc.CalculateValue().ToString();
                DeleteActualDisplay();
                display.Wyswietlacz = lastResult;
            }
        }
        private void CheckIfCalcWasDone()
        {
            if (signOfCalculation != "sqrt")
            {
                if (lastResult != null && signOfCalculation != null)
                {
                    if (!display2.Wyswietlacz.Contains('='))
                    {
                        secondPartOfEquation = display.Wyswietlacz;
                        CreateEquation(signOfCalculation);
                        PerformCalculation();
                    }
                    DeleteAll();
                    display2.Wyswietlacz = lastResult;
                }
                else if (lastResult == null && signOfCalculation != null)
                {
                    secondPartOfEquation = display.Wyswietlacz;
                    CreateEquation(signOfCalculation);
                    PerformCalculation();
                    DeleteAll();
                    display2.Wyswietlacz = lastResult;
                }
            }
            else
            {
                display2.Wyswietlacz = null;
            }
        }
        private void DeleteAbsolutelyAll()
        {
            DeleteAll();
            lastResult = null;
        }
        private void Coma()
        {
            if (display.Wyswietlacz == null)
            {
                display.Wyswietlacz = "0,";
            }
            else if (display.Wyswietlacz == "0,")
            {
                display.Wyswietlacz = null;
            }
            else if (!display.Wyswietlacz.Contains(","))
            {
                display.Wyswietlacz = ",";
            }
        }
        private void Result()
        {
            if (wasClickedAlready == true)
            {
                if (signOfCalculation != "-" && signOfCalculation != "/")
                {
                    secondPartOfEquation = display.Wyswietlacz;
                    display2.Wyswietlacz = secondPartOfEquation + signOfCalculation + firstPartOfEquation + "=";
                    display.Wyswietlacz = null;
                    PerformCalculation();
                }
                else if (signOfCalculation == "-" || signOfCalculation == "/")
                {
                    display2.Wyswietlacz = firstPartOfEquation + signOfCalculation + secondPartOfEquation + "=";
                    display.Wyswietlacz = null;
                    PerformCalculation();
                }
            }
            else
            {
                secondPartOfEquation = display.Wyswietlacz;
                if (secondPartOfEquation == "0" && signOfCalculation == "/")
                {
                    display.Wyswietlacz = null;
                    display.Wyswietlacz = "Nie można dzielić przez zero";
                    DeleteHistoryDisplay();
                }
                else
                {
                    display2.Wyswietlacz = display.Wyswietlacz + "=";
                    display.Wyswietlacz = null;
                    PerformCalculation();
                }
            }
        }
        private void ResultClickedAgain()
        {
            if (lastResult != null)
            {
                if (wasClickedAlready==false)
                {
                    if (signOfCalculation != "-" && signOfCalculation != "/")
                    {
                        firstPartOfEquation = secondPartOfEquation;
                        display2.Wyswietlacz = null;
                        wasClickedAlready = true;
                    }
                    else
                    {
                        firstPartOfEquation = lastResult;
                        display2.Wyswietlacz = null;
                        wasClickedAlready = true;
                    }
                }
                else
                {
                    if (signOfCalculation == "-" || signOfCalculation == "/")
                    {
                        firstPartOfEquation = lastResult;
                        display2.Wyswietlacz = null; 
                    }
                    else
                    {
                        display2.Wyswietlacz = null;
                    }
                }
            }

        }

    }
}

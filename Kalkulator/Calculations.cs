using System;
using System.Collections.Generic;
using System.Text;

namespace Kalkulator
{
    public class Calculations
    {
        private double num1;
        private double num2;
        private double result;
        private string whatCalc;

        public string Num1
        {
            get
            {
                return num1.ToString();
            }
            set
            {
                num1 = Double.Parse(value);
            }
        }
        public string Num2
        {
            get
            {
                return num2.ToString();
            }
            set
            {
                num2 = Double.Parse(value);
            }
        }

        public string Result
        {
            get
            {
                return result.ToString();
            }
            set {; }
        }
        public Calculations(string number1, string number2, string whatKindOfCalculation)
        {
            Num1 = (number1 == null) ? "0" : number1;
            Num2 =(number2==null)? "0": number2;
            whatCalc = whatKindOfCalculation;
        }
        public Calculations(string number1, string whatKindOfCalculation)
        {
            Num1 = (number1 == null) ? "0" : number1;
            whatCalc = whatKindOfCalculation;
        }
        public double CalculateValue()
        {
            switch (whatCalc)
            {
                case "+":
                   result = num1 + num2;
                        break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "sqrt":
                    result = Math.Sqrt(num1);
                    break;
            }
            return result;
        }
    }
}

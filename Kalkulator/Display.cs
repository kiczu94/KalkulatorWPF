using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Kalkulator
{
    public class Display : INotifyPropertyChanged
    {
        private string wyswietlacz;
        public string Wyswietlacz
        {
            get
            { return wyswietlacz; }
            set
            {
                if (value==null)
                {
                    wyswietlacz = null;
                }
                else
                {
                    wyswietlacz += value;
                }
                OnChangedProperty("Wyswietlacz");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChangedProperty(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

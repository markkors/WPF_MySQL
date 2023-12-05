using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MySQL.Controllers
{
    public class TestController : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int _myTestProperty; // member


        public TestController() // constructor
        {
            _myTestProperty = 10;
        }


        public int MyTestProperty { 
            get {
                return _myTestProperty;
            } 
            set { 
                _myTestProperty = value;
                NotifyPropertyChanged("MyTestProperty");
            } 
        }



        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

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
using System.Windows.Shapes;
using WPF_MySQL.Controllers;
using WPF_MySQL.Models;

namespace WPF_MySQL.Views
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {

        TestController tc = new TestController();
        Question _activeQuestion; // private field
        public TestWindow()
        {
            InitializeComponent();
            btnTestMe.Click += BtnTestMe_Click;
            this.DataContext = tc;
        }

        private void BtnTestMe_Click(object sender, RoutedEventArgs e)
        {
            tc.MyTestProperty += 10;
           

        }

        private void ShowActiveQuestion(Question Q)
        {
            lblActiveQuestion.Content = Q.Desc;

        }

        public Question setQuestion  { 
            get { return _activeQuestion; } 
            set { 
                _activeQuestion = value;
                ShowActiveQuestion(_activeQuestion);
            } 
        }


        public int MyProperty { get; set; }
    }
}

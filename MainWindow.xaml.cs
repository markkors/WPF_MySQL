using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WPF_MySQL.Models;

namespace WPF_MySQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controllers.Quiztime quiztimeObject = new Controllers.Quiztime();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = quiztimeObject;
            //Debug.WriteLine(quiztimeObject.Quizzes.Count());
            //quiztimeObject.Quizzes.ForEach(quiz => Debug.WriteLine(quiz.Name));
            btnTest.Click += BtnTest_Click;
            cmbCombo.SelectionChanged += CmbCombo_SelectionChanged;
           


        }

        private void CmbCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Quiz _selectedQuiz = (Quiz)cmbCombo.SelectedItem;
            quiztimeObject.ActiveQuiz = _selectedQuiz;
                    



        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            // nog ff niks
        }
    }
}

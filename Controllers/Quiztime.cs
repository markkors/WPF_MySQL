using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MySQL.Controllers
{
    public class Quiztime : SQL, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private Models.Quiz _activeQuiz;
        private List<Models.Quiz> _quizzes = new List<Models.Quiz>();

        // create constructor
        public Quiztime()
        {
            _quizzes = getQuizzes();
        }

        private List<Models.Quiz> getQuizzes()
        {
            List<Models.Quiz> quizzes = new List<Models.Quiz>();
            string query = "SELECT * FROM quiz";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader reader = cmd.ExecuteReader();
          

            while (reader.Read())
            {
              Models.Quiz quiz = new Models.Quiz();
              quiz.idQuiz = reader.GetInt32(0);
              quiz.Date = reader.GetDateTime(1);
              quiz.Name = reader.GetString(2);
              quizzes.Add(quiz);
            }

            return quizzes;
        }


        // getter for the quizzes
        public List<Models.Quiz> Quizzes { 
            get {
                return _quizzes;
            } 
        }

        public Models.Quiz ActiveQuiz { 
            get { return _activeQuiz; } 
            set {
                _activeQuiz = value;
                NotifyPropertyChanged("ActiveQuiz");
            } 
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

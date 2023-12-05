using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using WPF_MySQL.Models;

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
            NotifyPropertyChanged("Quizzes");
        }


        private List<Models.Question> Questions(int idQuiz)
        {
            List<Models.Question> questions = new List<Models.Question>();
            string query = "SELECT question.* FROM quiz " +
                "INNER JOIN quizquestion ON quiz.idQuiz = quizquestion.QuizID " +
                "INNER JOIN question ON quizquestion.QuestionID = question.idQuestion WHERE quiz.idQuiz = @idQuiz;";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                cmd.Parameters.AddWithValue("@idQuiz", idQuiz);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Models.Question question = new Models.Question();
                    question.idQuestion = reader.GetInt32(0);
                    question.Type = reader.GetInt32(1);
                    question.Desc = reader.GetString(2);
                    question.imagepath = reader.GetString(3);
                    questions.Add(question);
                }
                reader.Close();
                reader.Dispose();

            }
            return questions;
        }

        private List<Models.Quiz> getQuizzes()
        {
            List<Models.Quiz> quizzes = new List<Models.Quiz>();
            string query = "SELECT * FROM quiz";
         
            using (MySqlCommand cmd = new MySqlCommand(query, Connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Models.Quiz quiz = new Models.Quiz();
                    quiz.idQuiz = reader.GetInt32(0);
                    quiz.Date = reader.GetDateTime(1);
                    quiz.Name = reader.GetString(2);
                    quizzes.Add(quiz);
                }
                reader.Close();
                reader.Dispose();
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
                // active quiz updated
                _activeQuiz = value;
                _activeQuiz.Questions = Questions(_activeQuiz.idQuiz);
                NotifyPropertyChanged("ActiveQuiz");
            } 
        }

        public int MyProperty { get; set; }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MySQL.Controllers
{
    public class Quiztime
    {
        public static Controllers.SQL mySqlObject = new Controllers.SQL();
        private Models.Quiz _activeQuiz;

        // create constructor
        public Quiztime()
        {
            
        }

        private List<Models.Quiz> getQuizzes()
        {
            List<Models.Quiz> quizzes = new List<Models.Quiz>();
            MySqlDataReader reader = mySqlObject.executeQuery("SELECT * FROM quiz");

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
                return getQuizzes();
            } 
        }

        public Models.Quiz activeQuiz { 
            get { return _activeQuiz; } 
            set { _activeQuiz = value; } 
        }

    }
}

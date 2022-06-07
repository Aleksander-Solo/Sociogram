using Sociogram.DAL.Entities;
using Sociogram.DAL.Repositiores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Repositiores
{
    public class QuizService : IQuizService
    {
        ApplicationDbContext dbContext;
        public QuizService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Create(Quiz quiz)
        {
            quiz.CreatedDate = DateTime.Now;
            dbContext.Quizzes.Add(quiz);
            dbContext.SaveChanges();
        }

        public void CreateQuiz(Quiz quiz, string nameTeacher)
        {
            Teacher teacher = dbContext.Teachers.FirstOrDefault(t => t.Name == nameTeacher);
            quiz.Teacher = teacher;
            quiz.CreatedDate = DateTime.Now;
            dbContext.Quizzes.Add(quiz);
            dbContext.SaveChanges();
        }

        public List<Quiz> GetQuizzes(string name)
        {
            return dbContext.Quizzes.Where(x => x.Teacher.Name == name).ToList();
        }

        public void Update(int id)
        {
            var quiz = dbContext.Quizzes.FirstOrDefault(x => x.Id == id);
            quiz.Active = false;
            dbContext.Quizzes.Update(quiz);
            dbContext.SaveChanges();
        }
    }
}

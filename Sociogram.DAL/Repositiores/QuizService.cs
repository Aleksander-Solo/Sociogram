using Sociogram.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Repositiores
{
    public class QuizService
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
        public void Update(int id)
        {
            var quiz = dbContext.Quizzes.FirstOrDefault(x => x.Id == id);
            quiz.Active = false;
            dbContext.Quizzes.Update(quiz);
            dbContext.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Sociogram.DAL.Entities;
using Sociogram.DAL.Repositiores.Interfaces;

namespace Sociogram.DAL.Repositiores
{
    public class QuizService : IQuizService
    {
        ApplicationDbContext dbContext;
        public QuizService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void AddStudent(Student student, int joinCode)
        {
            student.CreatedDate = DateTime.Now;
            student.Quizzes = new List<Quiz>();
            student.Quizzes.Add(dbContext.Quizzes.First(x => x.JoinCode == joinCode));
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public void CreateQuiz(Quiz quiz, string nameTeacher)
        {
            Teacher teacher = dbContext.Teachers.FirstOrDefault(t => t.Name == nameTeacher);
            quiz.Teacher = teacher;
            quiz.CreatedDate = DateTime.Now;
            quiz.Active = true;
            dbContext.Quizzes.Add(quiz);
            dbContext.SaveChanges();
        }

        public ClassS GetClassS(int joinCode)
        {
            int ClassSId = dbContext.Quizzes.FirstOrDefault(x => x.JoinCode == joinCode).ClassSId;
            return dbContext.ClassS.Include(x => x.StudentsConst).FirstOrDefault(x => x.Id == ClassSId);
        }

        public Quiz GetQuizze(int joinCode)
        {
            return dbContext.Quizzes.Include(x => x.Students).Include(x => x.ClassS).ThenInclude(x => x.StudentsConst).First(x => x.JoinCode == joinCode);
        }

        public List<Quiz> GetQuizzes(string name)
        {
            return dbContext.Quizzes.Where(x => x.Teacher.Name == name).Include(x => x.ClassS).ToList();
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

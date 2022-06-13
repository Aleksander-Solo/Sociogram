using Sociogram.DAL.Entities;

namespace Sociogram.DAL.Repositiores.Interfaces
{
    public interface IQuizService
    {
        public void Update(int id);
        public List<Quiz> GetQuizzes(string name);
        public Quiz GetQuizze(int joinCode);
        public void CreateQuiz(Quiz quiz, string nameTeacher);
        public ClassS GetClassS(int joinCode);
        public void AddStudent(Student student, int joinCode);
    }
}

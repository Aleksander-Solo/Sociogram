using Sociogram.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Repositiores.Interfaces
{
    public interface IQuizService
    {
        public void Update(int id);
        public List<Quiz> GetQuizzes(string name);
        public void CreateQuiz(Quiz quiz, string nameTeacher);
    }
}

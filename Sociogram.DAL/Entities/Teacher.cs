using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public List<Quiz> Quizzes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

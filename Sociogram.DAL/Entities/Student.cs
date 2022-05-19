using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Nr { get; set; }
        public int FirstFriend { get; set; }
        public int SecontFriend { get; set; }
        public int ThirdFriend { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Quiz> Quizzes { get; set; }
    }
}

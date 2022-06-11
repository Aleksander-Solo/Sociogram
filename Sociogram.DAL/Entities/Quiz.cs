using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public List<Student> Students { get; set; }
        public DateTime CreatedDate { get; set; }
        public ClassS ClassS { get; set; }
        public int ClassSId { get; set; }
        public int JoinCode { get; set; }
        public bool Active { get; set; }
    }
}

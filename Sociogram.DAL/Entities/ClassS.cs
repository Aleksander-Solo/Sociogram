using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Entities
{
    public class ClassS
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentConst> StudentsConst { get; set; }
        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}

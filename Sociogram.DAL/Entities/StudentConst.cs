using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Entities
{
    public class StudentConst
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Nr { get; set; }
        [ForeignKey("ClassSId")]
        public int ClassSId { get; set; }
        public ClassS ClassS { get; set; }
    }
}

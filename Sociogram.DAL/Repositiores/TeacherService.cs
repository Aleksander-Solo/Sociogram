using Sociogram.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Repositiores
{
    public class TeacherService
    {
        ApplicationDbContext dbContext;
        public TeacherService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Create(Teacher teacher)
        {
            teacher.CreatedDate = DateTime.Now;
            dbContext.Teachers.Add(teacher);
            dbContext.SaveChanges();
        }
    }
}

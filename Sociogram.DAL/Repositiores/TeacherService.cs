using Microsoft.AspNetCore.Identity;
using Sociogram.DAL.Entities;
using Sociogram.DAL.Repositiores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Repositiores
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPasswordHasher<Teacher> _passwordHasher;
        public TeacherService(ApplicationDbContext _dbContext, IPasswordHasher<Teacher> passwordHasher)
        {
            dbContext = _dbContext;
            _passwordHasher = passwordHasher;
        }

        public void AddStudentConst(List<StudentConst> studentConstList, string name, string teatcherName)
        {
            Teacher teacher = dbContext.Teachers.Single(x => x.Name == teatcherName);
            dbContext.ClassS.Add(new ClassS { Name =name, StudentsConst = studentConstList , Teacher = teacher});
            //dbContext.StudentConst.AddRange(studentConstList);
            dbContext.SaveChanges();
        }

        public void Create(Teacher teacher)
        {
            teacher.CreatedDate = DateTime.Now;
            teacher.HashedPassword = _passwordHasher.HashPassword(teacher, teacher.HashedPassword);
            dbContext.Teachers.Add(teacher);
            dbContext.SaveChanges();
        }

        public Teacher Get(string name)
        {
            return dbContext.Teachers.SingleOrDefault(x => x.Name == name);
        }

        public List<ClassS> GetClassS(string teacherName)
        {
            int teacherId = dbContext.Teachers.Single(x => x.Name == teacherName).Id;
            return dbContext.ClassS.Where(x => x.TeacherId == teacherId).ToList();
        }
    }
}

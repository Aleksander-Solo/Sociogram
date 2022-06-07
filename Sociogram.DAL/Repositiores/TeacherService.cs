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
    }
}

using Sociogram.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociogram.DAL.Repositiores.Interfaces
{
    public interface ITeacherService
    {
        public void Create(Teacher teacher);
        public Teacher Get(string name);
    }
}

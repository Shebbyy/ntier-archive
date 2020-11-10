using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class TxtLessonRepository : ILessonRepository
    {
        public List<Lessons> Get()
        {
            throw new NotImplementedException();
        }

        public List<Lessons> GetById(string LessonID)
        {
            throw new NotImplementedException();
        }
    }
}

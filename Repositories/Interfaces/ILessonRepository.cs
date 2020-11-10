using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface ILessonRepository
    {
        List<Lessons> Get();
        List<Lessons> GetById(string LessonID);
    }
}

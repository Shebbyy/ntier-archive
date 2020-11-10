using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MockLessonRepository : ILessonRepository
    {
        private List<Lessons> LessonList;

        public MockLessonRepository()
        {
            LessonList = new List<Lessons>();

            LessonList.Add(new Lessons()
            {
                LessonName = "E",
                Teacher = "Atzlesberger",
                Description = "Boring english stuff you'll never need in your entire life"
            });

            LessonList.Add(new Lessons()
            {
                LessonName = "IMC",
                Teacher = "MSC Christoph Meisinger",
                Description = "Design and Web Dev"
            });

            LessonList.Add(new Lessons()
            {
                LessonName = "SWPM",
                Teacher = "DI Markus Meisinger",
                Description = "Programming stuff and managing Projects"
            });
        }
        public List<Lessons> Get()
        {
            return LessonList;
        }

        public List<Lessons> GetById(string LessonID)
        {
            throw new NotImplementedException();
        }
    }
}

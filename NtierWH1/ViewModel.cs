using System;
using System.Collections.Generic;
using System.Text;

namespace NtierWH
{
    public class ViewModel
    {
        public List<Lessons> LessonList { get; set; }

        private Lessons _SelectedLesson = null;
        public Lessons SelectedLesson
        {
            get { return _SelectedLesson; }
            set
            {
                if (_SelectedLesson != value)
                {
                    _SelectedLesson = value;
                }
            }
        }

        public ViewModel()
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
    }
}

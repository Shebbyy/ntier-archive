using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using Models;


namespace ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<Lessons> LessonList { get; set; }

        private Lessons _SelectedLesson = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public Lessons SelectedLesson
        {
            get { return _SelectedLesson; }
            set
            {
                if (_SelectedLesson != value)
                {
                    _SelectedLesson = value;
                    CurrentView = new LessonViewModel();

                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("CurrentView"));
                }
            }
        }

        public BaseViewModel CurrentView { get; set; }

        public ViewModel()
        {
            CurrentView = new WelcomeViewModel();

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

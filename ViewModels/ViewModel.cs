using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using DataAccess;
using Models;
using Repositories.Interfaces;

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

            ILessonRepository repo = new MockLessonRepository();
            LessonList = repo.Get();
        }
    }
}

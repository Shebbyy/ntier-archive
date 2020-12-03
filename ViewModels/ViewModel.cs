using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
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

            var CustomerRepoName = ConfigurationManager.AppSettings["LessonRepository"];
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            var currentDirectory = Path.GetDirectoryName(path);
            var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath($"{currentDirectory}/DataAccess.dll");
            var myType = myAssembly.GetType($"DataAccess.{CustomerRepoName}");
            ILessonRepository repo = (ILessonRepository)Activator.CreateInstance(myType);

            LessonList = repo.Get();
        }
    }
}

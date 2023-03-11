using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileGeneratorGui.Models;

namespace FileGeneratorGui.ViewModels
{
    public class ProjectListViewModel : ViewModelBase
    {

        public ProjectListViewModel()
        {
            var path = Constants.DefaultProjectPath;

            _projects = new ObservableCollection<Project>()
            {
                new Project("Test1", "A description", path + "_1"),
                new Project("Test2", "A description", path + "_2"),
                new Project("Test3", "A description", path + "_3"),
                new Project("Test4", "A description", path + "_4"),
            };
        }

        private ObservableCollection<Project> _projects;     
        public IEnumerable<Project> AllProjects
        {
            get
            {
                return _projects;
            }
        }

        private Project _project;
        public Project CurrentProject
        {
            get
            {
                return _project;
            }
            set
            {
                _project = value;
                OnPropertyChanged(nameof(CurrentProject));
            }
        }

    }
}

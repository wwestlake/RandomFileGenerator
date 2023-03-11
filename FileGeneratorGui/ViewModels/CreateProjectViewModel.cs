using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileGeneratorGui.Models;

namespace FileGeneratorGui.ViewModels
{
    public class CreateProjectViewModel : ViewModelBase
    {

        private Project _project;

        public CreateProjectViewModel(Project project)
        {
            _project = project;
        }


        public Project Project
        {
            get
            {
                return _project;
            }
        }

        public string Name
        {
            get
            {
                return _project.Name;
            }
            set
            {
                _project.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get
            {
                return _project.Description;
            }
            set
            {
                _project.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


        public string Folder
        {
            get
            {
                return _project.Folder;
            }
            set
            {
                _project.Folder = value;
                OnPropertyChanged(nameof(Folder));
            }
        }


    }
}

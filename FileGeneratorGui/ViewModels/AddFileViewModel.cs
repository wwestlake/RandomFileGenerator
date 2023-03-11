using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FileGeneratorGui.Commands;
using FileGeneratorGui.Models;
using FileGeneratorGui.Types;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FileGeneratorGui.ViewModels
{
    public class AddFileViewModel : ViewModelBase
    {
        private FileTypes _fileType;
        private ViewModelBase _detailsViewModel;

        public AddFileViewModel()
        {
            SelectFolderCommand = new DelegateCommand(SelectFolder);
            SaveCommand = new DelegateCommand(Save, CanSave);
            CancelCommand = new DelegateCommand(Cancel);
            FileType = FileTypes.Text;
            DetailsViewModel = new TextFileDetailsViewModel();
            DetailsViewModel.PropertyChanged += DetailsViewModel_PropertyChanged;
        }

        public DelegateCommand SelectFolderCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }



        public FileTypes FileType
        {
            get
            {
                return _fileType;
            }
            set
            {
                _fileType = value;
                OnPropertyChanged(nameof(FileType));
                SwitchDetailsViiew();
            }
        }

        private void SwitchDetailsViiew()
        {
            switch (FileType)
            {
                case FileTypes.Text:
                    {
                        DetailsViewModel = new TextFileDetailsViewModel();
                        DetailsViewModel.PropertyChanged += DetailsViewModel_PropertyChanged;
                        break;
                    }
                case FileTypes.Binary:
                    {
                        DetailsViewModel = new BinaryFileDetailsViewModel();
                        DetailsViewModel.PropertyChanged += DetailsViewModel_PropertyChanged;
                        break;
                    }
            }
        }

        private void DetailsViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public ViewModelBase DetailsViewModel
        {
            get
            {
                return _detailsViewModel;
            }
            set
            {
                _detailsViewModel = value;
                OnPropertyChanged(nameof(DetailsViewModel));
            }
        }



        private string _folder;

        public string Folder
        {
            get { return _folder; }
            set
            {
                _folder = value;
                OnPropertyChanged(nameof(Folder));
                SaveCommand.RaiseCanExecuteChanged();
            } 
        }

        private void SelectFolder(object? paramter)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                Folder = dialog.FileName;
            }
        }

        private string _filename;
        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                OnPropertyChanged(nameof(Filename));
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private int _size;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private int _blockSsize;
        public int BlockSize
        {
            get
            {
                return _blockSsize;
            }
            set
            {
                _blockSsize = value;
                OnPropertyChanged(nameof(BlockSize));
                SaveCommand.RaiseCanExecuteChanged();
            }
        }


        private bool CanSave(object? parameter)
        {
            var result =
                !string.IsNullOrEmpty(_folder)
                && !string.IsNullOrEmpty(_filename)
                && _size > 0
                && _blockSsize > 0
                && CanSaveDetails();
            return result;
        }

        private bool CanSaveDetails()
        {
            if (DetailsViewModel.GetType() == typeof(TextFileDetailsViewModel)) {
                var vm = (TextFileDetailsViewModel)DetailsViewModel;
                if (vm.UseParagraphs)
                {
                    return (vm.MinWords > 0 && vm.MaxWords > 0 && vm.MaxWords >= vm.MinWords);
                }
            } else
            {
                return true;
            }
            return true;
        }

        private void Save(object? parameter)
        {

        }

        private void Cancel(object? parameter)
        {

        }

    }
}

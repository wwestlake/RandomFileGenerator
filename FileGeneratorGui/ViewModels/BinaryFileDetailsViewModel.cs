using FileGeneratorGui.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneratorGui.ViewModels
{
    public class BinaryFileDetailsViewModel : ViewModelBase
    {
        private BinaryFileContents _contents = BinaryFileContents.RandomBytes;
        public BinaryFileContents Contents
        {
            get
            {
                return _contents;
            }
            set
            {
                _contents = value;
                OnPropertyChanged(nameof(Contents));
                OnPropertyChanged(nameof(CustomValueEnabled));
            }
        }

        private int _customValue;
        public int CustomValue
        {
            get
            {
                return _customValue;
            }
            set
            {
                _customValue = value;
                OnPropertyChanged(nameof(CustomValue));
            }
        }

        public bool CustomValueEnabled => _contents == BinaryFileContents.Custom;

    }
}

using FileGeneratorGui.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneratorGui.ViewModels
{
    public class TextFileDetailsViewModel : ViewModelBase
    {
        public TextFileDetailsViewModel()
        {
            _contents = TextFileContents.LoremIpsum;
            _format = TextFileFormat.Paragraphs;
        }

        private TextFileContents _contents;
        public TextFileContents Contents
        {
            get
            {
                return _contents;
            }
            set
            {
                _contents = value;
                OnPropertyChanged(nameof(Contents));
            }
        }

        private TextFileFormat _format;
        public TextFileFormat Format
        {
            get
            {
                return _format;
            }
            set
            {
                UseParagraphs = value == TextFileFormat.Paragraphs;
                _format = value;
                OnPropertyChanged(nameof(Format));
            }
        }

        private bool _useParagraphs = true;
        public bool UseParagraphs 
        { 
            get 
            {
                return _useParagraphs;
            } 
            set 
            { 
                _useParagraphs = value;
                OnPropertyChanged(nameof(UseParagraphs));
            } 
        }

        private int _minWords;
        public int MinWords
        {
            get
            {
                return _minWords;
            }
            set
            {
                _minWords = value;
                OnPropertyChanged(nameof(MinWords));
            }
        }

        private int _maxWord;
        public int MaxWords
        {
            get
            {
                return _maxWord;
            }
            set
            {
                _maxWord = value;
                OnPropertyChanged(nameof(MaxWords));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneration.Models
{
    public class FileManager
    {
        private List<FileDetails> _files = new List<FileDetails>();

        public IEnumerable<FileDetails> FilesGetFiles()
        {
            return _files;
        }

        public void AddFile(FileDetails file)
        {
            _files.Add(file);
        }

        public void RemoveFile(FileDetails file)
        {
            if (_files.Remove(file)) ;
        }

    }
}

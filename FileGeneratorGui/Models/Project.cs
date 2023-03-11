using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneratorGui.Models
{
    public class Project
    {
        private List<FileModelBase> _files = new List<FileModelBase>();

        public Project()
        {
            Name = "Enter Name";
            Description = "Enter Description";
            Folder = Constants.DefaultPath;
        }

        public Project(string name, string description, string folder)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Folder = folder;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Folder { get; set; }

        public IEnumerable<FileModelBase> GetFiles()
        {
            return _files;
        }

        public int FileCount
        {
            get { return _files.Count; }
        }

        public void AddFile(FileModelBase file)
        {
            foreach (var existingFile in _files)
            {
                if (existingFile.ConflictsWith(file))
                {
                    throw new FileConflictException(existingFile, file);
                }
            }
            _files.Add(file);
        }

        public void RemoveFIle(FileModelBase file)
        {
            _files.Remove(file);
        }

    }
}

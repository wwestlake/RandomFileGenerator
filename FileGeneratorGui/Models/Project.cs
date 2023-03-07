using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneratorGui.Models
{
    public class Project
    {
        private List<FileModelBase> files = new List<FileModelBase>();

        public Project(string name, string description, string folder)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Folder = folder;
        }

        public Guid Id { get; set; }

        public string Name { get; }
        public string Description { get; }

        public string Folder { get; }

        public IEnumerable<FileModelBase> GetFiles()
        {
            return files;
        }

        public void AddFile(FileModelBase file)
        {
            foreach (var existingFile in files)
            {
                if (existingFile.ConflictsWith(file))
                {
                    throw new FileConflictException(existingFile, file);
                }
            }
            files.Add(file);
        }

        public void RemoveFIle(FileModelBase file)
        {
            files.Remove(file);
        }

    }
}

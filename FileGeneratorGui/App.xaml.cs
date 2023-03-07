using FileGeneratorGui.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FileGeneratorGui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Project project = new Project(
                "Default Project",
                "THe default project for testing (to be removed)",
                Constants.DefaultPath
            );

            try
            {
                project.AddFile(
                    new BinaryFile(Constants.DefaultPath, "TestFile_1.dat", "simple test file", 1024, false, Constants.BlockSize)
                );
                project.AddFile(
                    new BinaryFile(Constants.DefaultPath, "TestFile_2.dat", "simple test file", 1024, false, Constants.BlockSize)
                );

            } catch (FileConflictException ex)
            { 
                // TODO: Handle exceptions and error reporting??  This is just test code!
            }

            var files = project.GetFiles();


            base.OnStartup(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestMaker
{
    internal class FileUtils
    {
        /// <summary>
        /// This funtion is ensures that the output directory exists in the MyDocuments folder of the user
        /// </summary>
        public void SetupOutputDirectory(string basePath)
        {
            // Try to create the directory.
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(basePath));
            }
            else
            {
                Console.WriteLine("That path exists already.");
            }
        }

        public void SetupProjectDirectories(string targetPath)
        {
            string sourcePath = "Templates";
            //string path = "/CrestMaker";

            // Try to create the directory.
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);

                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                }

                //Copy all the files & Replaces any files with the same name
                foreach (string filePath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(filePath, filePath.Replace(sourcePath, targetPath), true);
                }

                Debug.WriteLine("The project was setup successfully at {0}.", Directory.GetCreationTime(targetPath));
            }
            else
            {
                Debug.WriteLine("Directory already initialized.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
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
        public void SetupOutputDirectory(string path)
        {
            // Try to create the directory.
            if (!Directory.Exists(path))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            else
            {
                Console.WriteLine("That path exists already.");
            }
        }
    }
}

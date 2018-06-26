using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using FileHelpers;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ContactCreatorService
{
    public partial class FileCheck : ServiceBase
    {
        public FileCheck()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {                                                                           // File external, file internal

            string fileName = "contacts.csv";                                       // File Name
            string fileDir = @"Y:\Programming\TestFolder";                          // File Directory
                                                                                    
            string File = Path.Combine(fileDir, fileName);                          // File Path

            if (!Directory.Exists(fileDir))
            {   // check for Destination Directory and create
                Directory.CreateDirectory(fileDir);
                // get all files from Source Directory
                string[] files = Directory.GetFiles(fileDir);

                foreach (string file in files)
                {   // checks for specific files

                    FileInfo fi = new FileInfo(file);
                    string[] fiNameSplit = fi.Name.Split('.');      // FILEINFO NAME SPLIT
                    fiNameSplit[fiNameSplit.Length - 1] = "." + fiNameSplit[fiNameSplit.Length - 1];
                    string[] fNameSplit = fileName.Split('.');      // FILENAME SPLIT
                    fNameSplit[fiNameSplit.Length - 1] = "." + fNameSplit[fiNameSplit.Length - 1];


                    if (fi.Name.Contains("- complete") && fi.LastAccessTime < DateTime.Now.AddDays(-30))
                        fi.Delete();    // delete complete files that are 30 days or older

                    if (fi.Name.Contains("- processed"))
                    {   // processed files are complete
                        string[] fNameFix = fiNameSplit[0].Split('-');
                        
                        fileName = fNameFix[0] + "- complete" + fiNameSplit[1];
                        File = Path.Combine(fileDir, fileName);

                        System.IO.File.Copy(file, File);    // changes file name
                    }

                    if (fi.Name.Contains(fNameSplit[0]) && !fi.Name.Contains("-"))
                    {   // new files are processed
                        fileName = fiNameSplit[0] + " - processing" + fiNameSplit[1];

                        System.IO.File.Copy(file, File);

                        
                    }

                }
            }
            else
            {   // Error Checking
                Console.WriteLine("Source path does not exist!");
            }
        }

        protected override void OnStop()
        {
        }
    }
}

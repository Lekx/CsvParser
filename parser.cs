using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica4CsvParser
{
    class parser
    {
        private string @filePath;

        public void parseFile() 
        {
            readFile();
            verifyFileType();
        }

        private void readFile()
        {
            Console.Write("\nPlease type the full path of the \"CSV\" file that you want to parse:\n\n\n\t\t");
            this.filePath = Console.ReadLine();
        }

        public void verifyFileType()
        {

            if (File.Exists(this.filePath))
            {
                if (Path.GetExtension(this.filePath) == ".csv")
                {
                    getFileContent();
                }
                else
                {
                    Console.WriteLine("\n\n\tSorry but " + Path.GetExtension(this.filePath) + " files are not allowed, only .CSV files\n");
                    Console.ReadKey();
                    Console.Clear();
                    readFile();
                }
            }
            else 
            {
                Console.WriteLine("\n\n\tSorry but " + this.filePath + " does not exist, try again...\n");
                Console.ReadKey();
                Console.Clear();
                readFile();
            }
        }
        /*
        public Boolean verifyFile()
        {

            if (File.Exists(this.filePath))
                return true;
            else
                return false;

        }
        */
        private void getFileContent() 
        {
            List<string[]> csvArray = new List<string[]>();
            string line;
            string[] row;

            try
            {
                StreamReader readFile = new StreamReader(this.filePath);
                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(',');
                    csvArray.Add(row);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            printInformation(csvArray);
        }


        private void printInformation(List<string[]> csvArray) 
        {
            string delimiter = "\n------------------------------------------------------------------------\n";

            Console.Clear();
            Console.WriteLine("\nThe following information was found in your file(" + this.filePath + "): \n");

            foreach (string[] array in csvArray)
            {
                if (array.Length > 0)
                {
                    Console.WriteLine("Id:" + array[0]);
                }
                if (array.Length > 1)
                {
                    Console.WriteLine("Name:" + array[1]);
                }
                if (array.Length > 2)
                {
                    Console.WriteLine("Address:" + array[2]);
                }
                if (array.Length > 3)
                {
                    Console.WriteLine("Phone:" + array[3]);
                }

               /* Console.WriteLine(delimiter + "id: " + array[0] + "\t\t\t\t\tNombre: " + array[1] + "\nDirección: " + array[2] + "\t\tTelefono: " + array[3] + delimiter);*/
            
            }
        
        }

    }
}

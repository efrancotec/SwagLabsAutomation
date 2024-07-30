using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Utils
{
    public class FileHelper
    {
        public static List<string> ReadTextFile(string filePath)
        {
            string line;
            List<string> lines = new List<string>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filePath);
                //Read the first line of text
                line = sr.ReadLine()!;
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //add line to lines list
                    lines.Add(line);
                    //Read the next line
                    line = sr.ReadLine()!;
                }
                //close the file
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lines;
        }
    }
}

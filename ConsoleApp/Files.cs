using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp
{
    public class Files
    {
        public void createFile(String filename)
        {
            StreamWriter sw = File.CreateText(filename);
            sw.Close();
        }

        public void writeFile(String filename, string text)
        {
            File.AppendAllText(filename, $"{text}\n");
        }

        public string readFile(string filename)
        {
            string text = File.ReadAllText(filename);
            return text;
        }

        public void deleteFile(string filename)
        {
            File.Delete(filename);
        }
    }
}
using System;
using System.IO;

namespace ConsoleApp.Classes
{
    public class Files
    {
        public void createFile(String path)
        {
            StreamWriter sw = File.CreateText(path);
            sw.Close();
        }

        public void writeFile(String filename, String text)
        {
            File.AppendAllText(filename, text);
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
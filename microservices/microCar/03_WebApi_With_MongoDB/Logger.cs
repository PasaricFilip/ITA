using System;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Runtime.InteropServices;

namespace _03_WebApi_With_MongoDB
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            //before we write messages, we need to read them

            // Create a StreamReader
            using StreamReader reader = new StreamReader("C:\\Users\\Filip\\Desktop\\Faks\\Predmeti\\DRUGI SEMESTER\\IT ARHITEKTURE\\N2\\StartupHakk\\03_WebApi_With_MongoDB\\LogInfo.txt");

            // Create an array to store the lines
            var lines = new List<string>();

            // Read the stream line by line and add each line to the array
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                lines.Add(line);
            }

            // Convert the list to an array
            string[] linesArray = lines.ToArray();
            // To close the stream
            reader.Close();
            // This will create a file named MyFile.txt at the specified location i.e. in the D Drive
            // Here we are using the StreamWriter constructor which takes the string path as an argument to create an instance of StreamWriter class
            StreamWriter sw = new StreamWriter("C:\\Users\\Filip\\Desktop\\Faks\\Predmeti\\DRUGI SEMESTER\\IT ARHITEKTURE\\N2\\StartupHakk\\03_WebApi_With_MongoDB\\LogInfo.txt");
            string complete_message = "date : "+DateTime.Now.ToString() + " message : " + message;
            //write all the other stuff
            foreach(string line in lines)
            {
                sw.WriteLine(line.ToString());

            }
            // To write the data into the stream
            sw.WriteLine(complete_message);
            // Clears all the buffers
            sw.Flush();
            // To close the stream
            sw.Close();
        }
    }
}

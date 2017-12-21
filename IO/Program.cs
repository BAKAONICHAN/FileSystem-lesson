using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace IO
{
    class Program
    {
        static void Main(string[] args)
        {
            /*FileStream-работает с байтами
             *StremReader/StreamWriter-работает с текстом
             *BinaryReader/BinaryWriter-работает с файлами .bin            
             */

            string text = "gg EASY";
            byte[] source = Encoding.UTF32.GetBytes(text);
            using (FileStream stream = new FileStream(@"C:\name_of_directory\my_file.txt", FileMode.OpenOrCreate))
            {
                stream.Write(source, 0, source.Length);

            }
            byte[] reciver = File.ReadAllBytes(@"C:\name_of_directory\my_file.txt");
            //using (FileStream stream = File.ReadAllBytes)
            using (FileStream stream = File.OpenRead(@"C:\name_of_directory\my_file.txt"))
            {
                byte[] recievedData = new byte[stream.Length];
                stream.Read(recievedData, 0, recievedData.Length);
                string recievedtext = Encoding.UTF32.GetString(recievedData);

            }
            using (StreamWriter writer = new StreamWriter(File.Open(@"C:\name_of_directory\data.txt",FileMode.Append)))
            {
                string send_text = "hello";
                writer.WriteLine(send_text);


            }
            using (StreamReader reader = new StreamReader(File.Open(@"C:\name_of_directory\data.txt", FileMode.Open)))
            {
                string recievedText = "";
                recievedText = reader.ReadToEnd();
               

            }
            ///////////
            using (BinaryWriter binarywriter = new BinaryWriter(File.Open(@"C:\name_of_directory\data.bin", FileMode.Open)))
            {
                var person = new { Name = "af", Age = 27, Sex = true };
                binarywriter.Write(person.Name);
                binarywriter.Write(person.Age);
                binarywriter.Write(person.Sex);

            }
            using (BinaryReader reader = new BinaryReader(File.Open(@"C:\name_of_directory\data.bin", FileMode.Open)))
            {
                
                string Name = reader.ReadString();
                int age = reader.ReadInt32();
                bool Sex = reader.ReadBoolean();
                var person = new { Name = Name, Age =age, Sex = Sex };


            }
            /* var drives = DriveInfo.GetDrives();
             Directory.CreateDirectory(@"C:\name_of_directory");
             DirectoryInfo dir = new DirectoryInfo(@"C:\name_of_directory");
             var dirr = Directory.GetCurrentDirectory();
             if (Directory.Exists(@"C:\name_of_directory"))
             { File.Create(@"C:\name_of_directory\my_file.txt");}
             else
             {WriteLine("Is not created");}
             FileInfo fileinfo = new FileInfo(@"C:\name_of_directory\my_file.txt");*/
            ReadLine();
        }

    }
}
using Newtonsoft.Json;
using System.IO;
using System.Reflection.Metadata.Ecma335;
namespace HomeTaskFileDirectoryStreamWriterStreamReaderSerialize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddName("Shahin");
            Search("Shahin");
            Delete("Shahin");
       


        }
        public static void AddName(string name)
        {
            string  path = @"C:\Users\ASUS\Desktop\en son\HomeTaskFileDirectoryStreamWriterStreamReaderSerialize\Files\Names.json";
            List<string> names = Deserialize(path);
            names.Add(name);
            Serialize<List<string>>(path, names);
            Console.WriteLine(name+" Ugurla elave olundu");
        }
        public static void Serialize<T>(string path, T obj)
        {
            string result = JsonConvert.SerializeObject(obj);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(result);
            }
        }
        public static bool Search(string name) 
        {
            string path = @"C:\Users\ASUS\Desktop\en son\HomeTaskFileDirectoryStreamWriterStreamReaderSerialize\Files\Names.json";
            List<string> names = Deserialize(path);
          return names.Contains(name);
        }
        public static void Delete(string name) 
        {
            string path = @"C:\Users\ASUS\Desktop\en son\HomeTaskFileDirectoryStreamWriterStreamReaderSerialize\Files\Names.json";
            List <string> names = Deserialize(path);
            if (names.Contains(name)) 
            {
                names.Remove(name);
                Console.WriteLine(name+" ugurla silindi");
                Serialize(path, names);
            }
        }
        public static List<string> Deserialize(string path)
        {
            string result;
           

            using (StreamReader sr = new StreamReader(path))
            {
                result = sr.ReadToEnd();
            }
            List<string> names = JsonConvert.DeserializeObject<List<string>>(result);
            return names;
        }
       

    }
}// Mellim tam sekilde yaza bilmedim basa dusduyum qeder gedisati yazdim

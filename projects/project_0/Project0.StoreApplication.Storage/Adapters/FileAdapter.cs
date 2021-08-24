using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Storage.Adapters
{
  public class FileAdapter
  {
    public T ReadFromFile<T>(string path) where T : class
    {
      var reader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(T));

      return xml.Deserialize(reader) as T; 
    }

    public void WriteToFile<T>(string path, T data) where T : class
    {
      var writer = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(T));

      xml.Serialize(writer, data); 
    }

    // public List<Store> ReadFromFile()
    // {
    //   // file path
    //   string path = @"/home/zachary/revature/training_code/ZacharyWoolfolk1/data/project_0.xml";
    //   // open file
    //   var file = new StreamReader(path);
    //   // serialize
    //   var xml = new XmlSerializer(typeof(List<Store>));
    //   // write to file
    //   var stores = xml.Deserialize(file) as List<Store>;
    //   // return data
    //   return stores;
    // }

    // public void WriteToFile(List<Store> stores)
    // {
    //   // file path
    //   string path = @"/home/zachary/revature/training_code/ZacharyWoolfolk1/data/project_0.xml";
    //   // open file
    //   var file = new StreamWriter(path);
    //   // serialize
    //   var xml = new XmlSerializer(typeof(List<Store>));
    //   // write to file
    //   xml.Serialize(file, stores);
    // }
  }
}
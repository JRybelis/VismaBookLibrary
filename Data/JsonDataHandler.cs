using Newtonsoft.Json;
using System.IO;

namespace Data
{
    public class JsonDataHandler
    {
        public T ReadData<T>(string filename) where T : class
        {
            if (!File.Exists(filename))
            {
                return (T)null;
            }
            var json = File.ReadAllText(filename);

            if (string.IsNullOrEmpty(json))
            {
                return (T)null;
            }

            var jsonData = JsonConvert.DeserializeObject<T>(json);
            return jsonData;
        }

        public void SaveData(string filename, object data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filename, json);
        }
    }
}

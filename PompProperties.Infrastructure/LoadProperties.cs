using PompProperties.Domain.Entities;
using System.Text.Json;

namespace PompProperties.Infrastructure
{
    public class LoadProperties
    {
        public Properties? Load()
        {
            string dataResourceText;
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "data.json");
                //Console.WriteLine(path);
                using StreamReader sr = File.OpenText(path);
                dataResourceText = sr.ReadToEnd();
                Properties? properties = JsonSerializer.Deserialize<Properties>(dataResourceText);
                return properties;

            }
            catch (FileNotFoundException ex)
            {
                dataResourceText = ex.Message;
                return null;
            }
        }
    }
}

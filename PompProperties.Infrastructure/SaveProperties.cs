using PompProperties.Domain.Entities;
using System.Text.Json;

namespace PompProperties.Infrastructure
{
    public class SaveProperties
    {
        public static async Task Save(Properties? properties)
        {
            string dataResourceText;
            try
            {
                dataResourceText = JsonSerializer.Serialize(properties);
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "data.json");
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(dataResourceText);
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    dataResourceText = await sr.ReadToEndAsync();
                    properties = JsonSerializer.Deserialize<Properties>(dataResourceText);
                }
            }
            catch (FileNotFoundException ex)
            {
                dataResourceText = ex.Message;
            }

        }
    }
}

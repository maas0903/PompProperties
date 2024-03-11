using PompProperties.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PompProperties.Infrastructure
{
    public class SaveProperties
    {
        public static async Task Save(Properties properties)
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

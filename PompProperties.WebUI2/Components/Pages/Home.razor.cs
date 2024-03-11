using PompProperties.Domain.Entities;
using PompProperties.Infrastructure;

namespace PompProperties.WebUI2.Components.Pages
{
    public partial class Home
    {
        private string dataResourceText;
        private Properties properties = new();

        protected override void OnInitialized()
        {
            LoadProperties loadProperties = new();
            properties = loadProperties.Load();
        }

        public void OnValidSubmit()
        {
            properties.ValuesChanged = true;
            _ = SaveProperties.Save(properties);
            StateHasChanged();
        }

        public void OnInvalidSubmit()
        {
            //Console.WriteLine("Invalid Submit");
        }
    }
}

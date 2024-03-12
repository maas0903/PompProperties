using PompProperties.Domain.Entities;
using PompProperties.Infrastructure;

namespace PompProperties.WebUI.Components.Pages
{
    public partial class Home
    {
        private Properties? properties = new();

        protected override void OnInitialized()
        {
            LoadProperties loadProperties = new();
            properties = loadProperties.Load();
        }

        public void OnValidSubmit()
        {
            properties ??= new();
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

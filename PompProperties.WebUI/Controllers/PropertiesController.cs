using Microsoft.AspNetCore.Mvc;
using PompProperties.Domain.Entities;
using PompProperties.Infrastructure;

namespace PompProperties.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertiesController : ControllerBase
    {
        [HttpGet]
        public Properties GetProperties()
        {
            LoadProperties loadProperties = new();
            Properties? properties = loadProperties.Load();
            Properties? propertiesToSave = loadProperties.Load();
            if (propertiesToSave == null)
            {
                propertiesToSave = new();
            }
            propertiesToSave.ValuesChanged = false;
            propertiesToSave.StartwitchedOn = false;
            _ = SaveProperties.Save(propertiesToSave);

            properties ??= new();
            return properties;
        }
    }

}

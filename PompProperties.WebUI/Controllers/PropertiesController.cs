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
            Properties properties = loadProperties.Load();
            Properties propertiesToSave = loadProperties.Load();
            propertiesToSave.ValuesChanged = false;
            SaveProperties.Save(propertiesToSave);
            return properties;
        }
    }

}

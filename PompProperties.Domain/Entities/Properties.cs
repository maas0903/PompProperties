using System.ComponentModel.DataAnnotations;

namespace PompProperties.Domain.Entities
{
    public class Properties
    {
        [Required(ErrorMessage = "Ure tussenin moet tussen 1 en baie wees")]
        [Range(1, int.MaxValue, ErrorMessage = "Ure tussenin moet tussen 1 en baie wees")]
        public string UreTussenin { get; set; }
        [Required(ErrorMessage = "Sekondes aan moet tussen 1 en baie wees")]
        [Range(1, int.MaxValue, ErrorMessage = "Sekondes aan moet tussen 1 en baie wees")]
        public string SekondesAan { get; set; }
        public bool ValuesChanged { get; set; }
        public bool Reset { get; set; }
    }
}
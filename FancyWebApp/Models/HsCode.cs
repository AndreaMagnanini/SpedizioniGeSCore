using System.ComponentModel.DataAnnotations;

namespace FancyWebApp.Models
{
    public class HsCode
    {
        [Key]
        [Required]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

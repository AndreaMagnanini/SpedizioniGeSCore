using Newtonsoft.Json;

namespace FancyWebApp.Models.Common;

public class UserTrace
{
    [JsonIgnore] public DateTime CreationDate { get; set; }
    [JsonIgnore] public string CreationUser { get; set; }
    [JsonIgnore] public DateTime? TouchingDate { get; set; }
    [JsonIgnore] public string TouchingUser { get; set; }   
    [JsonIgnore] public DateTime? DeletionDate { get; set; }
    [JsonIgnore] public string DeletionUser { get; set; }
}
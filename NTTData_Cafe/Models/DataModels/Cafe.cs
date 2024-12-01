using System.ComponentModel.DataAnnotations;

namespace NTTData_Cafe.Models.DataModels
{
    public class Cafe
    {
        [Key]
        public Guid CafeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string? Logo { get; set; }
    }
}

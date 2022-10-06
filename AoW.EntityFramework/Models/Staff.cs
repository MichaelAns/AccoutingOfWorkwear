using AoW.EntityFramework.Models.Base;

namespace AoW.EntityFramework.Models
{
    public class Staff : BaseEntity
    {
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; } 
        public string Profession { get; set; }
        public string Post { get; set; }
        public virtual ICollection<ExtraditionInfo>? Extraditions { get; set; }
    }
}

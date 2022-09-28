using AoW.EntityFramework.Models.Base;

namespace AoW.EntityFramework.Models
{
    public class WorkWear : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }
}

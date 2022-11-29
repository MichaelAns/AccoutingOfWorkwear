using AoW.EntityFramework.Models.Base;

namespace AoW.EntityFramework.Models
{
    public class Provider : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? Home { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<ReceiptInfo>? ReceiptInfos { get; set; }

    }
}

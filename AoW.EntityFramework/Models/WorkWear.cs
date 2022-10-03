using AoW.EntityFramework.Models.Base;

namespace AoW.EntityFramework.Models
{
    public class WorkWear : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public virtual ICollection<ReceiptInfo> ReceiptInfos { get; set; }  
        public virtual ICollection<ExtraditionInfo> ExtraditionInfos { get; set; }  
    }
}

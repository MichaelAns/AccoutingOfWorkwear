using AoW.EntityFramework.Models.Base;

namespace AoW.EntityFramework.Models
{
    public class ReceiptInfo : BaseEntity
    {
        public int Count { get; set; }
        public int Remains { get; set; }
        public DateOnly Date { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual WorkWear WorkWear { get; set; }
    }
}

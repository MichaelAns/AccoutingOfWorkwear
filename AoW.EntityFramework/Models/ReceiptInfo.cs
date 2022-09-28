using AoW.EntityFramework.Models.Base;

namespace AoW.EntityFramework.Models
{
    public class ReceiptInfo : BaseEntity<int>
    {
        public int Count { get; set; }
        public DateOnly Date { get; set; }
    }
}

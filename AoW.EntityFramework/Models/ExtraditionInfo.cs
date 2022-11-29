namespace AoW.EntityFramework.Models
{
    public class ExtraditionInfo : Base.BaseEntity
    {
        public DateOnly Date { get; set; }
        public int Term { get; set;  }  
        public virtual WorkWear WorkWear { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
